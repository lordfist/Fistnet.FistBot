using Fistnet.FistBot.Bot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fistnet.FistBot.Tests
{
    public class TestEnemyEnergyBelow10 : TestBase
    {
        public override TestTypeEnum TestType
        {
            get { return TestTypeEnum.TestEnemyEnergyBelow10; }
        }

        public override bool Evaluate()
        {
            if (this.Owner.ActiveField.TrackedEnemy != null
                && (this.Owner.Time - this.Owner.ActiveField.TrackedEnemy.Time) < Common.MAX_TIME_DISTANCE_TEST)
            {
                return (this.Owner.ActiveField.TrackedEnemy.Energy < 10);
            }
            else
                return false;
        }

        public TestEnemyEnergyBelow10(BotBase owner)
            : base(owner)
        {
        }
    }
}