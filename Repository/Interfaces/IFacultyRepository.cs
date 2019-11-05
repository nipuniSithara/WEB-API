using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
   public interface IFacultyRepository
    {
        Task<IEnumerable<Faculty>> Select(string FacultyId);
        Task<int> Delete(string FacultyId);
        Task<int> Insert(Faculty faculty);
        Task<int> Update(Faculty faculty);
    }
}
