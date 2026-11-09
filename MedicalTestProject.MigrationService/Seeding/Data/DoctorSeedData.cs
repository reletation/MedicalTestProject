using MedicalTestProject.ApiService.Domain.Entities;

namespace MedicalTestProject.MigrationService.Seeding.Data;

public static class DoctorSeedData
{
    public static Doctor[] GetDoctors(DateTime createdAt)
    {
        return
        [
            new Doctor(1,  "Иван",    "Иванович",   "Иванов",     new DateTime(1980, 1, 15,  0, 0, 0, DateTimeKind.Utc), createdAt),
            new Doctor(2,  "Пётр",    "Петрович",   "Петров",     new DateTime(1975, 5, 20,  0, 0, 0, DateTimeKind.Utc), createdAt),
            new Doctor(3,  "Сергей",  "Сергеевич",  "Сергеев",    new DateTime(1985, 8, 3,   0, 0, 0, DateTimeKind.Utc), createdAt),
            new Doctor(4,  "Алексей", "Алексеевич", "Алексеев",   new DateTime(1978, 11, 12, 0, 0, 0, DateTimeKind.Utc), createdAt),
            new Doctor(5,  "Дмитрий", "Дмитриевич", "Дмитриев",   new DateTime(1990, 3, 7,   0, 0, 0, DateTimeKind.Utc), createdAt),
            new Doctor(6,  "Андрей",  "Андреевич",  "Андреев",    new DateTime(1982, 7, 25,  0, 0, 0, DateTimeKind.Utc), createdAt),
            new Doctor(7,  "Михаил",  "Михайлович", "Михайлов",   new DateTime(1970, 2, 18,  0, 0, 0, DateTimeKind.Utc), createdAt),
            new Doctor(8,  "Николай", "Николаевич", "Николаев",   new DateTime(1993, 9, 30,  0, 0, 0, DateTimeKind.Utc), createdAt),
            new Doctor(9,  "Владимир","Владимирович","Владимиров",new DateTime(1988, 6, 11,  0, 0, 0, DateTimeKind.Utc), createdAt),
            new Doctor(10, "Павел",   "Павлович",   "Павлов",     new DateTime(1983, 4, 22,  0, 0, 0, DateTimeKind.Utc), createdAt)
        ];
    }
}