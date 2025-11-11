namespace IT_STEP
{
    class Program
    {
        static void Main()
        {
            IRemoteControl tv = new TvRemoteControl();
            IRemoteControl radio = new RadioRemoteControl();

            tv.TurnOn();
            tv.SetChannel(667);

            radio.TurnOn();
            radio.SetChannel(993);
        }
    }
}
