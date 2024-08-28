using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace DTO.Enumerators
{
    [JsonConverter(typeof(JsonStringEnumConverter))]     
    public enum TransactionCategory
    {
        [EnumMember(Value = "Expense")]
        Expense,

        [EnumMember(Value = "Income")]
        Income
    }
}