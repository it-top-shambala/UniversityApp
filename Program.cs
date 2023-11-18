using UniversityApp.BLL;
using UniversityApp.DAL;
using UniversityApp.VL;

//var university = new University(new JsonContext("teachers.json", "students.json"));

var conn = "Server=127.0.0.1;User Id=postgres;Password=1234;Port=5432;Database=university_db;SearchPath=test;";
var university = new University(new DataBaseContext(conn));
var teachers = university.GetAllTeachers();
foreach (var teacher in teachers)
{
    Console.Write($"{teacher.Id}: {teacher.FullName}, {teacher.Age} -> {teacher.Faculty}: ");
    foreach (var subject in teacher.Subjects)
    {
        Console.Write($"{subject}, ");
    }
    Console.WriteLine();
}
