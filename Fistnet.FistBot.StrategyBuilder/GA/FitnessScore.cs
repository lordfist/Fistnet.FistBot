using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fistnet.FistBot.BL;
using Fistnet.FistBot.Bot;
using Robocode;

namespace Fistnet.FistBot.StrategyBuilder.GA
{
    public static class FitnessScore
    {
        public static void CalculateFitness(List<BattleResults> results, string botName, ref Strategy strategy)
        {
            List<BotStatistics> stats = BotStatistics.DeserializeList(File.ReadAllText(FistBot.ROBOT_STATISTICS_FILE));
            File.WriteAllText(FistBot.ROBOT_STATISTICS_FILE, "");

            // BATTLE FITNESS
            decimal myDamage = 0;
            decimal totalDamage = 1;
            decimal pcDmg = 0;

            decimal myRamDamage = 0;
            decimal totalRamDamage = 1;
            decimal pcRamDmg = 0;

            decimal mySurvivor = 0;
            decimal totalSurvivor = 1;
            decimal pcSurvivor = 0;

            decimal myTotal = 0;
            decimal totalTotal = 1;
            decimal pcTotal = 0;

            decimal winCount = 0;

            foreach (BattleResults result in results)
            {
                totalTotal += result.Score;
                totalRamDamage = totalRamDamage + result.RamDamage + result.RamDamageBonus;
                totalDamage = totalDamage + result.BulletDamage + result.BulletDamageBonus;
                totalSurvivor = totalSurvivor + result.Survival + result.LastSurvivorBonus;

                if (botName == result.TeamLeaderName)
                {
                    winCount = result.Firsts;
                    myRamDamage = result.RamDamage + result.RamDamageBonus;
                    myDamage = result.BulletDamage + result.BulletDamageBonus;
                    myTotal = result.Score;
                    mySurvivor = result.Survival + result.LastSurvivorBonus;
                }
            }

            pcDmg = (myDamage / totalDamage) * (decimal)100;
            pcRamDmg = (myRamDamage / totalRamDamage) * (decimal)100;
            pcSurvivor = (mySurvivor / totalSurvivor) * (decimal)100;
            pcTotal = (myTotal / totalTotal) * (decimal)100;

            decimal battleFitnessScore = pcDmg * (decimal)0.3 + pcRamDmg * (decimal)0.1 + pcTotal * (decimal)0.6;

            // ROBOT FITNESS
            decimal statCount = stats.Count;
            decimal totalBulletsFired = 0;
            decimal totalHits = 0;
            decimal totalMisses = 0;
            decimal totalSelfDamage = 0;
            decimal totalAliveSeconds = 0;

            foreach (var item in stats)
            {
                totalBulletsFired += item.BulletHit + item.BulletMiss;
                totalHits += item.BulletHit;
                totalMisses += item.BulletMiss;
                totalSelfDamage += item.SelfDamage;
                if (item.DeathAfterTicks > -1)
                    totalAliveSeconds += item.DeathAfterTicks;
            }
            if (totalSelfDamage == 0)
                totalSelfDamage = 1;
            if (totalAliveSeconds == 0)
                totalAliveSeconds = -1;
            if (totalBulletsFired == 0)
                totalBulletsFired = 1;

            decimal hitRatio = totalHits / totalBulletsFired * (decimal)100;
            decimal winRatio = winCount / statCount * (decimal)100;
            decimal damageRatio = myDamage / (myDamage + totalSelfDamage) * 100;

            decimal robotFitnessScore = hitRatio * (decimal)0.4 + winRatio * (decimal)0.1 + damageRatio * (decimal)0.5;

            // ABSOLUTE FITNESS
            decimal absoluteFitnes = battleFitnessScore * (decimal)0.6 + robotFitnessScore * (decimal)0.4;

            strategy.Fitness = absoluteFitnes;
            strategy.BulletHit = (int)totalHits;
            strategy.BulletMiss = (int)totalMisses;
            strategy.DeathAfterTicks = (int)(totalAliveSeconds / statCount);
            strategy.MyBulletDamage = (int)myDamage;
            strategy.MyRamDamage = (int)myRamDamage;
            strategy.MyScore = (int)myTotal;
            strategy.MySurvivor = (int)mySurvivor;
            strategy.SelfDamage = (int)totalSelfDamage;
            strategy.TotalBulletDamage = (int)totalDamage;
            strategy.TotalRamDamage = (int)totalRamDamage;
            strategy.TotalScore = (int)totalTotal;
            strategy.TotalSurvivor = (int)totalSurvivor;
            strategy.VictoryCount = (int)winCount;
        }
    }
}