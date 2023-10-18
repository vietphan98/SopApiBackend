using AutoMapper;
using SopApi.Data;
using SopApi.Models;
using System.Security.Cryptography.X509Certificates;

namespace SopApi.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Test,TestModel>().ReverseMap();
        }
    }
}
