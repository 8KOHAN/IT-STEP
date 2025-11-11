namespace IT_STEP
{
    public class EmailValidator : IValidator
    {
        public bool Validate(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return false;

            return input.Contains("@") && input.Contains(".");
        }
    }
}
