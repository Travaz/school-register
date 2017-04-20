using System;
using System.Linq;
using System.Threading.Tasks;
using school_register.Data;
using school_register.Model.Entities;

namespace school_register.Services
{
    public class SchoolRegisterDbContextSeeding
    {
        private SchoolRegisterDbContext _context;

        public SchoolRegisterDbContextSeeding(SchoolRegisterDbContext context)
        {
            _context = context;
        }

        public async Task EnsureSeedData()
        {
            /* Branches */
                Branch ComputerScience = new Branch()
                {
                    Name = "Computer Science",
                    StartDate = DateTime.UtcNow,
                    Description = "That's the computer science course. " +
                                        "By the end of the course, you'll be able to build and deploy from simple " +
                                        "to tricky Web Applications, Desktop Apps and Mobile Games",
                };
                Branch Chemistry = new Branch()
                {
                    Name = "Chemistry",
                    StartDate = DateTime.UtcNow,
                    Description = "Bla bla bla",
                };
                Branch Mechanics = new Branch()
                {
                    Name = "Mechanics",
                    StartDate = DateTime.UtcNow,
                    Description = "Bla bla bla",
                };

            /*Rooms*/
                Room DuecentoTre = new Room()
                {
                    NumeroAula = 203,
                    Floor = 2,
                    Lim = true,
                };
                Room DuecentoCinque = new Room()
                {
                    NumeroAula = 205,
                    Floor = 2,
                    Lim = false,
                };
                Room DuecentoOtto = new Room()
                {
                    NumeroAula = 208,
                    Floor = 2,
                    Lim = true,
                };
                Room TrecentoQuattro = new Room()
                {
                    NumeroAula = 304,
                    Floor = 3,
                    Lim = false,
                };

            /*Classes*/
                Class QuintaBI = new Class()
                {
                    Name = "5BI",
                    FkBranchNavigation = ComputerScience,
                    FkRoomNavigation = DuecentoTre
                };
                Class QuartaAM = new Class()
                {
                    Name = "4AM",
                    FkBranchNavigation = Mechanics,
                    FkRoomNavigation = DuecentoCinque,
                };
                Class QuintaAM = new Class()
                {
                    Name = "5AM",
                    FkBranchNavigation = Mechanics,
                    FkRoomNavigation = DuecentoOtto
                };
                Class TerzaCC = new Class()
                {
                    Name = "3CC",
                    FkBranchNavigation = Chemistry,
                    FkRoomNavigation = TrecentoQuattro
                };

            /* Students */
                Student Mario = new Student()
                {
                    FiscalCode = "RVNMRO89H04M220F",
                    Name = "Mario",
                    Surname = "Ravanelli",
                    Birthday = DateTime.UtcNow,
                    Email = "ravanelli.mario@gmail.com",
                    FkClassNavigation = QuintaAM
                };
                Student Daniel = new Student()
                {
                    FiscalCode = "TRVDNL98L30H330A",
                    Name = "Daniel",
                    Surname = "Travaglia",
                    Birthday = DateTime.Parse("1998/12"),
                    Email = "travaglia.daniel4@gmail.com",
                    FkClassNavigation = QuintaBI
                };

            if (!_context.Branch.Any())
            {
                _context.Branch.Add(ComputerScience);
                _context.Branch.Add(Mechanics);
                _context.Branch.Add(Chemistry);
            }

            if(!_context.Room.Any()) 
            {
                _context.Room.Add(DuecentoTre);
                _context.Room.Add(DuecentoCinque);
                _context.Room.Add(DuecentoOtto);
                _context.Room.Add(TrecentoQuattro);
            }

            if(!_context.Class.Any())
            {
                _context.Class.Add(TerzaCC);
                _context.Class.Add(QuartaAM);
                _context.Class.Add(QuintaAM);
                _context.Class.Add(QuintaBI);
            }

            if (!_context.Student.Any())
            {
                _context.Student.Add(Daniel);
                _context.Student.Add(Mario);
            }

            /* Save seeding data async*/
            await _context.SaveChangesAsync();      
        }
    }
}