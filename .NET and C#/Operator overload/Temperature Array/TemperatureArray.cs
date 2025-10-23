public class TemperatureArray
{
    public double Monday { get; set; }
    public double Tuesday { get; set; }
    public double Wednesday { get; set; }
    public double Thursday { get; set; }
    public double Friday { get; set; }
    public double Saturday { get; set; }
    public double Sunday { get; set; }

    public double this[int index]
    {
        get
        {
            switch (index)
            {
                case 0: return Monday;
                case 1: return Tuesday;
                case 2: return Wednesday;
                case 3: return Thursday;
                case 4: return Friday;
                case 5: return Saturday;
                case 6: return Sunday;
                default:
                    throw new IndexOutOfRangeException("Index must be between 0 (Monday) and 6 (Sunday).");
            }
        }
        set
        {
            switch (index)
            {
                case 0: Monday = value; break;
                case 1: Tuesday = value; break;
                case 2: Wednesday = value; break;
                case 3: Thursday = value; break;
                case 4: Friday = value; break;
                case 5: Saturday = value; break;
                case 6: Sunday = value; break;
                default:
                    throw new IndexOutOfRangeException("Index must be between 0 (Monday) and 6 (Sunday).");
            }
        }
    }

    public double GetAverageTemperature()
    {
        double sum = Monday + Tuesday + Wednesday + Thursday + Friday + Saturday + Sunday;
        return sum / 7.0;
    }
}
