using ListManagement.models;

namespace API.ListManagement.database
{
    static public class FakeDatabase
    {
        public static List<int> Ints = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        public static List<double> Doubles = new List<double> { 3.14, 2.80, 5.5 };

        public static List<Item> Items = new List<Item>
        {
            new Appointment{Name = "Appointment 1", Description="Appointment 1 Desc"},
            new ToDo{Name = "ToDo 1", Description="ToDo 1 Desc", IsCompleted=false}
        };
    }
}
