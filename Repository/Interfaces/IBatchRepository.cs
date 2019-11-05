using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
   public interface IBatchRepository
    {
        Task<IEnumerable<Batch>> Select(string BatchId);
        Task<int> Delete(string BatchId);
        Task<int> Insert(Batch batch);
        Task<int> Update(Batch batch);
    }
}
