using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiskApp
{
    class RiskyBetsByTimesAverageBet : IBetRiskIdentifier
    {
        List<Bet> SettledBets;
        List<Bet> UnsettledBets;
        List<BetStatistics> BetStatistics;

        readonly int NumberOfTimesHigherThanAverageBet = 1;

        public RiskyBetsByTimesAverageBet(List<Bet> settledBets, List<Bet> unsettledBets, List<BetStatistics> betStatistics, int numberOfTimesAverageBet)
        {
            SettledBets = settledBets;
            UnsettledBets = unsettledBets;
            BetStatistics = betStatistics;
            NumberOfTimesHigherThanAverageBet = numberOfTimesAverageBet;
        }

        public List<Bet> GetRiskyBets()
        {
            var riskyBetsByTimesHigherThanAverageBet = from bet in UnsettledBets
                                                       join betStatistic in BetStatistics on bet.CustomerID equals betStatistic.CustomerID
                                                 select new Bet(bet.CustomerID, bet.EventID, bet.ParticipantID, bet.Stake, bet.Win, bet.BetType, (bet.Stake >= betStatistic.AverageBet * NumberOfTimesHigherThanAverageBet));

            return riskyBetsByTimesHigherThanAverageBet.Where(x => x.RiskyBet == true).ToList();
        }
    }
}
