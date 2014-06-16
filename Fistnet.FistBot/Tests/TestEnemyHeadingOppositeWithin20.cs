using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fistnet.FistBot.Actions;
using Fistnet.FistBot.Bot;

namespace Fistnet.FistBot.Tests
{
    public class TestEnemyHeadingOppositeWithin20 : TestBase
    {
        public override TestTypeEnum TestType
        {
            get { return TestTypeEnum.TestEnemyHeadingOppositeWithin20; }
        }

        public override bool Evaluate()
        {
            bool eval = false;

            if (this.Owner.ActiveField.TrackedEnemy != null
                && (this.Owner.Time - this.Owner.ActiveField.TrackedEnemy.Time) < Common.MAX_TIME_DISTANCE_TEST)
            {
                if (this.Owner.ActiveField.TrackedEnemy.Heading.HasValue)
                    eval = (Math.Abs(this.Owner.ActiveField.TrackedEnemy.Heading.Value - this.Owner.ActiveField.TurnStatus.Status.Heading) >= 160);
            }

            return eval;
        }

        public TestEnemyHeadingOppositeWithin20(BotBase owner)
            : base(owner)
        {
        }
    }
}