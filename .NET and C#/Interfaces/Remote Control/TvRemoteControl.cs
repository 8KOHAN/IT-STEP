namespace IT_STEP
{
    public class TvRemoteControl : IRemoteControl
    {
        private int _currentChannel;
        private bool _isOn;

        public void TurnOn()
        {
            _isOn = true;
            Console.WriteLine($"TV is ON. Сhannel number {_currentChannel} is on");
        }

        public void TurnOff()
        {
            _isOn = false;
            Console.WriteLine("TV is OFF.");
        }

        public void SetChannel(int channel)
        {
            if (!_isOn)
            {
                Console.WriteLine("TV is OFF.");
                return;
            }

            _currentChannel = channel;
            Console.WriteLine($"TV channel set to {_currentChannel}.");
        }
    }
}
