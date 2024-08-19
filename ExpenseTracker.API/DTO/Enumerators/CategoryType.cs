using System.Runtime.Serialization;

namespace DTO.Enumerators
{

    public enum CategoryType
    {
        [EnumMember(Value = "Expense")]
        Expense,

        [EnumMember(Value = "Income")]
        Income
    }
}