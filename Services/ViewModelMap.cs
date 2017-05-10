using System;
using school_register.Model.Entities;
using school_register.ViewModels;

namespace school_register.Services
{
    public interface IViewModelMap
    {
         Branch GetBranch(BranchViewModel branchVM);
         Class GetClass(ClassViewModel classVM);
         Student GetStudent(StudentsViewModel studentVM);
         Room GetRoom(RoomViewModel roomVM);

         BranchViewModel GetBranchVM(Branch branch);
         ClassViewModel GetClassVM(Class _class);
         StudentsViewModel GetStudentVM(Student student);
         RoomViewModel GetRoomVM(Room room);
    }

    public class ViewModelMap : IViewModelMap
    {
        public Branch GetBranch(BranchViewModel branchVM)
            => 
                new Branch
                {
                    ID = branchVM.ID,
                    Name = branchVM.Name,
                    Description = branchVM.Description,
                    StartDate = branchVM.StartDate,
                    Icon = "default.png"
                };

        public Class GetClass(ClassViewModel classVM)
            => 
                new Class
                {
                    ID = classVM.ID,
                    Name = classVM.Name,
                    FkBranch = classVM.FkBranch,
                    FkRoom = classVM.FkRoom
                };

        public Room GetRoom(RoomViewModel roomVM)
            => 
                new Room
                {
                    ID = roomVM.ID,
                    NumeroAula = roomVM.NumeroAula,
                    Floor = roomVM.Floor,
                    Lim = roomVM.Lim
                };

        public Student GetStudent(StudentsViewModel studentVM)
            => 
                new Student
                {
                    ID = studentVM.ID,
                    Name = studentVM.Name,
                    Surname = studentVM.Surname,
                    Birthday = studentVM.Birthday,
                    Gender = studentVM.Gender,
                    Age = studentVM.Age,
                    Email = studentVM.Email,
                    FiscalCode = studentVM.FiscalCode,
                    FkClass = studentVM.FkClass
                };
        
        public StudentsViewModel GetStudentVM(Student student)
            =>
                new StudentsViewModel
                {
                    ID = student.ID,
                    Name = student.Name,
                    Surname = student.Surname,
                    Birthday = student.Birthday,
                    Gender = student.Gender,
                    Age = student.Age,
                    Email = student.Email,
                    FiscalCode = student.FiscalCode,
                    FkClass = student.FkClass
                };
        
        public ClassViewModel GetClassVM(Class _class)
            =>
                new ClassViewModel
                {
                    ID = _class.ID,
                    Name = _class.Name,
                    FkBranch = _class.FkBranch,
                    FkRoom = _class.FkRoom
                };

        public RoomViewModel GetRoomVM(Room room)
            =>
                new RoomViewModel
                {
                    ID = room.ID,
                    NumeroAula = room.NumeroAula,
                    Floor = room.Floor,
                    Lim = room.Lim
                };

        public BranchViewModel GetBranchVM(Branch branch)
            =>
                new BranchViewModel
                {
                    ID = branch.ID,
                    Name = branch.Name,
                    Description = branch.Description,
                    StartDate = branch.StartDate,
                    Icon = "default.png"
                };
    }
}