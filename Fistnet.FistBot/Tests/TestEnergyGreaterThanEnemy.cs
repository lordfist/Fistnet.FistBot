using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fistnet.FistBot.Bot;

namespace Fistnet.FistBot.Tests
{
    public class TestEnergyGreaterThanEnemy : TestBase
    {
        public override TestTypeEnum TestType
        {
            get { return TestTypeEnum.TestEnergyGreaterThanEnemy; }
        }

        public override bool Evaluate()
        {
            if (this.Owner.ActiveField.TrackedEnemy != null
                && (this.Owner.Time - this.Owner.ActiveField.TrackedEnemy.Time) < Common.MAX_TIME_DISTANCE_TEST)
            {
                return (this.Owner.ActiveField.TrackedEnemy.Energy > this.Owner.ActiveField.TurnStatus.Status.Energy);
            }
            else
                return false;
        }

        public TestEnergyGreaterThanEnemy(BotBase owner)
            : base(owner)
        {
        }
    }
}