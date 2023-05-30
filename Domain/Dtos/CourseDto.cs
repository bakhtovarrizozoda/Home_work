namespace Domain.Dtos;

public class CourseDto
{
    public int Id { get; set; }
    public string? CourseName { get; set; }
    public string? Coursedescription { get; set; }
    public decimal Fee { get; set; }
    public int Duration { get; set; }
    public DateTime Startdate { get; set; }
    public DateTime Enddate { get; set; }
    public int Studentlimit { get; set; }
}
