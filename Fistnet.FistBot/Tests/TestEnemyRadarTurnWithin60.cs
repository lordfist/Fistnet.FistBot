using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fistnet.FistBot.Actions;
using Fistnet.FistBot.Bot;

namespace Fistnet.FistBot.Tests
{
    public class TestEnemyRadarTurnWithin60 : TestBase
    {
        public override TestTypeEnum TestType
        {
            get { return TestTypeEnum.TestEnemyRadarTurnWithin60; }
        }

        public override bool Evaluate()
        {
            bool eval = false;

            if (this.Owner.ActiveField.TrackedEnemy != null
                && (this.Owner.Time - this.Owner.ActiveField.TrackedEnemy.Time) < Common.MAX_TIME_DISTANCE_TEST)
            {
                double absBearingToEnemy = this.Owner.GetAbsolutBearingFromPoint(this.Owner.GetEnemyPositionWithPrediction(this.Owner.ActiveField.TrackedEnemy));
                double turn = absBearingToEnemy - this.Owner.ActiveField.TurnStatus.Status.GunHeading;
                eval = (Math.Abs(turn) <= 60);
            }

            return eval;
        }

        public TestEnemyRadarTurnWithin60(BotBase owner)
            : base(owner)
        {
        }
    }
}