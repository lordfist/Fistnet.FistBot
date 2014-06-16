using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fistnet.FistBot.Bot;
using Robocode;
using Robocode.RobotInterfaces;

namespace Fistnet.FistBot
{
    public class FistBot : BotBase
    {
        public const string ROBOT_DATA_FILE = "H:\\Robocode\\robots\\.data\\Fistnet\\FistBot\\active.txt";

        public const string ROBOT_NAME = "Fistnet.FistBot.FistBot";
        private static string fileData = "";

        public override void Run()
        {
            // fileData = "0=2,10?55;-|3,2?39;7|1,13?-|3,26?36;34|3,17?42;18|3,11?3;17|1,26?33;-|3,16?37;6|2,18?52;-|1,1?12;-|3,9?6;47|1,25?2;-|1,14?49;-|1,14?1;-|0,25?1;-|3,18?47;48<>1=2,15?19;-|0,24?0;-|0,3?32;-|1,5?19;-|2,11?10;-|0,19?1;-|3,13?40;13|1,11?11;-|3,9?31;25|1,0?47;-|0,15?20;-|2,12?13;-|3,26?3;7|0,3?24;-|0,27?23;-|2,1?19;-<>2=1,6?43;-|0,6?25;-|0,0?11;-|3,14?43;55|3,28?20;51|1,10?18;-|0,25?5;-|2,10?36;-|0,10?30;-|0,9?5;-|2,1?28;-|3,6?13;9|2,16?24;-|1,27?54;-|3,22?25;32|3,13?33;14<>3=2,20?11;-|1,3?21;-|3,0?27;50|3,20?39;30|1,22?-|3,12?28|3,21?2;30|3,17?37;3|2,13?19;-|2,17?29;-|0,28?28;-|1,9?47;-|0,20?25;-|3,22?22;51|0,11?49;-|2,21?12;-<>4=1,4?30;-|1,22?53;-|3,4?28;9|3,5?14;42|1,6?42;-|0,17?39;-|3,5?39;37|1,9?25;-|1,23?12;-|1,15?1;-|2,22?25;-|3,23?21;25|2,8?9;-|2,20?9;-|2,28?46;-|3,20?43<>5=3,20?19;8|1,6?52;-|0,1?11;-|3,23?39;51|3,0?55;27|3,17?29;1|2,8?11;-|1,7?27;-|3,17?2;I9|1,10?9;-|2,3?26;-|2,0?10;-|1,3?5;-|1,8?45;-|0,0?45;-|1,7?36;-<>6=1,11?0;-|1,0?19;-|2,10?53;-|0,9?3;-|1,6?4;-|3,25?46;35|3,2?52;21|0,8?19;-|0,17?6;-|0,20?40;-|0,5?34;-|0,21?50;-|0,5?56;-|2,5?45;-|1,7?33;-|3,11?3;55<>7=0,18?25;-|3,28?35;I0|2,8?26;-|1,4?20;-|0,0?15;-|1,3?-|2,22?18;-|0,20?8;-|3,8?10;37|1,23?5;-|1,13?29;-|3,8?47;46|3,17?43;18|0,2?15;-|1,28?7;-|0,16?49;-";

            if (string.IsNullOrWhiteSpace(fileData))
            {
                using (StreamReader rdr = new StreamReader(this.GetDataFile("active.txt")))
                {
                    fileData = rdr.ReadToEnd();
                }
            }

            if (this.Evaluations == null)
                this.DeserializeStrategies(fileData);

            Ahead(2);

            while (!this.IsDead)
            {
                RunStrategies();
            }
        }

        #region Strategy controller.

        private StrategyEnum activeStrategy;
        private StrategyEnum requestedStrategy;
        private bool interrupt;
        private byte nextActionIndex;
        private byte prevActionIndex;

        public override void Init(Dictionary<StrategyEnum, List<Evaluation.EvaluationBase>> strategies)
        {
            base.Init(strategies);

            this.activeStrategy = StrategyEnum.Default;
            this.requestedStrategy = StrategyEnum.Default;
            this.interrupt = false;
            this.nextActionIndex = 0;
        }

        public override void RequestChangeStrategy(StrategyEnum strategy)
        {
            // if active strategy has lesser priority
            if ((byte)this.activeStrategy > (byte)strategy)
            {
                this.interrupt = true;
                this.requestedStrategy = strategy;
            }
        }

        private void RunStrategies()
        {
            if (this.interrupt)
            {
                if (this.activeStrategy != this.requestedStrategy)
                {
                    this.nextActionIndex = 0;
                    this.activeStrategy = this.requestedStrategy;
                }
                this.interrupt = false;
            }

            if (this.Evaluations[this.activeStrategy].Count > this.nextActionIndex)
                this.Evaluations[this.activeStrategy][this.nextActionIndex].TestAndExecute();
            else
                this.nextActionIndex = 0;

            if (this.Evaluations[this.activeStrategy][this.nextActionIndex].NextIndex.HasValue
                && this.Evaluations[this.activeStrategy][this.nextActionIndex].NextIndex.Value != this.nextActionIndex)
            {
                this.prevActionIndex = this.nextActionIndex;
                this.nextActionIndex = this.Evaluations[this.activeStrategy][this.nextActionIndex].NextIndex.Value;
                if (this.Evaluations[this.activeStrategy][this.nextActionIndex].NextIndex.HasValue &&
                    this.Evaluations[this.activeStrategy][this.nextActionIndex].NextIndex.Value == this.prevActionIndex)
                    this.DoNothing();
            }
            else if (this.nextActionIndex >= GlobalConstants.DNA_SIZE - 1)
                this.nextActionIndex = 0;
            else
                this.nextActionIndex++;
        }

        #endregion Strategy controller.
    }
}