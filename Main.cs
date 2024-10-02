namespace Practice1
{
    internal class Program
    {

        static void Main()
        {
            City city = new City("Madrid");

            PoliceStation policeStation = city.CreatePoliceStation();

            Taxi taxi1 = new Taxi("0001 AAA");
            Taxi taxi2 = new Taxi("0002 BBB");

            Console.WriteLine(taxi1.WriteMessage("Created"));
            Console.WriteLine(taxi2.WriteMessage("Created"));

            city.RegisterLicense(taxi1);
            city.RegisterLicense(taxi2);

            SpeedRadar speedRadar2 = new SpeedRadar();
            SpeedRadar speedRadar3 = new SpeedRadar();

            PoliceCar policeCarWithNoRadar = new PoliceCar("0001 CNP");
            PoliceCar policeCar2 = new PoliceCar("0002 CNP",speedRadar2);
            PoliceCar policeCar3 = new PoliceCar("0003 CNP", speedRadar3);

            Console.WriteLine(policeCarWithNoRadar.WriteMessage("Created"));
            Console.WriteLine(policeCar2.WriteMessage("Created"));
            Console.WriteLine(policeCar3.WriteMessage("Created"));


            policeStation.RegisterPoliceCar(policeCarWithNoRadar);
            policeStation.RegisterPoliceCar(policeCar2);
            policeStation.RegisterPoliceCar(policeCar3);

            policeCarWithNoRadar.StartPatrolling();
            policeCarWithNoRadar.UseRadar(taxi1);

            taxi2.StartRide();

            policeCar2.StartPatrolling();
            policeCar3.StartPatrolling();
            policeCar2.UseRadar(taxi2);
            policeCar2.NotifyInfractor(policeStation, taxi2.GetPlate());

            city.RemoveLicense(taxi2);

        }
    }
}
    

