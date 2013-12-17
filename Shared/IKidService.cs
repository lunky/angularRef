using System.Collections.Generic;

namespace Shared
{
	public interface IKidService
	{
		void SaveKids(IEnumerable<KidDto> kids);
		void SaveOrUpdateKids(IEnumerable<KidDto> kids);
		IEnumerable<KidDto> GetKids();
	}
}