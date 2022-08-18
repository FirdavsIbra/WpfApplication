using Examination.Data.IRepositories.StudentRepo;
using Examination.Domain.Entities.Students;
using Examintaion.Service.DTOs.StudentForCreation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examintaion.Service.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetAllAsync(string login, string password);
        Task<Student> GetAsync(long id);
        Task<Student> CreateAsync(StudentForCreation dto);
        Task<Student> UpdateAsync(long id, StudentForCreation dto);
        Task<bool> DeleteAsync(long id);
        Task UploadFilesAsync(long id, string imagePath, string passportPath);
    }
}
