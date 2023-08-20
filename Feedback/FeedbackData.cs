using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feedback
{
    public class FeedbackData
    {
        [LoadColumn(0)]
        public string Data;

        [LoadColumn(1), ColumnName("Label")]
        public bool Lable;
    }
}
