namespace MVCBasics.Models
{
    public static class GuessNumberModel
    {

        public static int GenerateSecretNumber()
        {
            Random random = new();
            int secretNumber = random.Next(1, 101);
            return secretNumber;
        }

        public static string CompareNumbers(int guess, int number)
        {
            string result;

            if (guess > number)
            {
                result = $"{guess} is too high.";
            }
            else if (guess < number)
            {
                result = $"{guess} is too low.";
            }
            else
            {
                result = $"{guess} is correct!";
            }

            return result;
        }
    }
}
