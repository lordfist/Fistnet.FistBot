using Fistnet.FistBot.Actions;
using Fistnet.FistBot.Bot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fistnet.FistBot.Tests
{
    public class TestFire2DistanceWithin10 : TestBase
    {
        public override TestTypeEnum TestType
        {
            get { return TestTypeEnum.TestFire2DistanceWithin10; }
        }

        public override bool Evaluate()
        {
            bool eval = false;

            if (this.Owner.ActiveField.TrackedEnemy != null
                && (this.Owner.Time - this.Owner.ActiveField.TrackedEnemy.Time) < Common.MAX_TIME_DISTANCE_TEST)
            {
                eval = (this.Owner.ActiveField.TrackedEnemy.Distance / GlobalConstants.BULLET_VELOCITY_2) <= 10;
            }

            return eval;
        }

        public TestFire2DistanceWithin10(BotBase owner)
            : base(owner)
        {
        }
    }
}