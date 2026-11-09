using MedicalTestProject.ApiService.Domain.Entities;

namespace MedicalTestProject.MigrationService.Seeding.Data;

public static class SpecializationSeedData
{
    public static Specialization[] GetSpecializations
        (DateTime createdAt)
    {
        return
        [
            new (1,  "Терапевт",          createdAt),
            new (2,  "Хирург",            createdAt),
            new (3,  "Кардиолог",         createdAt),
            new (4,  "Невролог",          createdAt),
            new (5,  "Педиатр",           createdAt),
            new (6,  "Оториноларинголог", createdAt),
            new (7,  "Офтальмолог",       createdAt),
            new (8,  "Дерматолог",        createdAt),
            new (9,  "Эндокринолог",      createdAt),
            new (10, "Гастроэнтеролог",   createdAt)
        ];
    }

}
