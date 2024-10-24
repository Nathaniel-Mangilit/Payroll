using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dto.WorkInfo;
using api.Model;

namespace api.Interface
{
    public interface IWorkInfoRepository
    {
        Task<List<WorkInfo>> GetAllAsync();
        Task<WorkInfo?> GetByIdAsync(int id);
        Task<WorkInfo> CreateAsync(WorkInfo workModel);
        Task<WorkInfo?> UpdateAsync(int id, UpdateWorkInfoDto updateDto);
        Task<WorkInfo?> DeleteAsync(int id);
    }
}