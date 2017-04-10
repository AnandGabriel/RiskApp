using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiskApp
{
    public interface IBetAnalyzer
    {
        List<BetStatistics> AnalyzeBets(List<Bet> bets);
    }
}
