using Examination.Domain.Entities.Students;
using Examintaion.Service.ApiInterfaces;
using Examintaion.Service.Configurations;
using Examintaion.Service.DTOs.StudentForCreation;
using Examintaion.Service.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Examintaion.Service.Services
{
    public class StudentService : IStudentService
    {
        public async Task<Student> CreateAsync(StudentForCreation dto)
        {
            using (HttpClient client = new HttpClient())
            {
                string json = JsonConvert.SerializeObject(dto);
                HttpResponseMessage response = await client.PostAsync(AppSettings.API_PATH + "students", 
                    new StringContent(json, Encoding.Default, "application/json"));

                string message = await response.Content.ReadAsStringAsync();

                if (string.IsNullOrEmpty(message))
                    return null;

                return JsonConvert.DeserializeObject<Student>(message);
            }
        }

        public async Task<bool> DeleteAsync(long id)
        {
            using(HttpClient client = new HttpClient())
            {
                var result = await client.DeleteAsync(AppSettings.API_PATH + "students/" + id);

                return result.IsSuccessStatusCode;
            }
        }

        public async Task<IEnumerable<Student>> GetAllAsync(string login, string password)
        {
            using (HttpClient client = new HttpClient())
            {
                string encoded = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(AppSettings.Login + ":" + AppSettings.Password));

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", encoded);

                var response = await client.GetAsync(AppSettings.API_PATH);
                
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<IEnumerable<Student>>(content);

                }

                return null;
            }
            
        }
        public async Task<Student> GetAsync(long id)
        {
            using (HttpClient client = new HttpClient())
            {
                return await client.GetFromJsonAsync<Student>(AppSettings.API_PATH + "students/" + id);
            }
        }

        public async Task<Student> UpdateAsync(long id, StudentForCreation dto)
        {
            using (HttpClient client = new HttpClient())
            {
                string json = JsonConvert.SerializeObject(dto);
                HttpResponseMessage response = await client.PutAsync(AppSettings.API_PATH + "students/" + id,
                    new StringContent(json,Encoding.Default, "application/json"));

                string message = await response.Content.ReadAsStringAsync();
                
                if (string.IsNullOrEmpty(message))
                    return null;

                return JsonConvert.DeserializeObject<Student>(message);
            }
        }

        public async Task UploadFilesAsync(long id, string imagePath, string passportPath)
        {
            using (HttpClient client = new HttpClient())
            {
                MultipartFormDataContent formData = new MultipartFormDataContent();
                formData.Add(new StreamContent(File.OpenRead(imagePath)), "image", "image.png");
                formData.Add(new StreamContent(File.OpenRead(passportPath)), "passport", "passport.png");

                HttpResponseMessage response = await client.PostAsync(AppSettings.API_PATH + "students/attachments/" + id, formData); 

                string message = await response.Content.ReadAsStringAsync();
            }
        }
    }
}
