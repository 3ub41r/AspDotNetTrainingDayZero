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
        public void Delete(int id)
        {
            var sql = "DELETE FROM Student WHERE Id = @Id";

            using (var connection = new ConnectionFactory().GetConnection())
            {
                connection.Execute(sql, new { Id = id });
            }
        }


        public void Update(Student student)
        {
            var sql = @"
            UPDATE Student 
            SET Name = @Name,
            IcNumber = @IcNumber,
            MatricNumber = @MatricNumber
            WHERE Id = @Id";

            using (var connection = new ConnectionFactory().GetConnection())
            {
                connection.Execute(sql, student);
            }
        }








        public Student Find(int id)
        {
            var sql = @"SELECT * FROM Student WHERE Id = @Id";

            using (var c = new ConnectionFactory().GetConnection())
            {
                return c.QueryFirstOrDefault<Student>(sql, new { Id = id });
            }
        }



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