using UniversityApp.Models;

namespace UniversityApp.VL;

public static class UniversityView
{
    #region Teachers

    public static void ShowTeacher(Teacher teacher)
    {
        CLI.PrintInfo($"{teacher.Id}: {teacher.FullName}, {teacher.Faculty}, {teacher.Age}, {teacher.Sex}");
    }

    public static void ShowTeachers(List<Teacher> teachers)
    {
        foreach (var teacher in teachers)
        {
            ShowTeacher(teacher);
        }
    }

    #endregion
}