namespace Practice1
{
    internal class PoliceStation
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
            PoliceCars.Add(policeCar);
        }

        public void AlertPoliceCars(string plate)
        {
            detectedInfractor = true;
            foreach (PoliceCar policeCar in PoliceCars)
            {
                policeCar.Chase(plate);
            }
        }
    }
}