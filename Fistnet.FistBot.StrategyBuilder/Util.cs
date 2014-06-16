using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fistnet.FistBot.BL;
using Fistnet.FistBot.StrategyBuilder.GA;
using Robocode;
using Robocode.Control;
using Robocode.Control.Events;

namespace Fistnet.FistBot.StrategyBuilder
{
    public static class Util
    {
        public const string ROBOCODE_FOLER = "H:\\Robocode";

        public static RobocodeEngine RobotEngine;

        public static void InitEngine(bool visible = false)
        {
            Util.RobotEngine = new RobocodeEngine(ROBOCODE_FOLER);
            // Add battle event handlers
            Util.RobotEngine.BattleCompleted += new BattleCompletedEventHandler(BattleCompleted);
            Util.RobotEngine.BattleError += new BattleErrorEventHandler(BattleError);
            Util.RobotEngine.Visible = visible;
        }

        public static List<string> GetRobots()
        {
            List<string> robotsOut = new List<string>();
            if (Util.RobotEngine == null)
                InitEngine();

            RobotSpecification[] allRobots = Util.RobotEngine.GetLocalRepository();

            foreach (RobotSpecification robot in allRobots)
            {
                robotsOut.Add(robot.Name);
            }

            return robotsOut;
        }

        public static void CloseEngine()
        {
            if (Util.RobotEngine != null)
            {
                Util.RobotEngine.Close();
                Util.RobotEngine = null;
            }
        }

        private static Strategy activeStrategy = null;
        private static string activeDnaBot = null;

        public static void RunBattle(bool showField, RobotSpecification[] selectedRobots, int bfWidth, int bfHeight, int numberOfRounds, Strategy strategy, string dnaBotName)
        {
            if (Util.RobotEngine == null)
                Util.InitEngine();

            File.WriteAllText(FistBot.ROBOT_DATA_FILE, strategy.Strategy);
            Util.activeStrategy = strategy;
            Util.activeDnaBot = dnaBotName;

            BattlefieldSpecification battlefield = new BattlefieldSpecification(bfWidth, bfWidth); // 800x600

            BattleSpecification battleSpec = new BattleSpecification(numberOfRounds, battlefield, selectedRobots);

            Util.RobotEngine.Visible = showField;

            // Run our specified battle and let it run till it is over
            Util.RobotEngine.RunBattle(battleSpec, true /* wait till the battle is over */);
        }

        // Called when the battle is completed successfully with battle results
        private static void BattleCompleted(BattleCompletedEvent e)
        {
            if (Util.activeStrategy == null || Util.activeDnaBot == null)
                return;

            Util.activeStrategy.Fitness = FitnessScore.CalculateFitness(e.IndexedResults.ToList(), Util.activeDnaBot);
            Util.activeStrategy.Save(null);

            //Console.WriteLine("-- Battle has completed --");

            //// Print out the sorted results with the robot names
            //Console.WriteLine("Battle results:");
            //foreach (BattleResults result in e.SortedResults)
            //{
            //    Console.WriteLine("  " + result.TeamLeaderName + ": " + result.Score);
            //}
        }

        // Called when the game sends out an error message during the battle
        private static void BattleError(BattleErrorEvent e)
        {
            Console.WriteLine("Err> " + e.Error);
        }
    }
}