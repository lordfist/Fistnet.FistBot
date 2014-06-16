using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Robocode;

namespace Fistnet.FistBot.StrategyBuilder.GA
{
    public static class FitnessScore
    {
        public static decimal CalculateFitness(List<BattleResults> results, string botName)
        {
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

            foreach (BattleResults result in results)
            {
                totalTotal += result.Score;
                totalRamDamage = totalRamDamage + result.RamDamage + result.RamDamageBonus;
                totalDamage = totalDamage + result.BulletDamage + result.BulletDamageBonus;
                totalSurvivor = totalSurvivor + result.Survival + result.LastSurvivorBonus;

                if (botName == result.TeamLeaderName)
                {
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

            return pcDmg * (decimal)0.6 + pcRamDmg * (decimal)0.05 + pcSurvivor * (decimal)0.2 + pcTotal * (decimal)0.15;
        }
    }
}