namespace UniversityApp.DAL.DB.Model;

public class Teacher
{
    public int Id { get; set; }
    public int PersonId { get; set; }
    public int FacultyId { get; set; }
    public bool IsActive { get; set; }
}