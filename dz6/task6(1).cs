using System;
namespace AdapterExample
{
    // Система яку будемо адаптовувати
    class OldElectricitySystem
    {
        public string MatchThinSocket()
        {
            return "old system";
        }
    }

    class AnotherOldElectricitySystem
    {
        public string MatchTriangleSocket()
        {
            return "another old system";
        }
    }


    // Широковикористовуваний інтерфейс нової системи (специфікація до квартири)
    interface INewElectricitySystem
    {
        string MatchWideSocket();
    }

    // Ну і власне сама розетка у новій квартирі
    class NewElectricitySystem : INewElectricitySystem
    {
        public string MatchWideSocket()
        {
            return "new interface";
        }
    }

    // Адаптер назовні виглядає як нові євророзетки, шляхом наслідування прийнятного у 
    // системі інтерфейсу
    class Adapter : INewElectricitySystem
    {
        // Але всередині він старий
        private readonly OldElectricitySystem _adaptee;
        private readonly AnotherOldElectricitySystem _another_adaptee;
        public Adapter(OldElectricitySystem adaptee)
        {
            _adaptee = adaptee;
        }
        public Adapter(AnotherOldElectricitySystem adaptee)
        {
            _another_adaptee = adaptee;
        }

        // А тут відбувається вся магія: наш адаптер «перекладає»
        // функціональність із нового стандарту на старий
        public string MatchWideSocket()
        {
            // Якщо б була різниця 
            // то тут ми б помістили трансформатор
            if (_adaptee != null) { 
                return _adaptee.MatchThinSocket(); 
            }
            else
            { 
                return _another_adaptee.MatchTriangleSocket(); 
            }

        }
    }

    class ElectricityConsumer
    {
        // Зарядний пристрій, який розуміє тільки нову систему
        public static void ChargeNotebook(INewElectricitySystem electricitySystem)
        {
            Console.WriteLine(electricitySystem.MatchWideSocket());
        }
    }


    public class AdapterDemo
    {
        static void Main()
        {
            // 1) Ми можемо користуватися новою системою без проблем
            var newElectricitySystem = new NewElectricitySystem();
            ElectricityConsumer.ChargeNotebook(newElectricitySystem);

            // 2) Ми повинні адаптуватися до старої системи, використовуючи адаптер
            var oldElectricitySystem = new OldElectricitySystem();
            var adapter = new Adapter(oldElectricitySystem);
            ElectricityConsumer.ChargeNotebook(adapter);

            // 3) Ми повинні адаптуватися до іншої старої системи, використовуючи інший адаптер
            var anotherOldElectricitySystem = new AnotherOldElectricitySystem();
            var anotherAdapter = new Adapter(anotherOldElectricitySystem);
            ElectricityConsumer.ChargeNotebook(anotherAdapter);

            Console.ReadKey();
        }
    }
}