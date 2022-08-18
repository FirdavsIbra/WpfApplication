using AutoMapper;
using Examination.Domain.Entities.Students;
using Examintaion.Service.DTOs.StudentForCreation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examintaion.Service.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Student, StudentForCreation>().ReverseMap();
            CreateMap<Attachment, StudentFileForCreation>().ReverseMap();
        }
    }
}
