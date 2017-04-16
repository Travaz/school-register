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

            Rooms DuecentoTre = new Rooms();
            Rooms DuecentoCinque = new Rooms();
            Rooms DuecentoOtto = new Rooms();
            Rooms TrecentoQuattro = new Rooms();

            Classes QuintaBI = new Classes();
            Classes QuartaAM = new Classes();
            Classes QuintaAM = new Classes();
            Classes TerzaCC = new Classes();

            Students Mario = new Students();
            Students Daniel = new Students();

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

            if(!_context.Rooms.Any()) 
            {
                DuecentoTre = new Rooms()
                {
                    IdRoom = 1,
                    NumeroAula = "203",
                    Floor = 2,
                    Lim = true,
                };

                DuecentoCinque = new Rooms()
                {
                    IdRoom = 1,
                    NumeroAula = "205",
                    Floor = 2,
                    Lim = false,
                };

                DuecentoOtto = new Rooms()
                {
                    IdRoom = 1,
                    NumeroAula = "208",
                    Floor = 2,
                    Lim = true,
                };

                TrecentoQuattro = new Rooms()
                {
                    IdRoom = 1,
                    NumeroAula = "304",
                    Floor = 3,
                    Lim = false,
                };
            }

            if(!_context.Classes.Any())
            {
                QuintaBI = new Classes()
                {
                    Name = "5BI",
                    Branch = ComputerScience,
                    Room = DuecentoTre
                };

                QuartaAM = new Classes()
                {
                    Name = "4AM",
                    Branch = Mechanics,
                    Room = DuecentoCinque,
                };
            
                QuintaAM = new Classes()
                {
                    Name = "5AM",
                    Branch = Mechanics,
                    Room = DuecentoOtto
                };

                TerzaCC = new Classes()
                {
                    Name = "3CC",
                    Branch = Chemistry,
                    Room = TrecentoQuattro
                };
            }

            /* Check if there aren't any students in the DB */
            if (!_context.Students.Any())
            {
                Daniel = new Students()
                {
                    FiscalCode = "TRVDNL98L30H330A",
                    Name = "Daniel",
                    Surname = "Travaglia",
                    Birthday = DateTime.UtcNow,
                    Email = "travaglia.daniel4@gmail.com",
                    Class = QuintaBI
                };

                Mario = new Students()
                {
                    FiscalCode = "RVNMRO89H04M220F",
                    Name = "Mario",
                    Surname = "Ravanelli",
                    Birthday = DateTime.UtcNow,
                    Email = "ravanelli.mario@gmail.com",
                    Class = QuintaAM
                };

                _context.Branch.Add(ComputerScience);
                _context.Branch.Add(Mechanics);
                _context.Branch.Add(Chemistry);

                _context.Rooms.Add(DuecentoTre);
                _context.Rooms.Add(DuecentoCinque);
                _context.Rooms.Add(DuecentoOtto);
                _context.Rooms.Add(TrecentoQuattro);

                _context.Classes.Add(TerzaCC);
                _context.Classes.Add(QuartaAM);
                _context.Classes.Add(QuintaAM);
                _context.Classes.Add(QuintaBI);

                _context.Students.Add(Daniel);
                _context.Students.Add(Mario);

                /* Save seeding data async*/
                await _context.SaveChangesAsync();

            }
        }
    }
}