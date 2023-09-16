namespace UniversityApp.DAL;

public abstract class FileContext
{
    protected readonly string PathToTeachers;
    protected readonly string PathToStudents;

    protected FileContext(string pathToTeachers, string pathToStudents)
    {
        PathToTeachers = pathToTeachers;
        PathToStudents = pathToStudents;
    }
}