using System.Collections.Generic;
using System.Linq;
using school_register.Data;
using school_register.Model.Entities;

namespace school_register.Services
{
    public interface ISchoolRegisterRepository
    {
        IEnumerable<Students> GetAllStudents();
    }
    public class SchoolRegisterRepository : ISchoolRegisterRepository
    {
        private SchoolRegisterDbContext _context;

        public SchoolRegisterRepository(SchoolRegisterDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Students> GetAllStudents()
        {
            return _context.Students.ToList();
        }
    }


}