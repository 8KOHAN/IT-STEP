namespace IT_STEP
{
    public class RadioRemoteControl : IRemoteControl
    {
        private int _currentChannel = 0;
        private bool _isOn = false;

        public void TurnOn()
        {
            _isOn = true;
            Console.WriteLine($"The radio is now on. Station number {_currentChannel} is on.");
        }

        public void TurnOff()
        {
            _isOn = false;
            Console.WriteLine("Radio is OFF.");
        }

        public void SetChannel(int channel)
        {
            if (!_isOn)
            {
                Console.WriteLine("Radio is OFF.");
                return;
            }

            _currentChannel = channel;
            Console.WriteLine($"Radio tuned to station {_currentChannel}.");
        }
    }
}
