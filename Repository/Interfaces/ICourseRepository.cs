using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> Select(string CourseId);
        Task<int> Delete(string CourseId);
        Task<int> Insert(Course course);
        Task<int> Update(Course course);
    }
}
