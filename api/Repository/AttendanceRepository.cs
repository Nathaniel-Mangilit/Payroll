using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interface;
using api.Model;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly ApplicationDBContext _context;
        public AttendanceRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Attendance> CreateAsync(Attendance attendanceModel)
        {
            await _context.Attendances.AddAsync(attendanceModel);
            await _context.SaveChangesAsync();
            return attendanceModel;
        }

        public async Task<Attendance?> DeleteAsync(int id)
        {
           var attendanceModel = _context.Attendances.FirstOrDefault(x => x.Id == id);
           if(attendanceModel == null)
           {
             return null;
           }
           _context.Attendances.Remove(attendanceModel);
           await _context.SaveChangesAsync();
           return attendanceModel;
        }

        public async Task<List<Attendance>> GetAllAsync()
        {
           return await _context.Attendances.ToListAsync();
        }

        public Task<Attendance?> GetByIdAsync(int id)
        {
           return _context.Attendances.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}