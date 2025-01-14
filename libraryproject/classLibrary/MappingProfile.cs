using AutoMapper;
using Library.Core.Modals.ModalsDTO;
using Library.Core.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Subscribe, SubscribePost>().ReverseMap();
            CreateMap<Book, BookPost>().ReverseMap();
            //CreateMap<Borrow, BorrowPost>().ReverseMap();
            CreateMap<Subscribe, SubscribePut>().ReverseMap();
        }
    }
}
