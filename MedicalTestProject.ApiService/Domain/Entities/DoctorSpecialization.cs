namespace MedicalTestProject.ApiService.Domain.Entities;

public class DoctorSpecialization
{
    private DoctorSpecialization() { }
    public int DoctorId { get; private set; }
    public int SpecializationId { get; private set; }
    public Doctor? Doctor { get; private set; }
    public Specialization? Specialization { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public DoctorSpecialization(Doctor doctor, Specialization specialization, DateTime createdAt)
    {
        DoctorId = doctor.Id;
        SpecializationId = specialization.Id;

        Doctor = doctor;
        Specialization = specialization;

        CreatedAt = createdAt;
    }
}
