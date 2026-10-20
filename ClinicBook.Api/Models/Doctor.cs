namespace ClinicBook.Api.Models;

public class Doctor
{
    public int Id { get; set; }
    public string FullName { get; set; } = "";
    public string Specialty { get; set; } = "";
    public string Email { get; set; } = "";
    public int YearsOfExperience { get; set; }
}