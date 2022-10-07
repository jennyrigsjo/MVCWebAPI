namespace MVCBasics.Models
{
    public static class DoctorModel
    {
        private readonly static double FeverTemp = 37.6;

        private readonly static double HypothermiaTemp = 34.9;


        public static string CheckFever(double temperature)
        {
            string message;

            if (temperature >= FeverTemp)
            {
                message = "You have a fever!";
            }
            else if (temperature <= HypothermiaTemp)
            {
                message = "You have hypothermia!";
            }
            else
            {
                message = "Your body temperature is within normal range.";
            }

            return message;
        }


        public static string GetTemperatureColor(double temperature)
        {
            string color;

            if (temperature >= FeverTemp)
            {
                color = "red";
            }
            else if (temperature <= HypothermiaTemp)
            {
                color = "blue";
            }
            else
            {
                color = "green";
            }

            return color;
        }


        public static double FahrenheitToCelsius(double fahrenheit)
        {
            double celsius = (fahrenheit - 32) * 5 / 9;
            return Math.Round(celsius, 1);
        }
    }
}
