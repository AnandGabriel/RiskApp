using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiskApp
{
    class RiskyBetsByHigherWinAmount : IBetRiskIdentifier
    {
        List<Bet> SettledBets;
        List<Bet> UnsettledBets;
        List<BetStatistics> BetStatistics;

        const int HigherAmountMargin = 1000;

        public RiskyBetsByHigherWinAmount(List<Bet> settledBets, List<Bet> unsettledBets, List<BetStatistics> betStatistics)
        {
            SettledBets = settledBets;
            UnsettledBets = unsettledBets;
            BetStatistics = betStatistics;
        }

        public List<Bet> GetRiskyBets()
        {
            var riskyBetsByTimesHigherThanAverageBet = from bet in UnsettledBets
                                                       join betStatistic in BetStatistics on bet.CustomerID equals betStatistic.CustomerID
                                                       select new Bet(bet.CustomerID, bet.EventID, bet.ParticipantID, bet.Stake, bet.Win, bet.BetType, bet.Win >= HigherAmountMargin);

            return riskyBetsByTimesHigherThanAverageBet.Where(x => x.RiskyBet == true).ToList();
        }
    }
}
