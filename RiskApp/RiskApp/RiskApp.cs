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
        IBetRiskIdentifier RiskyBetsByUnusualRateCustomer;
        IBetRiskIdentifier RiskyBetsByTenTimesAverageBet;
        IBetRiskIdentifier RiskyBetsByThirtyTimesAverageBet;
        IBetRiskIdentifier RiskyBetsByHigherWinAmount;
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

        public List<Bet> GetTotalRiskyBets()
        {
            //Get the bets from the file
            List<Bet> unsettledBets = FileHandlerUnSettled.GetBets();

            //Get the bets from the file
            List<Bet> settledBets = FileHandlerSettled.GetBets();

            //Analyze the bets
            List<BetStatistics> betStatistics = BetAnalyzer.AnalyzeBets(settledBets);

            RiskyBetsByUnusualRateCustomer = new RiskyBetsByUnusualRateCustomer(settledBets, unsettledBets, betStatistics);
            RiskyBetsByTenTimesAverageBet = new RiskyBetsByTimesAverageBet(settledBets, unsettledBets, betStatistics, 10);
            RiskyBetsByThirtyTimesAverageBet = new RiskyBetsByTimesAverageBet(settledBets, unsettledBets, betStatistics, 30);
            RiskyBetsByHigherWinAmount = new RiskyBetsByHigherWinAmount(settledBets, unsettledBets, betStatistics);

            List<Bet> riskyBets = RiskyBetsByUnusualRateCustomer.GetRiskyBets();
            List<Bet> riskyBetsByTenTimesAverageBet = RiskyBetsByTenTimesAverageBet.GetRiskyBets();
            List<Bet> riskyBetsByThirtyTimesAverageBet = RiskyBetsByThirtyTimesAverageBet.GetRiskyBets();
            List<Bet> riskyBetsByHigherWinAmount= RiskyBetsByHigherWinAmount.GetRiskyBets();

            riskyBets.AddRange(riskyBetsByTenTimesAverageBet);
            riskyBets.AddRange(riskyBetsByThirtyTimesAverageBet);
            riskyBets.AddRange(riskyBetsByHigherWinAmount);

            return riskyBets.ToList();
        }

        public List<Bet> GetRiskyBetsByUnusualRateCustomer()
        {
            //Get the bets from the file
            List<Bet> unsettledBets = FileHandlerUnSettled.GetBets();

            //Get the bets from the file
            List<Bet> settledBets = FileHandlerSettled.GetBets();

            //Analyze the bets
            List<BetStatistics> betStatistics = BetAnalyzer.AnalyzeBets(settledBets);

            RiskyBetsByUnusualRateCustomer = new RiskyBetsByUnusualRateCustomer(settledBets, unsettledBets, betStatistics);

            List<Bet> riskyBets = RiskyBetsByUnusualRateCustomer.GetRiskyBets();

            return riskyBets.ToList();
        }

        public List<Bet> GetRiskyBetsByTenTimesMoreThanAverage()
        {
            //Get the bets from the file
            List<Bet> unsettledBets = FileHandlerUnSettled.GetBets();

            //Get the bets from the file
            List<Bet> settledBets = FileHandlerSettled.GetBets();

            //Analyze the bets
            List<BetStatistics> betStatistics = BetAnalyzer.AnalyzeBets(settledBets);

            RiskyBetsByTenTimesAverageBet = new RiskyBetsByTimesAverageBet(settledBets, unsettledBets, betStatistics, 10);

            List<Bet> riskyBets = RiskyBetsByTenTimesAverageBet.GetRiskyBets();

            return riskyBets.ToList();
        }

        public List<Bet> GetRiskyBetsByThirtyTimesMoreThanAverage()
        {
            //Get the bets from the file
            List<Bet> unsettledBets = FileHandlerUnSettled.GetBets();

            //Get the bets from the file
            List<Bet> settledBets = FileHandlerSettled.GetBets();

            //Analyze the bets
            List<BetStatistics> betStatistics = BetAnalyzer.AnalyzeBets(settledBets);

            RiskyBetsByThirtyTimesAverageBet = new RiskyBetsByTimesAverageBet(settledBets, unsettledBets, betStatistics, 30);

            List<Bet> riskyBets = RiskyBetsByThirtyTimesAverageBet.GetRiskyBets();

            return riskyBets.ToList();
        }

        public List<Bet> GetRiskyBetsByHigherWinAmount()
        {
            //Get the bets from the file
            List<Bet> unsettledBets = FileHandlerUnSettled.GetBets();

            //Get the bets from the file
            List<Bet> settledBets = FileHandlerSettled.GetBets();

            //Analyze the bets
            List<BetStatistics> betStatistics = BetAnalyzer.AnalyzeBets(settledBets);

            RiskyBetsByHigherWinAmount = new RiskyBetsByHigherWinAmount(settledBets, unsettledBets, betStatistics);

            List<Bet> riskyBets = RiskyBetsByHigherWinAmount.GetRiskyBets();

            return riskyBets.ToList();
        }
    }
}
