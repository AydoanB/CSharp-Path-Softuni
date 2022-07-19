using Artillery.Data.Models;
using Artillery.DataProcessor.ImportDto;

namespace Artillery
{
    using AutoMapper;
    class ArtilleryProfile : Profile
    {
        // Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE THIS CLASS
        public ArtilleryProfile()
        {
            this.CreateMap<ImportCountriesDto, Country>();
            this.CreateMap<ImportGunsDto, Gun>();
        }
    }
}