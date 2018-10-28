using System.ServiceModel;

namespace DollarConverterService
{
    [ServiceContract]
    public interface IDollarConverterService
    {

        [OperationContract]
        string ConvertNumberToWord(string number);
    }
}
