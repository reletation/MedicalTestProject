using MedicalTestProject.ApiService.Domain.Entities;

namespace MedicalTestProject.MigrationService.Seeding.Data;

public static class PatientDiseaseSeedData
{
    public static PatientDisease[] GetPatientDiseases
        (Dictionary<int, Patient> patient, Dictionary<int, Disease> disease, DateTime createdAt)
    {
        return
        [
            new(patient[1],  disease[1],  createdAt),
            new(patient[1],  disease[7],  createdAt),
            new(patient[2],  disease[3],  createdAt),
            new(patient[2],  disease[10], createdAt),
            new(patient[3],  disease[2],  createdAt),
            new(patient[3],  disease[5],  createdAt),
            new(patient[4],  disease[4],  createdAt),
            new(patient[4],  disease[8],  createdAt),
            new(patient[5],  disease[1],  createdAt),
            new(patient[5],  disease[6],  createdAt),
            new(patient[6],  disease[9],  createdAt),
            new(patient[6],  disease[10], createdAt),
            new(patient[7],  disease[2],  createdAt),
            new(patient[7],  disease[5],  createdAt),
            new(patient[8],  disease[3],  createdAt),
            new(patient[8],  disease[7],  createdAt),
            new(patient[9],  disease[1],  createdAt),
            new(patient[9],  disease[4],  createdAt),
            new(patient[10], disease[6],  createdAt),
            new(patient[10], disease[8],  createdAt)
        ];
    }
}
