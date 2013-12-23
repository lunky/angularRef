using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Entities;
using Shared;

namespace angularRef.Service
{
	public class KidService : IKidService
	{
		private readonly IRepository<Kid> _kidRepository;
		private readonly IUnitOfWork _unitOfWork;

		public KidService(IRepository<Kid> kidRepository, IUnitOfWork unitOfWork)
		{
			_kidRepository = kidRepository;
			_unitOfWork = unitOfWork;
		}

		public void SaveKids(IEnumerable<KidDto> kids)
		{
			SaveOrUpdateKids(kids);
			System.Diagnostics.Debug.WriteLine("kids");
		}


		public void SaveOrUpdateKids(IEnumerable<KidDto> kids)
		{
			foreach (var kid in kids)
			{
				var isEditAction = kid.Id > 0;
				Kid saveKid;

				if (!isEditAction)
				{
					saveKid = new Kid();
					_kidRepository.Insert(saveKid);
				}
				else
				{
					saveKid = _kidRepository.FindById(kid.Id);
				}
				if (saveKid == null)
				{
					throw new Exception("Entity not found.");
				}
				saveKid.Age = kid.Age;
				saveKid.Name = kid.Name;
				saveKid.FamilyId = kid.FamilyId;
			}
			var changes = _unitOfWork.SaveChanges();
			System.Diagnostics.Debug.WriteLine("changes " + changes);
		}

		public IEnumerable<KidDto> GetKids()
		{
			var kids = _kidRepository.All();
			return Mapper.Map<IEnumerable<Kid>, IEnumerable<KidDto>>(kids);
		}

		public IEnumerable<KidDto> GetKids(int familyId)
		{
			var kids = _kidRepository.All().Where(f => f.FamilyId == familyId);
			return Mapper.Map<IEnumerable<Kid>, IEnumerable<KidDto>>(kids);
		}

	}
}
