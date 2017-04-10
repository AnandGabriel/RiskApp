using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiskApp
{
    interface IBetAnalyzer
    {
        List<BetStatistics> AnalyzeBets();
    }
}
