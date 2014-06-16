using Fistnet.FistBot.Bot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fistnet.FistBot.Tests
{
    public class TestEnemyEnergy0 : TestBase
    {
        public override TestTypeEnum TestType
        {
            get { return TestTypeEnum.TestEnemyEnergy0; }
        }

        public override bool Evaluate()
        {
            if (this.Owner.ActiveField.TrackedEnemy != null
                && (this.Owner.Time - this.Owner.ActiveField.TrackedEnemy.Time) < Common.MAX_TIME_DISTANCE_TEST)
            {
                return (this.Owner.ActiveField.TrackedEnemy.Energy == 0);
            }
            else
                return false;
        }

        public TestEnemyEnergy0(BotBase owner)
            : base(owner)
        {
        }
    }
}