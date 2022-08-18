using Examination.Data.IRepositories.IGenericRepo;
using Examination.Domain.Entities.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination.Data.IRepositories.StudentRepo
{
    public interface IStudentRepository : IGenericRepository<Student>
    {

    }
}
