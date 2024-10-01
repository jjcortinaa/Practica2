namespace Practice1
{
    class PoliceCar : VehicleWithPlate
    {
        //constant string as TypeOfVehicle wont change allong PoliceCar instances
        private const string typeOfVehicle = "Police Car";
        private bool isPatrolling;
        private bool isChasing;
        private SpeedRadar speedRadar;
        private PoliceStation policeStation;
        public PoliceCar(string plate) : base(typeOfVehicle, plate)
        {
            isChasing = false;
            isPatrolling = false;
            speedRadar = new SpeedRadar();
            policeStation = new PoliceStation();

        }

        public void UseRadar(Vehicle vehicle)
        {
            if (isPatrolling)
            {
                speedRadar.TriggerRadar(vehicle);
                string meassurement = speedRadar.GetLastReading();
                Console.WriteLine(WriteMessage($"Triggered radar. Result: {meassurement}"));

                float speed = speedRadar.GetInfractorSpeed();
                float legalSpeed = speedRadar.GetLegalSpeed();
                string plateInfractor = speedRadar.GetInfractorPlate();

                if (speed > legalSpeed)
                {
                    Chase(plateInfractor);
                }
            }
            else
            {
                Console.WriteLine(WriteMessage($"has no active radar."));
            }
        }

        public bool IsPatrolling()
        {
            return isPatrolling;
        }

        public void StartPatrolling()
        {
            if (!isPatrolling)
            {
                isPatrolling = true;
                Console.WriteLine(WriteMessage("started patrolling."));
            }
            else
            {
                Console.WriteLine(WriteMessage("is already patrolling."));
            }
        }

        public void EndPatrolling()
        {
            if (isPatrolling)
            {
                isPatrolling = false;
                Console.WriteLine(WriteMessage("stopped patrolling."));
            }
            else
            {
                Console.WriteLine(WriteMessage("was not patrolling."));
            }
        }

        public void PrintRadarHistory()
        {
            Console.WriteLine(WriteMessage("Report radar speed history:"));
            foreach (float speed in speedRadar.SpeedHistory)
            {
                Console.WriteLine(speed);
            }
        }
        public void NotifyInfractor(PoliceStation policeStation, string plate)
        {
            policeStation.AlertPoliceCars(plate);
        }

        public void Chase(string plateInfractor)
        {
            isChasing = true;
            Console.WriteLine(WriteMessage($"{ToString()} is chasing car with plate {plateInfractor}"));
        }
    }
}