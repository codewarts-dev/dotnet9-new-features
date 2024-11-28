namespace Net9NewFeatures.AggregateBy;

public class AggregateByExample
{
    public static void RunTest()
    {
        Console.WriteLine("=== .NET 8 AggregateBy Örneği Çalıştırılıyor ===");
        CalculateAverageWithNet8();

        Console.WriteLine("=== .NET 9 AggregateBy Örneği Çalıştırılıyor ===");
        CalculateAverageWithNet9();
    }

    private static void CalculateAverageWithNet8()
    {
        var students = CreateStudents();

        var averageGradesByClass = students
            .GroupBy(s => s.Class)
            .Select(group => new
            {
                Class = group.Key,
                AverageGrade = group.Average(s => s.Grade)
            });

        foreach (var result in averageGradesByClass)
        {
            Console.WriteLine($"Sınıf: {result.Class}, Ortalama Not: {result.AverageGrade:F2}");
        }
    }

    private static void CalculateAverageWithNet9()
    {
        var students = CreateStudents();

        var averageGradesByClass = students.AggregateBy(keySelector: s => s.Class,
                                                        seedSelector: _ => (Sum: 0, Count: 0),
                                                        func: (acc, student) => (acc.Sum + student.Grade, acc.Count + 1))
                                            .Select(kvp => new
                                            {
                                                Class = kvp.Key,
                                                AverageGrade = kvp.Value.Sum / (double)kvp.Value.Count
                                            });

        foreach (var result in averageGradesByClass)
        {
            Console.WriteLine($"Sınıf: {result.Class}, Ortalama Not: {result.AverageGrade:F2}");
        }
    }

    private static List<Student> CreateStudents()
    {
        return
        [
            new(Name: "Ahmet", Class: "10A", Grade: 85),
            new(Name: "Ayşe", Class: "10A", Grade: 90),
            new(Name: "Mehmet", Class: "10B", Grade: 78),
            new(Name: "Fatma", Class: "10B", Grade: 82)
        ];
    }

    record Student(string Name, string Class, int Grade);
}