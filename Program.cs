using UniversityApp.BLL;
using UniversityApp.DAL;
using UniversityApp.VL;

var university = new University(new JsonContext("teachers.json", "students.json"));

var teachers = university.GetAllTeachers();
UniversityView.ShowTeachers(teachers);

var name = CLI.InputString("Введите имя преподавателя для поиска: ");
var listOfTeachers = university.FindTeachersByName(name);
UniversityView.ShowTeachers(listOfTeachers);

/*
var students = university.GetAllStudents();
foreach (var s in students)
{
    Console.WriteLine($"{s.Id}: {s.FullName}, {s.Faculty}, {s.Age}, {s.Sex}");
    foreach (var m in s.Marks)
    {
        Console.WriteLine($"\t{m.Id} ({m.Date:d}) -> {m.Subject}, {m.Teacher.FullName} -> {m.Rating}");
    }
}
*/
