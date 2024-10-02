namespace Practice1
{
    class PoliceStation: IMessageWritter
    {
        public List<PoliceCar> PoliceCars { get; private set; }
        private bool detectedInfractor;
        public PoliceStation()
        {
            detectedInfractor = false;
            PoliceCars = new List<PoliceCar>();
        }

        public void RegisterPoliceCar(PoliceCar policeCar)
        {
            Console.WriteLine(WriteMessage($"Has registered {policeCar.ToString()}"));
            PoliceCars.Add(policeCar);
        }

        public void AlertPoliceCars(PoliceCar policeWhichAlerted, string plate)
        {
            detectedInfractor = true;
            foreach (PoliceCar policeCar in PoliceCars)
            {
                if (policeCar.IsPatrolling() == true && policeCar!=policeWhichAlerted)
                {
                    policeCar.Chase(plate);
                }
               
            }
        }
        public virtual string WriteMessage(string message)
        {
            return $"Police station {message}";
        }
    }
}