using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiskApp
{
    class RiskyBetsByUnusualRateCustomer : IBetRiskIdentifier
    {
        List<Bet> SettledBets;
        List<Bet> UnsettledBets;
        List<BetStatistics> BetStatistics;

        const int UnUsualRateCutOffPercentage = 60;

        public RiskyBetsByUnusualRateCustomer(List<Bet> settledBets, List<Bet> unsettledBets, List<BetStatistics> betStatistics)
        {
            SettledBets = settledBets;
            UnsettledBets = unsettledBets;
            BetStatistics = betStatistics;
        }

        public List<Bet> GetRiskyBets()
        {
            //Get the unusual rate bets
            List<BetStatistics> betsUnusualByCustomer = BetStatistics.Where(x => x.WinPercentage > UnUsualRateCutOffPercentage).ToList();

            bool riskyBet = true;
            var riskyBetsByUnusualRateCustomer = from bet in UnsettledBets
                                                 join unusualRate in betsUnusualByCustomer on bet.CustomerID equals unusualRate.CustomerID
                                select new Bet(bet.CustomerID, bet.EventID, bet.ParticipantID, bet.Stake, bet.Win, bet.BetType, riskyBet);

            return riskyBetsByUnusualRateCustomer.ToList();
        }
    }
}
