using MedicalTestProject.ApiService.Domain.Entities;

namespace MedicalTestProject.MigrationService.Seeding.Data;

public static class DiseaseSeedData
{
    public static Disease[] GetDiseases(DateTime createdAt)
    {
        return
        [
            new(1,  "Грипп",                   createdAt),
            new(2,  "ОРВИ",                    createdAt),
            new(3,  "Гипертоническая болезнь", createdAt),
            new(4,  "Сахарный диабет 2 типа",  createdAt),
            new(5,  "Бронхиальная астма",      createdAt),
            new(6,  "Пневмония",               createdAt),
            new(7,  "Гастрит",                 createdAt),
            new(8,  "Мигрень",                 createdAt),
            new(9,  "Аллергический ринит",     createdAt),
            new(10, "Остеохондроз",            createdAt),
        ];
    }
}