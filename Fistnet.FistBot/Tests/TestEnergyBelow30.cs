using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fistnet.FistBot.Bot;

namespace Fistnet.FistBot.Tests
{
    public class TestEnergyBelow30 : TestBase
    {
        public override TestTypeEnum TestType
        {
            get { return TestTypeEnum.TestEnergyBelow30; }
        }

        public override bool Evaluate()
        {
            if (this.Owner.ActiveField.TurnStatus.Status.Energy < 30)
                return true;
            else
                return false;
        }

        public TestEnergyBelow30(BotBase owner)
            : base(owner)
        {
        }
    }
}