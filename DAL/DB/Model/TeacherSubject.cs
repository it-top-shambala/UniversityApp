﻿namespace UniversityApp.DAL.DB.Model;

public class TeacherSubject
{
    public int Id { get; set; }
    public int TeacherId { get; set; }
    public int SubjectId { get; set; }
}