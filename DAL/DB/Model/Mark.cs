namespace UniversityApp.DAL.DB.Model;

public class Mark
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public DateTime Date { get; set; }
    public int Rating { get; set; }
    public int SubjectId { get; set; }
    public int TeacherId { get; set; }
}