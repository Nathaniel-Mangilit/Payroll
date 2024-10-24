using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dto.WorkInfo;
using api.Interface;
using api.Model;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{

    public class WorkInfoRepository : IWorkInfoRepository
    {
        private readonly ApplicationDBContext _context;
        public WorkInfoRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<WorkInfo> CreateAsync(WorkInfo workModel)
        {
            await _context.WorkInfos.AddAsync(workModel);
            await _context.SaveChangesAsync();
            return workModel;
        }

        public async Task<WorkInfo?> DeleteAsync(int id)
        {
           var workModel = await _context.WorkInfos.FirstOrDefaultAsync(x => x.Id == id);

           if(workModel == null)
           {
            return null;
           }
           _context.WorkInfos.Remove(workModel);
           await _context.SaveChangesAsync();
           return workModel;
        }

        public async Task<List<WorkInfo>> GetAllAsync()
        {
            return await _context.WorkInfos.ToListAsync();
        }

        public async Task<WorkInfo?> GetByIdAsync(int id)
        {
           return await _context.WorkInfos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<WorkInfo?> UpdateAsync(int id, UpdateWorkInfoDto updateDto)
        {
           var existingInfo = await _context.WorkInfos.FirstOrDefaultAsync(x => x.Id == id);
           if(existingInfo == null)
           {
            return null;
           }
           existingInfo.Company = updateDto.Company;
           existingInfo.Department = updateDto.Department;
           existingInfo.Position = updateDto.Position;
           existingInfo.SuperVisor = updateDto.SuperVisor;
           existingInfo.WorkPlace = updateDto.WorkPlace;
          
           await _context.SaveChangesAsync();
           return existingInfo;
        }
    }
}