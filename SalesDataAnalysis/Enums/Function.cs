using System.ComponentModel;

namespace SalesDataAnalysis.Enums
{
    /// <summary>
    /// Enum denoting all possible action functions
    /// </summary>
    public enum Function
    {
        [Description("Sum")]
        Sum,

        [Description("Max")]
        Max,

        [Description("Min")]
        Min,

        [Description("Average")]
        Average
    }
}