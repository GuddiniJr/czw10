using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApplication1.DTOs;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class EnrollDbService : IDbService
    {

        public List<Enrollment> GetEnrollment()
        {
            var dataBase = new s18511Context();
            try
            {

                var enrollments = dataBase.Enrollment.ToList();
                return enrollments;

            }
            catch (SqlException e)
            {
                return null;

            }

        }

        public List<Student> GetStudent()
        {

            s18511Context dataBase = new s18511Context();
            return dataBase.Student.ToList();

        }


        public string ChangeStudent(Student student)
        {

            s18511Context db = new s18511Context();


            try
            {
                Student stul = db.Student.First(s => s.IndexNumber == student.IndexNumber);
                stul.FirstName = student.FirstName;
                stul.LastName = student.LastName;
                stul.BirthDate = student.BirthDate;
                stul.IdEnrollment = student.IdEnrollment;
                stul.Refresh = student.Refresh;
                stul.Password = student.Password;
                stul.Salt = student.Salt;
                stul.IdEnrollmentNavigation = student.IdEnrollmentNavigation;
                db.SaveChanges();
              
                return "Ok";
            }
            catch (InvalidOperationException e)
            {
                return "exception";
            }
            

        }



        public string RemoveStudent(string index)

        {
            s18511Context dataBase = new s18511Context();
            try
            {
                var stDelete = dataBase.Student.FirstOrDefault(s => s.IndexNumber == index);
                if (stDelete == null)
                {
                    return "exception";
                }
                dataBase.Student.Remove(stDelete);
                dataBase.SaveChanges();
            }
            catch (SqlException exc)
            {
                return "exception";
            }
            return "Ok";
        }



        public string EnrollStudent(EnrollStudentRequest req)
        {

            var db = new s18511Context();

            try
            {


                var res = db.Studies.First(s => s.Name == req.Studies).IdStudy;
                var idEnrollment = db.Enrollment.Max(e => e.IdEnrollment) + 1;

                db.Enrollment.Add(new Enrollment
                {
                    IdEnrollment = idEnrollment,
                    Semester = 0,
                    IdStudy = (int)res,
                    StartDate = DateTime.Now

                }); 
              

                db.Student.Add(new Student
                {
                    IndexNumber = req.IndexNumber,
                    FirstName = req.FirstName,
                    LastName = req.LastName,
                    BirthDate = req.BirthDate,
                    IdEnrollment = idEnrollment


                });
                db.SaveChanges();

                return "Ok";
                
            }
            catch(SqlException e)
            {

                return "error";

            }
            catch(InvalidOperationException eo)
            {

                return "error";

            }

        }

        public string PromoteStudents(PromoteStudentRequest req)
        {


            var dataBase = new s18511Context();


            try
            {
                var wrt1 = dataBase.Studies.First(s => s.Name == req.Studies).IdStudy;
                var wrt2 = dataBase.Enrollment.Where(e => e.IdStudy == wrt1)
                    .Where(e => e.Semester == req.Semester);


                if (wrt2.Count() < 1)
                    return "exception";


                foreach(var e in wrt2)
                {

                    e.Semester += 1;

                }


                dataBase.SaveChanges();


                return ("Ok");

            }catch(SqlException e)
            {

                return "exception";

            }catch(InvalidOperationException en)
            {

                return "exception";

            }




        }
    }
}

