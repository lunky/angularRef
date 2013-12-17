using AutoMapper;
using Entities;
using Shared;

namespace angularRef.Service
{
	public class MapperConfig
	{
		public static void RegisterMappings()
		{
			Mapper.CreateMap<Kid, KidDto>().ReverseMap();
		}
	}
}