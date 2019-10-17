using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWEBAPI.Services
{
    public interface IService<TEnity, in TPk>
    {
        Task<IEnumerable<TEnity>> GetAsync();
        Task<TEnity> GetAsync(TPk id);
        Task<TEnity> CreateAsync(TEnity enity);
        Task<TEnity> UpdateAsync(TPk id, TEnity enity);
        Task<bool> DeleteAsync(TPk id); 
    }
}
