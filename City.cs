namespace Practice1
{
    class City: IMessageWritter
    {
        private PoliceStation policeStation;
        private string cityname;
        public List<Taxi> Taxis { get; private set; }
        public City(string cityname)
        {
            Taxis = new List<Taxi>();
            this.cityname = cityname;
        }

        public void RegisterLicense(Taxi taxi)
        {
            Console.WriteLine(WriteMessage($"Has registered the license of {taxi.ToString()}"));
            Taxis.Add(taxi);
        }

        public PoliceStation CreatePoliceStation()
        {
            Console.WriteLine(WriteMessage("Has created a Police Station"));
            PoliceStation policeStation = new PoliceStation();
            return policeStation;
        }
        public void RemoveLicense(Taxi taxi)
        {
            Console.WriteLine(WriteMessage($"Has removed the license of {taxi.ToString()}"));
            Taxis.Remove(taxi);
        }
        public virtual string WriteMessage(string message)
        {
            return $"{cityname}: {message}";
        }
    }
}