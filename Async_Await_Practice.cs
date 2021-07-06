using System;
using System.Threading;
using System.Threading.Tasks;

namespace PracticeWithC_Sharp {
    class Program {
        static async Task DoLaundry() {
            Console.WriteLine("Starting laundry.");
            await Task.Delay(5000);
            Console.WriteLine("Done with laundry.");
        }
        static void MakeBreakfast() {
            Console.WriteLine("Making breakfast...");
            Thread.Sleep(2000);
            Console.WriteLine("Breakfast made!");
        }
        static void FeedWabbits() {
            Console.WriteLine("Feeding the wabbits...");
            Thread.Sleep(1000);
            Console.WriteLine("Wabbits fed!");
        }
        static void SweepFloor() {
            Console.WriteLine("Sweeping the floor...");
            Thread.Sleep(2000);
            Console.WriteLine("Floor swept!");
        }
        static void TakeOutTrash() {
            Console.WriteLine("Taking the trash out...");
            Thread.Sleep(2000);
            Console.WriteLine("Trash taken out!");
        }
        static void WashDishes() {
            Console.WriteLine("Washing the dishes...");
            Thread.Sleep(2000);
            Console.WriteLine("Dishes washed!");
        }
        static void Main(string[] args) {
            DoLaundry(); // throws warning
            TakeOutTrash();
            SweepFloor();
            FeedWabbits();
            MakeBreakfast();
            WashDishes();
            Console.WriteLine("Press any key to end the program.");
            Console.ReadKey();
        }
    }
}
