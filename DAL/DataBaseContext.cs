using System.Data;
using System.Data.Common;
using Npgsql;
using UniversityApp.Models;

namespace UniversityApp.DAL;

public class DataBaseContext : DbContext, IContext
{
    public List<Teacher> Teachers { get; set; } = new();
    public List<Student> Students { get; set; } = new();
    
    public DataBaseContext(DbConnection dbConnection) : base(dbConnection)
    { }

    public DataBaseContext(string connectionString)
    {
        DbConnection = new NpgsqlConnection(connectionString);
    }

    private void GetTeachers()
    {
        DbConnection.Open();
        const string sql = """
                           SELECT table_teachers.id AS id,
                                  last_name, first_name, patronymic, date_of_birth,
                                  faculty
                           FROM table_teachers
                               JOIN table_persons
                                   ON table_teachers.person_id = table_persons.id
                               JOIN table_faculties
                                   ON table_teachers.faculty_id = table_faculties.id;
                           """;
        var command = new NpgsqlCommand(sql, (NpgsqlConnection?)DbConnection);
        var result = command.ExecuteReader();
        while (result.Read())
        {
            Teachers.Add(new Teacher()
            {
                Id = result.GetInt32("id"),
                LastName = result.GetString("last_name"),
                FirstName = result.GetString("first_name"),
                Patronymic = result.GetString("patronymic"),
                DateOfBirth = result.GetDateTime("date_of_birth"),
                Faculty = result.GetString("faculty"),
                Subjects = new List<string>()
            });
        }
        DbConnection.Close();
    }

    private void TeacherAddSubject()
    {
        foreach (var teacher in Teachers)
        {
            DbConnection.Open();
            var sql1 = $"""
                            SELECT table_subjects.subject AS subject
                            FROM table_teacher_subjects
                                     JOIN table_subjects
                                          ON table_teacher_subjects.subject_id = table_subjects.id
                            WHERE table_teacher_subjects.teacher_id = {teacher.Id};
                        """;
            var command = new NpgsqlCommand(sql1, (NpgsqlConnection?)DbConnection);
            var result = command.ExecuteReader();
            while (result.Read())
            {
                teacher.Subjects.Add(result.GetString("subject"));
            }
            DbConnection.Close();
        }
    }
    
    public void ImportTeachers()
    {
        GetTeachers();
        TeacherAddSubject();
    }

    public void ExportTeachers()
    {
        throw new NotImplementedException();
    }

    public void ImportStudents()
    {
        throw new NotImplementedException();
    }

    public void ExportStudents()
    {
        throw new NotImplementedException();
    }
}