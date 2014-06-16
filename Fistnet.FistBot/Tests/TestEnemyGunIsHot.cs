using Fistnet.FistBot.Bot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fistnet.FistBot.Tests
{
    public class TestEnemyGunIsHot : TestBase
    {
        public override TestTypeEnum TestType
        {
            get { return TestTypeEnum.TestEnemyGunIsHot; }
        }

        public override bool Evaluate()
        {
            if (this.Owner.ActiveField.TrackedEnemy != null
               && this.Owner.ActiveField.TrackedBullet != null)
            {
                return (this.Owner.ActiveField.TrackedBullet.Time <= 5);
            }
            else
                return false;
        }

        public TestEnemyGunIsHot(BotBase owner)
            : base(owner)
        {
        }
    }
}