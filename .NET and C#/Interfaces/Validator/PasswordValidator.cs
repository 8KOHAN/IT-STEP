namespace IT_STEP
{
    public class PasswordValidator : IValidator
    {
        public bool Validate(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return false;

            bool lengthOk = input.Length >= 6;
            bool hasDigit = input.Any(char.IsDigit);

            return lengthOk && hasDigit;
        }
    }
}
