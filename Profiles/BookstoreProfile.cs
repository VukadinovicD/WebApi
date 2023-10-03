using AutoMapper;
namespace AspNetCoreWebApiTask1.Profiles;

public class BookstoreProfile : Profile
{
    public BookstoreProfile()
    {
        CreateMap<Entities.Bookstore, Models.BookstoreDto>();
    }
}
