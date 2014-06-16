using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fistnet.FistBot.Actions;
using Fistnet.FistBot.Evaluation;
using Fistnet.FistBot.Tests;

namespace Fistnet.FistBot.Bot
{
    public static class BotDna
    {
        #region Serialize strategy.

        public static string SerializeStrategies(this Dictionary<StrategyEnum, List<EvaluationBase>> strategies)
        {
            // STRATEGY=EVAL,TEST?ACTION;ALTERNATE_ACTION|EVAL,TEST?ACTION;-|EVAL,TEST?Iindex;Ialternate_index|EVAL,TEST?Iindex;-|

            string strategyString = "";
            foreach (StrategyEnum strategy in strategies.Keys)
            {
                strategyString += ((byte)strategy).ToString() + "=";

                foreach (EvaluationBase eval in strategies[strategy])
                {
                    strategyString += ((byte)eval.EvalType).ToString() + ",";
                    strategyString += ((byte)eval.Test.TestType).ToString() + "?";

                    if (eval.Action != null)
                    {
                        strategyString += ((byte)eval.Action.ActionType).ToString() + ";";

                        if (eval.AlternateAction != null)
                            strategyString += ((byte)eval.AlternateAction.ActionType).ToString() + "|";
                        else
                            strategyString += "-|";
                    }

                    if (eval.JumpIndex.HasValue)
                    {
                        strategyString += "I" + ((byte)eval.JumpIndex.Value).ToString() + ";";

                        if (eval.AlternateJumpIndex.HasValue)
                            strategyString += "I" + ((byte)eval.AlternateJumpIndex.Value).ToString() + "|";
                        else
                            strategyString += "-|";
                    }
                }

                strategyString += "<>";
            }

            return strategyString;
        }

        #endregion Serialize strategy.

        #region Deserialize strategy.

        private static EvaluationBase DeserializeEvaluation(BotBase bot, string data, byte evalIndex)
        {
            // EVAL,TEST?ACTION;ALTERNATE_ACTION
            string[] evalAndTest = data.Split(',');
            string[] testAndActions = evalAndTest[1].Split('?');
            EvaluationTypeEnum evalEn = (EvaluationTypeEnum)byte.Parse(evalAndTest[0]);
            string[] actions = testAndActions[1].Split(';');

            TestTypeEnum testEn = (TestTypeEnum)byte.Parse(testAndActions[0]);
            TestBase test = Factory.CreateTest(bot, testEn);

            byte? index = null;
            byte? altIndex = null;
            ActionBase actionTp = null;
            ActionBase altActionTp = null;

            if (actions[0].StartsWith("I") && actions[0] != "-")
                index = byte.Parse(actions[0].Remove(0, 1).Trim());
            if (actions[1].StartsWith("I") && actions[1] != "-")
                altIndex = byte.Parse(actions[1].Remove(0, 1).Trim());

            if (!actions[0].StartsWith("I") && actions[0] != "-")
                actionTp = Factory.CreateAction(bot, (ActionTypeEnum)byte.Parse(actions[0]));

            if (!actions[1].StartsWith("I") && actions[1] != "-")
                altActionTp = Factory.CreateAction(bot, (ActionTypeEnum)byte.Parse(actions[1]));

            if (actionTp == null && !index.HasValue)
                throw new ArgumentNullException("actionTp AND index");

            switch (evalEn)
            {
                case EvaluationTypeEnum.True:
                    return new TrueCondition(bot, test, actionTp, altActionTp, index, altIndex, evalIndex);

                case EvaluationTypeEnum.JumpTrue:
                    return new JumpTrueCondition(bot, test, actionTp, altActionTp, index, altIndex, evalIndex);

                case EvaluationTypeEnum.JumpFalse:
                    return new JumpFalseCondition(bot, test, actionTp, altActionTp, index, altIndex, evalIndex);

                case EvaluationTypeEnum.JumpIf:
                    return new JumpIfCondition(bot, test, actionTp, altActionTp, index, altIndex, evalIndex);

                default:
                    return new TrueCondition(bot, test, actionTp, altActionTp, index, altIndex, evalIndex);
            }
        }

        private static List<EvaluationBase> DeserializeStrategy(BotBase bot, string data)
        {
            // EVAL,ACTION;ALTERNATE_ACTION|EVAL,ACTION;-|EVAL,Iindex,Ialternate_index|EVAL,Iindex,-|

            List<EvaluationBase> evals = new List<EvaluationBase>();
            List<string> evalsString = data.Split(new string[1] { "|" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            for (byte i = 0; i < evalsString.Count; i++)
            {
                evals.Add(DeserializeEvaluation(bot, evalsString[i], i));
            }

            return evals;
        }

        public static void DeserializeStrategies(this BotBase bot, string data)
        {
            Dictionary<StrategyEnum, List<EvaluationBase>> strategies = new Dictionary<StrategyEnum, List<EvaluationBase>>();

            List<string> strategyList = data.Split(new string[1] { "<>" }, StringSplitOptions.RemoveEmptyEntries).ToList();

            foreach (string strategyString in strategyList)
            {
                List<string> strategyAndEval = strategyString.Split(new string[1] { "=" }, StringSplitOptions.RemoveEmptyEntries).ToList();

                StrategyEnum strategy = (StrategyEnum)byte.Parse(strategyAndEval[0]);
                List<EvaluationBase> evals = DeserializeStrategy(bot, strategyAndEval[1]);

                strategies.Add(strategy, evals);
            }
            bot.Init(strategies);
        }

        #endregion Deserialize strategy.

        #region Create random.

        private static Random rnd = new Random();

        public static ActionTypeEnum CreateRandomAction()
        {
            return (ActionTypeEnum)(byte)rnd.Next(Actions.Common.ACTION_COUNT);
        }

        public static EvaluationTypeEnum CreateRandomEval()
        {
            return (EvaluationTypeEnum)(byte)rnd.Next(Evaluation.Common.EVALUATION_COUNT);
        }

        public static TestTypeEnum CreateRandomTest()
        {
            return (TestTypeEnum)(byte)rnd.Next(Tests.Common.TEST_COUNT);
        }

        public static byte GetRandomDnaIndex()
        {
            return (byte)rnd.Next(GlobalConstants.DNA_SIZE);
        }

        public static string CreateRandomDnaStrategy()
        {
            string sString = "";

            for (byte i = 0; i < GlobalConstants.DNA_STRANDS; i++)
            {
                List<string> strategies = new List<string>();
                sString += i.ToString() + "=";
                int jumpCount = 0;

                for (byte dnaIdx = 0; dnaIdx < GlobalConstants.DNA_SIZE; dnaIdx++)
                {
                    EvaluationTypeEnum evalType = CreateRandomEval();
                    if (dnaIdx == GlobalConstants.DNA_SIZE - 1 && i == GlobalConstants.DNA_STRANDS - 1)
                        evalType = EvaluationTypeEnum.True;

                    TestTypeEnum testType = CreateRandomTest();

                    bool isIndex = rnd.Next(10) == 1 ? true : false;
                    bool isAltIndex = rnd.Next(10) == 1 ? true : false;

                    if (i == (byte)StrategyEnum.OnBulletMissed || i == (byte)StrategyEnum.OnBulletHitBullet)
                    {
                        isIndex = false;
                        isAltIndex = false;
                    }

                    if (isAltIndex || isIndex)
                    {
                        jumpCount++;
                    }

                    if (jumpCount > 2)
                    {
                        isIndex = false;
                        isAltIndex = false;
                    }

                    ActionTypeEnum actionType = CreateRandomAction();
                    byte index = GetRandomDnaIndex();

                    ActionTypeEnum altActionType = CreateRandomAction();
                    byte altIndex = GetRandomDnaIndex();

                    string indexOrAction = (isIndex) ? "I" + index.ToString() : ((byte)actionType).ToString();
                    string altIndexOrAction = (isAltIndex) ? "I" + altIndex.ToString() : ((byte)altActionType).ToString();

                    if (evalType == EvaluationTypeEnum.JumpIf)
                    {
                        // EVAL,TEST?ACTION;ALTERNATE_ACTION
                        sString += ((byte)evalType).ToString() + "," + ((byte)testType).ToString() + "?" + indexOrAction + ";" + altIndexOrAction + "|";
                    }
                    else
                    {
                        sString += ((byte)evalType).ToString() + "," + ((byte)testType).ToString() + "?" + indexOrAction + ";-" + "|";
                    }
                }

                sString += string.Join("|", strategies) + "<>";
            }

            return sString;
        }

        #endregion Create random.
    }
}