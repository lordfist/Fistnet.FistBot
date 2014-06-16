using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fistnet.FistBot.Actions;
using Fistnet.FistBot.Bot;
using Fistnet.FistBot.Evaluation;
using Fistnet.FistBot.Tests;

namespace Fistnet.FistBot.StrategyBuilder.GA
{
    public class EvalData
    {
        public EvaluationTypeEnum Evaluation { get; set; }

        public TestTypeEnum Test { get; set; }

        public ActionTypeEnum? Action { get; set; }

        public ActionTypeEnum? AltAction { get; set; }

        public byte? JIndex { get; set; }

        public byte? JAltIndex { get; set; }

        private void RandomizeMe()
        {
            Random rnd = new Random(DateTime.Now.Millisecond);
            this.Evaluation = BotDna.CreateRandomEval();
            this.Test = BotDna.CreateRandomTest();

            bool isIndex = rnd.Next(10) == 1 ? true : false;

            if (isIndex)
                this.JIndex = BotDna.GetRandomDnaIndex();
            else
                this.Action = BotDna.CreateRandomAction();

            if (this.Evaluation == EvaluationTypeEnum.JumpIf)
            {
                bool isAltIndex = rnd.Next(10) == 1 ? true : false;

                if (isAltIndex)
                    this.JAltIndex = BotDna.GetRandomDnaIndex();
                else
                    this.AltAction = BotDna.CreateRandomAction();
            }
        }

        public EvalData(bool random)
        {
            if (random)
            {
                RandomizeMe();
            }
            else
            {
                this.Evaluation = EvaluationTypeEnum.True;
                this.Test = TestTypeEnum.TestOthersMoreThan1;
                this.Action = null;
                this.AltAction = null;
                this.JIndex = null;
                this.JAltIndex = null;
            }
        }

        public EvalData(string eval)
        {
            // EVAL,TEST?ACTION;ALTERNATE_ACTION
            string[] evalAndTest = eval.Split(',');
            string[] testAndActions = evalAndTest[1].Split('?');
            EvaluationTypeEnum evalEn = (EvaluationTypeEnum)byte.Parse(evalAndTest[0]);
            string[] actions = testAndActions[1].Split(';');

            TestTypeEnum testEn = (TestTypeEnum)byte.Parse(testAndActions[0]);

            byte? index = 0;
            byte? altIndex = 0;
            ActionTypeEnum? actionTp = null;
            ActionTypeEnum? altActionTp = null;

            try
            {
                if (actions[0].StartsWith("I") && actions[0] != "-")
                    index = byte.Parse(actions[0].Remove(0, 1).Trim());
                if (actions[1].StartsWith("I") && actions[1] != "-")
                    altIndex = byte.Parse(actions[1].Remove(0, 1).Trim());

                if (!actions[0].StartsWith("I") && actions[0] != "-")
                    actionTp = (ActionTypeEnum)byte.Parse(actions[0]);

                if (!actions[1].StartsWith("I") && actions[1] != "-")
                    altActionTp = (ActionTypeEnum)byte.Parse(actions[1]);

                if (!actionTp.HasValue && !index.HasValue)
                {
                    throw new ArgumentNullException("actionTp AND index");
                }
            }
            catch (Exception ex)
            {
                Console.Write("EXCEPTION: - " + eval + "\r\n" + ex.Message);
                RandomizeMe();
            }

            this.Evaluation = evalEn;
            this.Test = testEn;
            this.Action = actionTp;
            this.AltAction = altActionTp;
            this.JIndex = index;
            this.JAltIndex = altIndex;
        }

        public override string ToString()
        {
            if (!this.Action.HasValue && !this.JIndex.HasValue)
            {
                this.Action = BotDna.CreateRandomAction();

                if (this.Evaluation == EvaluationTypeEnum.JumpIf && !this.AltAction.HasValue && !this.JAltIndex.HasValue)
                {
                    this.AltAction = BotDna.CreateRandomAction();
                }
            }

            string strategyString = ((byte)this.Evaluation).ToString() + ",";
            strategyString += ((byte)this.Test).ToString() + "?";

            if (this.Action.HasValue)
                strategyString += ((byte)this.Action.Value).ToString() + ";";
            else if (this.JIndex.HasValue)
                strategyString += "I" + ((byte)this.JIndex.Value).ToString() + ";";

            if (this.AltAction.HasValue)
                strategyString += ((byte)this.AltAction.Value).ToString();
            else if (this.JAltIndex.HasValue)
                strategyString += "I" + ((byte)this.JAltIndex.Value).ToString();
            else
                strategyString += "-";

            return strategyString;
        }
    }

    public static class DnaStrategyUtil
    {
        private static Random random = new Random();

        public static string CombineDna(string dna, string otherDna)
        {
            List<string> dnaStrategyList = dna.Split(new string[1] { "<>" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> otherStrategyList = otherDna.Split(new string[1] { "<>" }, StringSplitOptions.RemoveEmptyEntries).ToList();

            string childStrand = "";

            for (int i = 0; i < dnaStrategyList.Count; i++)
            {
                List<string> dnaStrategyAndEval = dnaStrategyList[i].Split(new string[1] { "=" }, StringSplitOptions.RemoveEmptyEntries).ToList();
                List<string> otherStrategyAndEval = otherStrategyList[i].Split(new string[1] { "=" }, StringSplitOptions.RemoveEmptyEntries).ToList();
                if (i < dnaStrategyList.Count - 1)
                    childStrand += dnaStrategyAndEval[0] + "=" + CombineDnaStrand(dnaStrategyAndEval[1], otherStrategyAndEval[1]) + "<>";
                else
                    childStrand += dnaStrategyAndEval[0] + "=" + CombineDnaStrand(dnaStrategyAndEval[1], otherStrategyAndEval[1]);
            }

            return childStrand;
        }

        public static string CombineDnaStrand(string dnaStrand, string otherDnaStrand)
        {
            List<string> evalsString = dnaStrand.Split(new string[1] { "|" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> otherEvalsString = otherDnaStrand.Split(new string[1] { "|" }, StringSplitOptions.RemoveEmptyEntries).ToList();

            string childStrand = "";

            int jumpCount = 0;
            for (int i = 0; i < evalsString.Count; i++)
            {
                bool hasJump = false;

                if (i < evalsString.Count - 1)
                    childStrand += CombineSingleEval(evalsString[i], otherEvalsString[i], jumpCount, out hasJump) + "|";
                else
                    childStrand += CombineSingleEval(evalsString[i], otherEvalsString[i], jumpCount, out hasJump);

                if (hasJump)
                {
                    jumpCount++;
                }
            }
            return childStrand;
        }

        public static string CombineSingleEval(string dnaEval, string otherDnaEval, int jumpCount, out bool hasJump)
        {
            if (random.Next(50) == 10)
            {
                EvalData evData = new EvalData(true);

                if (evData.JAltIndex.HasValue || evData.JIndex.HasValue)
                    hasJump = true;
                else
                    hasJump = false;

                return evData.ToString();
            }
            else
            {
                EvalData myData = new EvalData(dnaEval);
                EvalData otherData = new EvalData(otherDnaEval);

                EvalData combinedData = new EvalData(false);

                if (random.Next(2) == 0)
                    combinedData.Evaluation = myData.Evaluation;
                else
                    combinedData.Evaluation = otherData.Evaluation;

                if (random.Next(2) == 0)
                    combinedData.Test = myData.Test;
                else
                    combinedData.Test = otherData.Test;

                if (random.Next(2) == 0)
                    combinedData.Action = myData.Action;
                else
                    combinedData.Action = otherData.Action;

                if (random.Next(2) == 0 && jumpCount < 2)
                    combinedData.JIndex = myData.JIndex;
                else if (jumpCount < 2)
                    combinedData.JIndex = otherData.JIndex;

                if (combinedData.Evaluation == EvaluationTypeEnum.JumpIf)
                {
                    if (random.Next(2) == 0)
                        combinedData.AltAction = myData.AltAction.HasValue ? myData.AltAction : otherData.AltAction;
                    else
                        combinedData.AltAction = otherData.AltAction.HasValue ? otherData.AltAction : myData.AltAction;

                    if (random.Next(2) == 0 && jumpCount < 2)
                        combinedData.JAltIndex = myData.JAltIndex.HasValue ? myData.JAltIndex : otherData.JAltIndex;
                    else if (jumpCount < 2)
                        combinedData.JAltIndex = otherData.JAltIndex.HasValue ? otherData.JAltIndex : myData.JAltIndex;

                    if (!combinedData.AltAction.HasValue && !combinedData.JAltIndex.HasValue)
                    {
                        combinedData.AltAction = BotDna.CreateRandomAction();
                    }
                }

                if (combinedData.JIndex.HasValue || combinedData.JAltIndex.HasValue)
                    hasJump = true;
                else
                    hasJump = false;

                return combinedData.ToString();
            }
        }
    }
}