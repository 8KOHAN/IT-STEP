namespace IT_STEP
{
    class Program
    {
        static void Main()
        {
            IValidator emailValidator = new EmailValidator();
            IValidator passwordValidator = new PasswordValidator();

            Console.WriteLine(emailValidator.Validate("test@example.com"));
            Console.WriteLine(passwordValidator.Validate("StrongPass123!"));
        }
    }
}
