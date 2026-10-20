using System.ComponentModel.DataAnnotations;

namespace ClinicBook.Api.Dtos;

public class CreateDoctorRequest
{
    [Required, StringLength(100, MinimumLength = 3)]
    public string FullName { get; set; } = "";

    [Required, StringLength(50, MinimumLength = 2)]
    public string Specialty { get; set; } = "";

    [Required, EmailAddress, StringLength(100)]
    public string Email { get; set; } = "";

    [Range(0, 60)]
    public int YearsOfExperience { get; set; }
}

public class UpdateDoctorRequest : CreateDoctorRequest { }

public record DoctorResponse(int Id, string FullName, string Specialty,
                             string Email, int YearsOfExperience);