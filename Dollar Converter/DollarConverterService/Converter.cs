namespace DollarConverterService
{
    public class Converter
    {
        private const int Million = 1000000;
        private const int Thousand = 1000;
        private const int Hundred = 100;
        private const int Ten = 10;

        public static string NumberToWord(int number)
        {
            if (number == 0)
                return "zero";

            if (number < 0)
                return "minus " + NumberToWord(number * -1);

            var word = string.Empty;

            var millions = number / Million;
            if (millions > 0)
            {
                word += NumberToWord(millions) + " million ";
                number %= Million;
            }

            var thousands = number / Thousand;
            if (thousands > 0)
            {
                word += NumberToWord(thousands) + " thousand ";
                number %= Thousand;
            }

            var hundreds = number / Hundred;
            if (hundreds > 0)
            {
                word += NumberToWord(hundreds) + " hundred ";
                number %= Hundred;
            }

            if (number > 0)
            {
                var wordArray = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };

                if (number < wordArray.Length)
                {
                    word += wordArray[number];
                }
                else
                {
                    var tens = number / Ten;

                    var tensWordArray = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

                    word += tensWordArray[tens];
                    number %= Ten;

                    if (number > 0)
                        word += "-" + wordArray[number];
                }
            }

            return word.TrimEnd();
        }
    }
}