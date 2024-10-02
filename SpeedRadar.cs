﻿namespace Practice1
{
    class SpeedRadar : IMessageWritter
    {
        //Radar doesn't know about Vechicles, just speed and plates
        private string plate;
        private float speed;
        private float legalSpeed = 50.0f;
        public List<float> SpeedHistory { get; private set; }

        public SpeedRadar()
        {
            plate = "";
            speed = 0f;
            SpeedHistory = new List<float>();
        }

        public void TriggerRadar(Vehicle vehicle)
        {
            if (vehicle is VehicleWithPlate vehicleWithPlate)
            {
                plate = vehicleWithPlate.GetPlate();
                speed = vehicleWithPlate.GetSpeed();
                SpeedHistory.Add(speed);
            }
            
        }

        public string GetLastReading()
        {
            if (speed > legalSpeed)
            {
                return WriteMessage("Catched above legal speed.");
            }
            else
            {
                return WriteMessage("Driving legally.");
            }
        }
        public float GetInfractorSpeed()
        {
            return speed;
        }

        public float GetLegalSpeed()
        {
            return legalSpeed;
        }

        public string GetInfractorPlate()
        {
            return plate;
        }
        public virtual string WriteMessage(string radarReading)
        {
            return $"Vehicle with plate {plate} at {speed.ToString()} km/h. {radarReading}";
        }
    }
}