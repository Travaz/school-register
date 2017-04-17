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
            Branch ComputerScience = new Branch();
            Branch Chemistry = new Branch();
            Branch Mechanics = new Branch();

            Room DuecentoTre = new Room();
            Room DuecentoCinque = new Room();
            Room DuecentoOtto = new Room();
            Room TrecentoQuattro = new Room();

            Class QuintaBI = new Class();
            Class QuartaAM = new Class();
            Class QuintaAM = new Class();
            Class TerzaCC = new Class();

            Student Mario = new Student();
            Student Daniel = new Student();

            if(!_context.Branch.Any())
            {
                ComputerScience = new Branch() 
                {
                    Name = "Computer Science",
                    IdBranch = 1,
                    StartDate = DateTime.UtcNow,
                    Description = "That's the computer science course. " +
                                    "By the end of the course, you'll be able to build and deploy from simple " +
                                    "to tricky Web Applications, Desktop Apps and Mobile Games",
                };

                Chemistry = new Branch() 
                {
                    Name = "Chemistry",
                    IdBranch = 2,
                    StartDate = DateTime.UtcNow,
                    Description = "Bla bla bla",
                };

                Mechanics = new Branch() 
                {
                    Name = "Mechanics",
                    IdBranch = 3,
                    StartDate = DateTime.UtcNow,
                    Description = "Bla bla bla",
                };
            }

            if(!_context.Room.Any()) 
            {
                DuecentoTre = new Room()
                {
                    IdRoom = 1,
                    NumeroAula = 203,
                    Floor = 2,
                    Lim = true,
                };

                DuecentoCinque = new Room()
                {
                    IdRoom = 1,
                    NumeroAula = 205,
                    Floor = 2,
                    Lim = false,
                };

                DuecentoOtto = new Room()
                {
                    IdRoom = 1,
                    NumeroAula = 208,
                    Floor = 2,
                    Lim = true,
                };

                TrecentoQuattro = new Room()
                {
                    IdRoom = 1,
                    NumeroAula = 304,
                    Floor = 3,
                    Lim = false,
                };
            }

            if(!_context.Class.Any())
            {
                QuintaBI = new Class()
                {
                    Name = "5BI",
                    FkBranchNavigation = ComputerScience,
                    FkRoomNavigation = DuecentoTre
                };

                QuartaAM = new Class()
                {
                    Name = "4AM",
                    FkBranchNavigation = Mechanics,
                    FkRoomNavigation = DuecentoCinque,
                };
            
                QuintaAM = new Class()
                {
                    Name = "5AM",
                    FkBranchNavigation = Mechanics,
                    FkRoomNavigation = DuecentoOtto
                };

                TerzaCC = new Class()
                {
                    Name = "3CC",
                    FkBranchNavigation = Chemistry,
                    FkRoomNavigation = TrecentoQuattro
                };
            }

            /* Check if there aren't any Student in the DB */
            if (!_context.Student.Any())
            {
                Daniel = new Student()
                {
                    FiscalCode = "TRVDNL98L30H330A",
                    Name = "Daniel",
                    Surname = "Travaglia",
                    Birthday = DateTime.UtcNow,
                    Email = "travaglia.daniel4@gmail.com",
                    FkClassNavigation = QuintaBI
                };

                Mario = new Student()
                {
                    FiscalCode = "RVNMRO89H04M220F",
                    Name = "Mario",
                    Surname = "Ravanelli",
                    Birthday = DateTime.UtcNow,
                    Email = "ravanelli.mario@gmail.com",
                    FkClassNavigation = QuintaAM
                };

                _context.Branch.Add(ComputerScience);
                _context.Branch.Add(Mechanics);
                _context.Branch.Add(Chemistry);

                _context.Room.Add(DuecentoTre);
                _context.Room.Add(DuecentoCinque);
                _context.Room.Add(DuecentoOtto);
                _context.Room.Add(TrecentoQuattro);

                _context.Class.Add(TerzaCC);
                _context.Class.Add(QuartaAM);
                _context.Class.Add(QuintaAM);
                _context.Class.Add(QuintaBI);

                _context.Student.Add(Daniel);
                _context.Student.Add(Mario);

                /* Save seeding data async*/
                await _context.SaveChangesAsync();

            }
        }
    }
}