using AutoMapper;
namespace AspNetCoreWebApiTask1.Profiles;

public class BookProfile : Profile
{
    public BookProfile()
    {
        CreateMap<Entities.Book, Models.BookDto>();
        CreateMap<Models.BookCreationDto, Entities.Book>();
        CreateMap<Models.SpecialBookForUpdateDto, Entities.SpecialBook>();
        CreateMap<Models.SpecialBookCreationDto, Entities.SpecialBook>();
        CreateMap<Entities.SpecialBook, Models.SpecialBookDto>();
        CreateMap<Models.SpecialBookDto, Entities.SpecialBook>();
        CreateMap<Entities.SpecialBook, Entities.Book>();
        CreateMap<Entities.Book, Entities.SpecialBook>();
        CreateMap<Models.SpecialBookForUpdateDto,Models.SpecialBookDto>();
    }
}
