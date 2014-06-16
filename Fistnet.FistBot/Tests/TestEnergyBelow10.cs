using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fistnet.FistBot.Bot;

namespace Fistnet.FistBot.Tests
{
    public class TestEnergyBelow10 : TestBase
    {
        public override TestTypeEnum TestType
        {
            get { return TestTypeEnum.TestEnergyBelow10; }
        }

        public override bool Evaluate()
        {
            if (this.Owner.ActiveField.TurnStatus.Status.Energy < 10)
                return true;
            else
                return false;
        }

        public TestEnergyBelow10(BotBase owner)
            : base(owner)
        {
        }
    }
}