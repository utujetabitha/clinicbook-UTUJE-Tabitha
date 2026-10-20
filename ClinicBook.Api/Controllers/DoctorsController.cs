using ClinicBook.Api.Dtos;
using ClinicBook.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClinicBook.Api.Controllers;

[ApiController]
[Route("api/doctors")]
public class DoctorsController : ControllerBase
{
    private static readonly List<Doctor> _doctors = new()
    {
        new() { Id = 1, FullName = "Dr. Aline Uwase", Specialty = "Pediatrics",
                Email = "aline.uwase@clinicbook.test", YearsOfExperience = 8 },
        new() { Id = 2, FullName = "Dr. Jean Habimana", Specialty = "Cardiology",
                Email = "jean.habimana@clinicbook.test", YearsOfExperience = 12 }
    };
    private static int _nextId = 3;

    [HttpGet]
    public ActionResult<IEnumerable<DoctorResponse>> GetAll() =>
        Ok(_doctors.Select(ToResponse));

    [HttpGet("{id:int}")]
    public ActionResult<DoctorResponse> GetById(int id)
    {
        var d = _doctors.FirstOrDefault(x => x.Id == id);
        return d is null ? NotFound() : Ok(ToResponse(d));
    }

    [HttpPost]
    public ActionResult<DoctorResponse> Create(CreateDoctorRequest req)
    {
        var d = new Doctor
        {
            Id = _nextId++,
            FullName = req.FullName,
            Specialty = req.Specialty,
            Email = req.Email,
            YearsOfExperience = req.YearsOfExperience
        };
        _doctors.Add(d);
        return CreatedAtAction(nameof(GetById), new { id = d.Id }, ToResponse(d));
    }

    [HttpPut("{id:int}")]
    public IActionResult Update(int id, UpdateDoctorRequest req)
    {
        var d = _doctors.FirstOrDefault(x => x.Id == id);
        if (d is null) return NotFound();

        d.FullName = req.FullName;
        d.Specialty = req.Specialty;
        d.Email = req.Email;
        d.YearsOfExperience = req.YearsOfExperience;
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        var d = _doctors.FirstOrDefault(x => x.Id == id);
        if (d is null) return NotFound();
        _doctors.Remove(d);
        return NoContent();
    }

    private static DoctorResponse ToResponse(Doctor d) =>
        new(d.Id, d.FullName, d.Specialty, d.Email, d.YearsOfExperience);
}