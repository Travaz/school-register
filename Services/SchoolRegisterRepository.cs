using System.Collections.Generic;
using System.Linq;
using school_register.Data;
using school_register.Model.Entities;

namespace school_register.Services
{
    public interface ISchoolRegisterRepository
    {
        IEnumerable<Student> GetAllStudents();
    }
    public class SchoolRegisterRepository : ISchoolRegisterRepository
    {
        private SchoolRegisterDbContext _context;

        public SchoolRegisterRepository(SchoolRegisterDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _context.Student.ToList();
        }
    }


}