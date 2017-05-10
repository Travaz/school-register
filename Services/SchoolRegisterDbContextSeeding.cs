using System;
using System.Linq;
using System.Threading.Tasks;
using school_register.Data;
using school_register.Models;
using System.Collections.Generic;

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
                    ID = 1,
                    Name = "Computer Science",
                    StartDate = DateTime.Parse("1988/09/12"),
                    Description = "That's the computer science course. " +
                                        "By the end of the course, you'll be able to build and deploy from simple " +
                                        "to tricky Web Applications, Desktop Apps and Mobile Games",
                    Icon = "computer science.png"
                };
                Branch Chemistry = new Branch()
                {
                    ID = 2,
                    Name = "Chemistry",
                    StartDate = DateTime.Parse("2005/09/15"),
                    Description = "Bla bla bla",
                    Icon = "chemistry.png"
                };
                Branch Mechanics = new Branch()
                {
                    ID = 3,
                    Name = "Mechanics",
                    StartDate = DateTime.Parse("1999/09/05"),
                    Description = "Bla bla bla",
                    Icon = "mechanics.png"
                };

            /*Rooms*/
                Room DuecentoTre = new Room()
                {
                    ID = 1,
                    NumeroAula = 203,
                    Floor = 2,
                    Lim = true,
                };
                Room DuecentoCinque = new Room()
                {
                    ID = 2,
                    NumeroAula = 205,
                    Floor = 2,
                    Lim = false,
                };
                Room DuecentoOtto = new Room()
                {
                    ID = 3,
                    NumeroAula = 208,
                    Floor = 2,
                    Lim = true,
                };
                Room TrecentoQuattro = new Room()
                {
                    ID = 4,
                    NumeroAula = 304,
                    Floor = 3,
                    Lim = false,
                };

            /*Classes*/
                Class QuintaBI = new Class()
                {
                    ID = 1,
                    Name = "5BI",
                    FkBranch = 1,
                    FkRoom = 1
                };
                Class QuartaAM = new Class()
                {
                    ID = 2,
                    Name = "4AM",
                    FkBranch = 3,
                    FkRoom = 2,
                };
                Class QuintaAM = new Class()
                {
                    ID = 3,
                    Name = "5AM",
                    FkBranch = 3,
                    FkRoom = 3,
                };
                Class TerzaCC = new Class()
                {
                    ID = 4,
                    Name = "3CC",
                    FkBranch = 2,
                    FkRoom = 4,
                };

            /* Students */
                Student Mario = new Student()
                {
                    FiscalCode = "RVNMRO89H04M220F",
                    Gender = Gender.Male,
                    Name = "Mario",
                    Surname = "Ravanelli",                   
                    Birthday = DateTime.Parse("1996/01/30"),
                    Email = "mario.ravanelli@marconirovereto.it",
                    FkClass = 3
                };
                Student Aurora = new Student()
                {
                    FiscalCode = "BNDAUR00M08G508D",
                    Gender = Gender.Female,
                    Name = "Aurora",
                    Surname = "Benedetti",
                    Birthday = DateTime.Parse("2000/04/08"),
                    Email = "aurora.benedetti@marconirovereto.it",
                    FkClass = 4
                };
                Student Chiara = new Student()
                {
                    FiscalCode = "PISCAR00M14T714A",
                    Gender = Gender.Female,
                    Name = "Chiara",
                    Surname = "Pisoni",
                    Birthday = DateTime.Parse("2000/08/14"),
                    Email = "chiara.pisoni@marconirovereto.it",
                    FkClass = 4
                };
                Student Daniel = new Student()
                {
                    FiscalCode = "TRVDNL98L30H330A",
                    Gender = Gender.Male,
                    Name = "Daniel",
                    Surname = "Travaglia",
                    Birthday = DateTime.Parse("1998/07/30"),
                    Email = "daniel.travaglia@marconirovereto.it",
                    FkClass = 1
                };
                Student Manuele = new Student()
                {
                    FiscalCode = "MSTMNL99L25H325X",
                    Gender = Gender.Male,
                    Name = "Manuele",
                    Surname = "Maistri",
                    Birthday = DateTime.Parse("1999/12/25"),
                    Email = "manuele.maistri@marconirovereto.it",
                    FkClass = 2
                };
                Student Sara = new Student()
                {
                    FiscalCode = "DBRSAR00J03M103F",
                    Gender = Gender.Female,
                    Name = "Sara",
                    Surname = "De Baroni",
                    Birthday = DateTime.Parse("1998/10/03"),
                    Email = "sara.debaroni@marconirovereto.it",
                    FkClass = 4
                };


            if (!_context.Branch.Any())
            {
                await _context.Branch.AddRangeAsync(ComputerScience, Mechanics, Chemistry);
            }

            if(!_context.Room.Any()) 
            {
                await _context.Room.AddRangeAsync(DuecentoTre, DuecentoCinque, DuecentoOtto, TrecentoQuattro);
            }

            if(!_context.Class.Any())
            {
                await _context.Class.AddRangeAsync(TerzaCC, QuartaAM, QuintaAM, QuintaBI);
            }

            if (!_context.Student.Any())
            {
                await _context.Student.AddRangeAsync(Mario, Aurora, Chiara, Daniel, Manuele, Sara);
            }

            /* Save seeding data async*/
            await _context.SaveChangesAsync();      
        }
    }
}