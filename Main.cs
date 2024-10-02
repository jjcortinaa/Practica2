namespace Practice1
{
    internal class Program
    {

        static void Main()
        {
            SpeedRadar speedRadarp1 = new SpeedRadar();
            SpeedRadar speedRadarp2 = new SpeedRadar();
            Taxi taxip1 = new Taxi("0001 AAA");
            Taxi taxip2 = new Taxi("0002 BBB");
            PoliceCar policeCarp1 = new PoliceCar("0001 CNP", speedRadarp1);
            PoliceCar policeCarp2 = new PoliceCar("0002 CNP", speedRadarp2);

            Console.WriteLine(taxip1.WriteMessage("Created"));
            Console.WriteLine(taxip2.WriteMessage("Created"));
            Console.WriteLine(policeCarp1.WriteMessage("Created"));
            Console.WriteLine(policeCarp2.WriteMessage("Created"));

            policeCarp1.StartPatrolling();
            policeCarp1.UseRadar(taxip1);

            taxip2.StartRide();
            policeCarp2.UseRadar(taxip2);
            policeCarp2.StartPatrolling();
            policeCarp2.UseRadar(taxip2);
            taxip2.StopRide();
            policeCarp2.EndPatrolling();

            taxip1.StartRide();
            taxip1.StartRide();
            policeCarp1.StartPatrolling();
            policeCarp1.UseRadar(taxip1);
            taxip1.StopRide();
            taxip1.StopRide();
            policeCarp1.EndPatrolling();

            policeCarp1.PrintRadarHistory();
            policeCarp2.PrintRadarHistory();


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
    

