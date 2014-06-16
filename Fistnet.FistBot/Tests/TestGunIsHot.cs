using Fistnet.FistBot.Bot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fistnet.FistBot.Tests
{
    public class TestGunIsHot : TestBase
    {
        public override TestTypeEnum TestType
        {
            get { return TestTypeEnum.TestGunIsHot; }
        }

        public override bool Evaluate()
        {
            if (this.Owner.GunHeat > 0)
                return true;
            else
                return false;
        }

        public TestGunIsHot(BotBase owner)
            : base(owner)
        {
        }
    }
}