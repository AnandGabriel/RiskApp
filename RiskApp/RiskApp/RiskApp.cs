using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiskApp
{
    class RiskApp
    {
        IFileHandler FileHandler;
        IBetAnalyzer BetAnalyzer;

        const int UnUsualRateCutOffPercentage = 60;

        public RiskApp(IFileHandler fileHandler, IBetAnalyzer betAnalyzer)
        {
            FileHandler = fileHandler;
        }

        public List<BetStatistics> GetCustomersWithUnUsualRate()
        {
            //Get the bets from the file
            List<Bet> bets = FileHandler.GetBets();

            //Analyze the bets
            List<BetStatistics> betStatistics = BetAnalyzer.AnalyzeBets();

            //Get the unusual rate bets
            List<BetStatistics> betsUnusal = betStatistics.Where(x => x.WinPercentage > UnUsualRateCutOffPercentage).ToList();

            return betsUnusal;
        }
    }
}
