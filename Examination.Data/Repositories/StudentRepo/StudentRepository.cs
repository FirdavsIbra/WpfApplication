using Examination.Data.DbContexts;
using Examination.Data.IRepositories.StudentRepo;
using Examination.Data.Repositories.GenericRepo;
using Examination.Domain.Entities.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination.Data.Repositories.StudentRepo
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(ExaminationDbContext airportSystemContext) : base(airportSystemContext)
        {
        }
    }
}
