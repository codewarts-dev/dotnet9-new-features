namespace Net9NewFeatures.SemiAutoProperties;

public class SemiAutoPropertiesExample
{
    class PersonNet9
    {
        public int Age
        {
            get => field; // Backing field doğrudan kullanılıyor
            set
            {
                if (value >= 0) // Negatif yaş değerine izin verilmez
                    field = value;
                else
                    Console.WriteLine("Yaş negatif olamaz!");
            }
        }

        public required string Name
        {
            get => field; // Backing field doğrudan kullanılıyor
            set => field = value.Trim(); // İsim boşluklardan temizleniyor
        }
    }

    class PersonNet8
    {
        private int _age;
        private string _name = null!;

        public int Age
        {
            get => _age;
            set
            {
                if (value >= 0) // Negatif yaş değerine izin verilmez
                    _age = value;
                else
                    Console.WriteLine("Yaş negatif olamaz!");
            }
        }

        public string Name
        {
            get => _name;
            set => _name = value.Trim(); // İsim boşluklardan temizleniyor
        }
    }


    public static void RunTest()
    {
        Console.WriteLine("=== .NET 8 Backing Field Örneği Çalıştırılıyor ===");
        PersonNet8 personNet8 = new()
        {
            // Name özelliği
            Name = "  Ahmet Yılmaz  "
        };
        Console.WriteLine($"İsim: '{personNet8.Name}'"); // Çıktı: 'Ahmet Yılmaz'

        // Age özelliği
        personNet8.Age = 25; // Geçerli
        Console.WriteLine($"Yaş: {personNet8.Age}"); // Çıktı: 25

        personNet8.Age = -5; // Geçersiz, hata mesajı verir
        Console.WriteLine($"Yaş: {personNet8.Age}"); // Çıktı: 25 (değer değişmedi)


        Console.WriteLine("=== .NET 9 Semi Auto Properties Örneği Çalıştırılıyor ===");
        PersonNet9 personNet9 = new()
        {
            // Name özelliği
            Name = "  Ahmet Yılmaz  "
        };
        Console.WriteLine($"İsim: '{personNet9.Name}'"); // Çıktı: 'Ahmet Yılmaz'

        // Age özelliği
        personNet9.Age = 25; // Geçerli
        Console.WriteLine($"Yaş: {personNet9.Age}"); // Çıktı: 25

        personNet9.Age = -5; // Geçersiz, hata mesajı verir
        Console.WriteLine($"Yaş: {personNet9.Age}"); // Çıktı: 25 (değer değişmedi)
    }
}