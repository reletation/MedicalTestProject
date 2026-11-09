namespace MedicalTestProject.ApiService.Domain.Entities;

public class PatientDisease
{
    private PatientDisease() { }
    public int PatientId { get; private set; }
    public int DiseaseId { get; private set; }

    public Patient? Patient { get; private set; }
    public Disease? Disease { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public PatientDisease(Patient patient, Disease disease, DateTime createdAt)
    {
        PatientId = patient.Id;
        DiseaseId = disease.Id;

        Patient = patient;
        Disease = disease;

        CreatedAt = createdAt;
    }
}
