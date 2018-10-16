using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_lab_5
{
    public static class Printer
    {
        public static void iAmPrinting(Vehicle obj)
        {
            Console.WriteLine($"Это {obj.GetType()}");
        }
    }


    public abstract class Vehicle
    {
        protected bool isStarted;
        public virtual void Move()
        {
            Console.WriteLine("ЧТо та двигается!");
        }
    }

    class Car : Vehicle, Engine
    {
        public bool startEngine()
        {
            this.isStarted = true;
            return true;
        }

        public bool stopEngine()
        {
            this.isStarted = false;
            return false;
        }
        public override void Move()
        {
            Console.WriteLine("Тачка едет");
        }
        
    }

    class Train : Vehicle, Engine
    {
        public bool startEngine()
        {
            this.isStarted = true;
            return true;
        }

        public bool stopEngine()
        {
            this.isStarted = false;
            return false;
        }
  
        public override void Move()
        {
            Console.WriteLine("Поезд едет");
        }
        
    }

    interface Engine
    {
        bool startEngine();
        bool stopEngine();
    }

    sealed class Express : Train
    {
        public override void Move()
        {
            Console.WriteLine("Экспресс-поезд едет");
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            Vehicle a = obj as Express;
            if (a as Express == null)
            {
                return false;
            }
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    sealed class Carriage : Train
    {
        public void itsVagon()
        {
            Console.WriteLine("Это вагон");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Vehicle Train_1 = new Train();

            if (Train_1 is Car)
            {
                Console.WriteLine("Что-то не так");
            }
            else
            {
                Console.WriteLine("Train is not a Car");
            }

            Printer.iAmPrinting(Train_1);
        }
    }
}
