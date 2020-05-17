using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DTOs;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IDbService
    {

        public List<Student> GetStudent();

        public string ChangeStudent(Student student);

        public string RemoveStudent(string index);

        public string EnrollStudent(EnrollStudentRequest req);
        public List<Enrollment> GetEnrollment();

        public string PromoteStudents(PromoteStudentRequest req);


    }
}
