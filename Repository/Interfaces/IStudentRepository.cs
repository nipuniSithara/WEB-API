using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
namespace Repository.Interfaces
{
   public interface IStudentRepository
    {
        Task<IEnumerable<Student>>Select(string StudentId);
        Task<int> Delete(string StudentId);
        Task<int> Insert(Student student);
        Task<int> Update(Student student);
    }
}
