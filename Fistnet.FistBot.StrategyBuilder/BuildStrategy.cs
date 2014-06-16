using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FistCore.Core;
using FistCore.Core.Common;
using Fistnet.FistBot.Actions;
using Fistnet.FistBot.BL;
using Fistnet.FistBot.Bot;
using Fistnet.FistBot.DAL;
using Fistnet.FistBot.Evaluation;
using Fistnet.FistBot.StrategyBuilder.GA;
using Robocode.Control;

namespace Fistnet.FistBot.StrategyBuilder
{
    public partial class BuildStrategy : Form
    {
        public BuildStrategy()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.uiRandomSS.Text = DnaStrategyUtil.CombineDna(BotDna.CreateRandomDnaStrategy(), BotDna.CreateRandomDnaStrategy());
        }

        private void uiLoadRobots_Click(object sender, EventArgs e)
        {
            List<string> allRobots = Util.GetRobots();

            this.uiRobots.Items.Clear();

            foreach (string robot in allRobots)
            {
                if (robot.Contains("FistBot"))
                    this.uiRobots.Items.Add(robot, true);
                else
                    this.uiRobots.Items.Add(robot);
            }
        }

        private void uiRunBattles_Click(object sender, EventArgs e)
        {
            if (this.uiRobots.CheckedItems.Count == 0)
                return;

            this.currentGeneration = 0;
            this.currentBattle = 0;
            this.shouldStop = false;
            this.uiCancelButton.Enabled = true;
            this.uiRunBattles.Enabled = false;
            this.uiBattleWorker.RunWorkerAsync();
        }

        private void RunSingleBattle(bool showField, RobotSpecification[] selectedRobots)
        {
            DataTable strategyTable = SP.TakeNextStrategy().DataTable;
            if (strategyTable.Rows.Count == 0 || selectedRobots.Length == 0)
                return;

            int selectedStrategy = (int)strategyTable.Rows[0][0];

            Strategy activeStrategy = new Strategy(selectedStrategy);
            activeStrategy.Fetch(null, DataAccessScope.EntityOnly);

            Util.RunBattle(showField, selectedRobots, 800, 600, int.Parse(this.uiRoundsPerBattle.Text), activeStrategy, FistBot.ROBOT_NAME);
        }

        private int currentGeneration = 0;
        private int currentBattle = 0;
        private bool shouldStop = false;

        private void uiBattleWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (this.uiRobots.CheckedItems.Count == 0)
                return;

            int popCount = int.Parse(this.uiPopulationCount.Text);
            int genCount = int.Parse(this.uiGenerationCount.Text);

            int genId = Population.CreateAndActivateNextRandomGeneration(popCount, true);

            string robotsString = "";
            foreach (string robot in this.uiRobots.CheckedItems)
            {
                robotsString += robot + ",";
            }
            robotsString = robotsString.Remove(robotsString.Length - 1, 1);

            RobotSpecification[] selectedRobots = Util.RobotEngine.GetLocalRepository(robotsString);

            for (int generation = 0; generation < genCount; generation++)
            {
                this.currentGeneration = generation;

                for (int i = 0; i < popCount; i++)
                {
                    RunSingleBattle(false, selectedRobots);
                    this.currentBattle = i;
                    this.uiBattleWorker.ReportProgress(generation / genCount);
                    if (this.shouldStop)
                        break;
                }
                genId = Population.CreateAndActivateNextGenerationBasedOn(genId);

                if (this.shouldStop)
                    break;
            }
        }

        private void uiBattleWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.uiGenerationProgress.Value = e.ProgressPercentage;
            this.uiLabelBattle.Text = string.Format("Running battle {0} of {1}. Generation {2}.", this.currentBattle, this.uiPopulationCount.Text, this.currentGeneration);
        }

        private void uiBattleWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.currentGeneration = 0;
            this.currentBattle = 0;
            this.shouldStop = false;
            this.uiRunBattles.Enabled = true;
            this.uiCancelButton.Enabled = false;
        }

        private void uiCancelButton_Click(object sender, EventArgs e)
        {
            this.shouldStop = true;
            this.uiCancelButton.Enabled = false;
            this.uiRunBattles.Enabled = true;
        }
    }
}