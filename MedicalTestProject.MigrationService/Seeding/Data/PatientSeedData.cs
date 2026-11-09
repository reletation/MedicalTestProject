using MedicalTestProject.ApiService.Domain.Entities;

namespace MedicalTestProject.MigrationService.Seeding.Data;

public static class PatientSeedData
{
    public static Patient[] GetPatients(DateTime createdAt)
    {
        return
        [
            new (1,  "Анна",     "Сергеевна",    "Смирнова",  new DateTime(1990, 2, 14,  0, 0, 0, DateTimeKind.Utc), createdAt),
            new (2,  "Дмитрий",  "Александрович","Кузнецов",  new DateTime(1985, 7, 8,   0, 0, 0, DateTimeKind.Utc), createdAt),
            new (3,  "Ольга",    "Андреевна",    "Попова",    new DateTime(1992, 11, 3,  0, 0, 0, DateTimeKind.Utc), createdAt),
            new (4,  "Сергей",   "Игоревич",     "Соколов",   new DateTime(1978, 4, 19,  0, 0, 0, DateTimeKind.Utc), createdAt),
            new (5,  "Наталья",  "Павловна",     "Лебедева",  new DateTime(1988, 9, 27,  0, 0, 0, DateTimeKind.Utc), createdAt),
            new (6,  "Алексей",  "Дмитриевич",   "Козлов",    new DateTime(1995, 1, 12,  0, 0, 0, DateTimeKind.Utc), createdAt),
            new (7,  "Ирина",    "Алексеевна",   "Новикова",  new DateTime(1983, 6, 5,   0, 0, 0, DateTimeKind.Utc), createdAt),
            new (8,  "Михаил",   "Михайлович",   "Морозов",   new DateTime(1975, 12, 21, 0, 0, 0, DateTimeKind.Utc), createdAt),
            new (9,  "Юлия",     "Владимировна", "Волкова",   new DateTime(1991, 8, 16,  0, 0, 0, DateTimeKind.Utc), createdAt),
            new (10, "Николай",  "Николаевич",   "Зайцев",    new DateTime(1987, 3, 9,   0, 0, 0, DateTimeKind.Utc), createdAt)
        ];
    }
}