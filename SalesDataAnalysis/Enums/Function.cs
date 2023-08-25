using System.ComponentModel;

namespace SalesDataAnalysis.Enums
{
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