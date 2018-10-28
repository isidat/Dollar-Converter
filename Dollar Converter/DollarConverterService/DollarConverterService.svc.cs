namespace DollarConverterService
{
    public class DollarConverterService : IDollarConverterService
    {
        public string ConvertNumberToWord(string number)
        {
            return Parser.Parse(number).ToString();
        }
    }
}
