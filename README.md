# RiskApp
Tech Challenge Application

This solution contains RiskApp project.
 - Bet to hold either settled or unsettled bets
 - BetStatistics to hold by customer Win Percentage, Average Bet
 - FileHandler to read off content from csv files and converts to List of Bet instances
 - BetAnalyzer to calculate Win Percentage, Average Bet etc
 - Class specific to execute the risk calculation type
  - RiskyBetsByHigherWinAmount (Bets with win amount more than 1000)
  - RiskyBetsByTimesAverageBet (Bets with stake more than Average By multiplied by x times). x can be 10 0r 30 passed as constructor parameter.
  - RiskyBetsByUnusualRateCustomer (Bets from customer who has bet stake more than 60% win rate)

 RiskAppTests - Test project
  - It expects the csv files in C:\temp\settled.csv, C:\temp\unsettled.csv
