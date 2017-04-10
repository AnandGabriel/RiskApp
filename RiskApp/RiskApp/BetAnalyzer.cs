using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiskApp
{
    class BetAnalyzer : IBetAnalyzer
    {
        private List<Bet> Bets;

        public BetAnalyzer(List<Bet> bets)
        {
            Bets = bets;
        }

        public List<BetStatistics> AnalyzeBets()
        {
            throw new NotImplementedException();
        }
    }
}
