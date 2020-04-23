using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;



namespace Problem1
{
    class Program
    {
        public abstract class Vehicles
        {
            public float fue;  //油量
            public float fueCon; //油耗
            abstract public void Refuel(float f);
            abstract public void Drive(float s, bool isSummer);
            abstract public void Fue();
        }
        public class Car : Vehicles
        {
            
            string name = "Car";
            public override void Refuel(float f)
            {
                this.fue += f;

            }
         
            public Car(float a,float b)
            {
                this.fue = a;
                this.fueCon = b;
            }
            public override void Drive(float s, bool isSummer)
            {
                float realS = 0;
                int flag = 0;
                if (isSummer)
                {
                    flag = 1;
                    realS = this.fue / (this.fueCon + 0.9f);
                }
                else
                    realS = this.fue / this.fueCon;
                if(realS<s)
                {
                    Console.WriteLine("{0} needs refueling.", this.name);
                }
                else
                {
                    this.fue = this.fue - (s * (this.fueCon + flag * (0.9f)));
                    Console.WriteLine("{0} travelled {1} km.", this.name, s);
                }
            }
            public override void Fue()
            {
                Console.WriteLine("{0} : {1:##.00}", this.name, this.fue);
            }
        }


        public class Truck : Vehicles
        {

            string name = "Truck";
            public override void Refuel(float f)
            {
                this.fue += 0.95f * f;
            }

            public Truck(float a, float b)
            {
                this.fue = a;
                this.fueCon = b;
            }
            public override void Drive(float s, bool isSummer)
            {
                float realS = 0;
                int flag = 0;
                if (isSummer)
                {
                    flag = 1;
                    realS = this.fue / (this.fueCon + 1.6f);
                }
                else
                    realS = this.fue / this.fueCon;
                if (realS < s)
                {
                    Console.WriteLine("{0} needs refueling.", this.name);
                }
                else
                {
                    this.fue = this.fue - (s * (this.fueCon + flag * (0.9f)));
                    Console.WriteLine("{0} travelled {1} km.", this.name, s);
                }
            }
            public override void Fue()
            {
                Console.WriteLine("{0} : {1:##.00}", this.name, this.fue);
            }
        }
        static void Main(string[] args)
        {
            string[] carinfo = Console.ReadLine().Split(' ').ToArray();
            string[] truckinfo = Console.ReadLine().Split(' ').ToArray();
            Car car = new Car(Convert.ToSingle(carinfo[1]), Convert.ToSingle(carinfo[2]));
            Truck truck = new Truck(Convert.ToSingle(truckinfo[1]), Convert.ToSingle(truckinfo[2]));
            int N = int.Parse(Console.ReadLine());
            string totaltext = Console.ReadLine();
            for (int i = 0; i < N - 1; i++) 
            {
                totaltext = totaltext + ";" + Console.ReadLine();
            }
            Console.WriteLine("---------------------");
            for (int i = 0; i < N; i++) 
            {
                string[] text = totaltext.Split(';').ToArray();
                string[] textinfo = text[i].Split(' ').ToArray();
                float data = Convert.ToSingle(textinfo[2]);
                if(textinfo[0] == "Drive")
                {
                    if (textinfo[1] == "Car")
                        car.Drive(data,true);
                    else
                        truck.Drive(data, true);
                }
                else
                {
                    if (textinfo[1] == "Car")
                        car.Refuel(data);
                    else
                        truck.Refuel(data);
                }
                
            }
            car.Fue();
            truck.Fue();
            Console.ReadKey();
        }
    }
}
