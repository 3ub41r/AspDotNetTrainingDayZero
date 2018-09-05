using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AspDotNetTraining.Models;
using Dapper;

namespace AspDotNetTraining.Services
{
    public class StudentService
    {
        public IEnumerable<Student> GetAll()
        {
            using (var c = new ConnectionFactory().GetConnection())
            {
                return c.Query<Student>("SELECT * FROM Student");
            }
        }





        public int Insert(Student student)
        {
            var sql = @"
            INSERT INTO Student (Name, IcNumber, MatricNumber)
            VALUES (@Name, @IcNumber, @MatricNumber)
            ";

            using (var connection = new ConnectionFactory().GetConnection())
            {
                return connection.Execute(sql, student);
            }
        }
    }
}