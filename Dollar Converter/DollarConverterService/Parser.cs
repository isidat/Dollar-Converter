using System.ServiceModel;
using System.Text.RegularExpressions;

using DollarConverterService.Model;

namespace DollarConverterService
{
    public class Parser
    {
        public static ParsedNumberModel Parse(string number)
        {
            // Clear all whitespaces (for thousand seperators)
            number = Regex.Replace(number, @"\s+", "");

            var regex = new Regex(@"(\d+)(,\d{1,2})?");

            var match = regex.Match(number);
            if (!match.Success)
                throw new FaultException("Please enter a valid number (Eg: 99 999,99)");

            var parsedModel = new ParsedNumberModel
            {
                Dollars = int.Parse(match.Groups[1].Value)
            };

            if (match.Groups[2].Success)
            {
                var cents = match.Groups[2].Value.TrimStart(',');

                // If cents section has only one digit it means ten times that digit (Eg: ,5 means ,50 cents)
                if (cents.Length == 1)
                    cents += "0";

                parsedModel.Cents = int.Parse(cents);
            }

            return parsedModel;
        }
    }
}