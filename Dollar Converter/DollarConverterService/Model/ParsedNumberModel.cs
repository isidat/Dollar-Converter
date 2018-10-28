namespace DollarConverterService.Model
{
    public class ParsedNumberModel
    {
        public int Dollars { get; set; }
        public int Cents { get; set; }

        public override string ToString()
        {
            var dollars = Converter.NumberToWord(this.Dollars);

            var word = dollars + " dollar";

            if (this.Dollars != 1)
                word += "s";

            if (this.Cents > 0)
            {
                word += " and " + Converter.NumberToWord(this.Cents) + " cent";

                if (this.Cents != 1)
                    word += "s";
            }

            return word;
        }
    }
}