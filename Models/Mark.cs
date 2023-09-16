namespace UniversityApp.Models;

public record Mark
{
    public string Id { get; init; }
    public DateTime Date { get; init; }
    public string Subject { get; init; }
    public Teacher Teacher { get; init; }
    public int Rating { get; init; }
}