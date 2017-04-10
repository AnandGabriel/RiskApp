using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiskApp
{
    public class RiskApp
    {
        IFileHandler FileHandlerSettled;
        IFileHandler FileHandlerUnSettled;
        IBetAnalyzer BetAnalyzer;

        const int UnUsualRateCutOffPercentage = 60;

        public RiskApp(IFileHandler fileHandlerSettled, IFileHandler fileHandlerUnSettled, IBetAnalyzer betAnalyzer)
        {
            FileHandlerSettled = fileHandlerSettled;
            FileHandlerUnSettled = fileHandlerUnSettled;
            BetAnalyzer = betAnalyzer;
        }

        public List<BetStatistics> GetCustomersWithUnUsualRate()
        {
            //Get the bets from the file
            List<Bet> bets = FileHandlerSettled.GetBets();

            //Analyze the bets
            List<BetStatistics> betStatistics = BetAnalyzer.AnalyzeBets(bets);

            //Get the unusual rate bets
            List<BetStatistics> betsUnusal = betStatistics.Where(x => x.WinPercentage > UnUsualRateCutOffPercentage).ToList();

            return betsUnusal;
        }

        public List<Bet> GetBetsFromRiskyCustomers()
        {
            //Get the bets from the file
            List<Bet> bets = FileHandlerUnSettled.GetBets();

            //Get the unusual rate from settled bets
            List<BetStatistics> betsUnusalRate = GetCustomersWithUnUsualRate();

            bool riskyBet = true;
            var markBetsRisky = from bet in bets
                                join unusualRate in betsUnusalRate on bet.CustomerID equals unusualRate.CustomerID
                                select new Bet(bet.CustomerID, bet.EventID, bet.ParticipantID, bet.Stake, bet.Win, bet.BetType, riskyBet);

            return markBetsRisky.ToList();
        }
    }
}
