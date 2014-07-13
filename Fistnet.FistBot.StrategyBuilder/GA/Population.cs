using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FistCore.Core;
using FistCore.Core.Common;
using Fistnet.FistBot.BL;
using Fistnet.FistBot.Bot;
using Fistnet.FistBot.DAL;

namespace Fistnet.FistBot.StrategyBuilder.GA
{
    public static class Population
    {
        private static Random random = new Random();

        private static Generation CreateNewGeneration()
        {
            GenerationMeta genMeta = new GenerationMeta();
            UpdateStatement update = new UpdateStatement(genMeta);
            update.UpdateList = new UpdateList(genMeta.Active, 0);
            update.Execute();

            Generation gen = new Generation();
            gen.Active = true;
            gen.Save(null);
            return gen;
        }

        public static int CreateAndActivateNextRandomGeneration(int popSize, bool reoladFromLast)
        {
            int lastGen = Generation.GetLastGenerationId();
            if (lastGen == 0)
            {
                reoladFromLast = false;
            }

            if (reoladFromLast)
            {
                StrategyMeta stratMeta = new StrategyMeta(true);

                UpdateStatement updateStrat = new UpdateStatement(stratMeta);
                updateStrat.UpdateList.Add(UpdateExpressionFactory.Null(stratMeta.Fitness));
                updateStrat.UpdateList.Add(stratMeta.Used, false);

                SelectStatement lastOne = new SelectStatement(stratMeta, stratMeta.Id);
                lastOne.Top = 1;
                lastOne.Where.Add(stratMeta.IdGeneration, lastGen);
                lastOne.OrderBy.Add(stratMeta.Id, false);

                updateStrat.Where.Add(PredicateFactory.In(stratMeta.Id, lastOne));
                updateStrat.Execute();

                return lastGen;
            }
            else
            {
                Generation gen = CreateNewGeneration();

                for (int i = 0; i < popSize; i++)
                {
                    Strategy strategy = new Strategy();
                    strategy.IdGeneration = gen.IdGeneration;
                    strategy.Used = false;
                    strategy.Strategy = BotDna.CreateRandomDnaStrategy();
                    strategy.Save(null);
                }

                return gen.IdGeneration;
            }
        }

        public static int CreateAndActivateNextGenerationBasedOn(int generationId)
        {
            EntityCollection<StrategyEntity, StrategyMeta> oldGeneration = Strategy.GetGeneration(generationId);

            Generation gen = CreateNewGeneration();

            EntityCollection<StrategyEntity, StrategyMeta> newGeneration = new EntityCollection<StrategyEntity, StrategyMeta>();

            int genSize = oldGeneration.Count;
            int eliteCount = (int)(genSize * 0.05);
            if (eliteCount > 2)
                eliteCount = 2;

            int halfCount = (int)(genSize * 0.8);
            int remainingCount = oldGeneration.Count - halfCount - eliteCount;

            EntityCollection<StrategyEntity, StrategyMeta> eliteOnes = Strategy.GetAllTop(eliteCount, generationId);
            eliteCount = random.Next(eliteOnes.Count);

            for (int i = 0; i < eliteCount; i++)
            {
                StrategyEntity strategy = new StrategyEntity();
                strategy.IdGeneration = gen.IdGeneration;
                strategy.Used = false;
                strategy.Strategy = eliteOnes[i].Strategy;

                newGeneration.Add(strategy);
            }

            EntityCollection<StrategyEntity, StrategyMeta> chosenFirst = new EntityCollection<StrategyEntity, StrategyMeta>();
            EntityCollection<StrategyEntity, StrategyMeta> chosenSecond = new EntityCollection<StrategyEntity, StrategyMeta>();

            decimal sumFitness = oldGeneration.Sum((item) => { return item.Fitness.Value; });

            while (chosenFirst.Count < halfCount || chosenSecond.Count < halfCount)
            {
                decimal selectedNumber = (decimal)random.NextDouble() * sumFitness + ((decimal)100 - oldGeneration[0].Fitness.Value);
                decimal selectedAltNumber = (decimal)random.NextDouble() * sumFitness + ((decimal)100 - oldGeneration[0].Fitness.Value);

                decimal currentFitness = 0;
                for (int i = 0; i < genSize - 1; i++)
                {
                    currentFitness += ((decimal)100 - oldGeneration[i].Fitness.Value);

                    bool chooseThis = (selectedNumber > currentFitness);
                    bool chooseAltThis = (selectedAltNumber > currentFitness);

                    if (chooseThis && chosenFirst.Count < halfCount)
                        chosenFirst.Add(oldGeneration[i]);

                    if (chooseAltThis && chosenSecond.Count < halfCount)
                        chosenSecond.Add(oldGeneration[i + 1]);
                }
            }

            for (int i = 0; i < halfCount; i++)
            {
                StrategyEntity strategy = new StrategyEntity();
                strategy.IdGeneration = gen.IdGeneration;
                strategy.Used = false;
                if (chosenFirst[i].Fitness.Value > 1 && chosenSecond[i].Fitness.Value > 1)
                    try
                    {
                        strategy.Strategy = DnaStrategyUtil.CombineDna(chosenFirst[i].Strategy, chosenSecond[i].Strategy);
                    }
                    catch (Exception ex)
                    {
                        strategy.Strategy = BotDna.CreateRandomDnaStrategy();
                    }
                else
                    strategy.Strategy = BotDna.CreateRandomDnaStrategy();

                newGeneration.Add(strategy);
            }

            remainingCount = oldGeneration.Count - newGeneration.Count;
            if (remainingCount <= 0)
                remainingCount = 0;

            for (int i = 0; i < remainingCount; i++)
            {
                StrategyEntity strategy = new StrategyEntity();
                strategy.IdGeneration = gen.IdGeneration;
                strategy.Used = false;

                if (random.Next(2) == 1)
                    strategy.Strategy = DnaStrategyUtil.CombineDna(BotDna.CreateRandomDnaStrategy(), chosenSecond[i].Strategy);
                else
                    strategy.Strategy = DnaStrategyUtil.CombineDna(BotDna.CreateRandomDnaStrategy(), chosenFirst[i].Strategy);

                newGeneration.Add(strategy);
            }
            DALHelper.SaveEntities(newGeneration, new Catalog().CreateConnectionProvider());
            return gen.IdGeneration;
        }
    }
}