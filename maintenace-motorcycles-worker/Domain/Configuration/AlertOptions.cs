namespace Domain.Configuration
{
    public sealed class AlertOptions
    {
        public int FirstAlert { get; set; }
        public int SecondAlert { get; set; }
        public int ThirdAlert { get; set; }
        public List<int> Alerts { get; private set; } = new List<int>();

        public List<int> CreateAlerts()
        {
            Alerts.Add(FirstAlert);
            Alerts.Add(SecondAlert);
            Alerts.Add(ThirdAlert);

            return Alerts;
        }
    }
}
