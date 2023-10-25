using AutoMapper;
using data = Solution.DO.Objects;

namespace Solution.API.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile() {
            CreateMap<data.Goal, DataModels.Goal>().ReverseMap();
        }
    }
}
