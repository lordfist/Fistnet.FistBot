using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fistnet.FistBot.Bot;

namespace Fistnet.FistBot.Tests
{
    public class TestOthersMoreThan1 : TestBase
    {
        public override TestTypeEnum TestType
        {
            get { return TestTypeEnum.TestOthersMoreThan1; }
        }

        public override bool Evaluate()
        {
            return (this.Owner.Others > 1);
        }

        public TestOthersMoreThan1(BotBase owner)
            : base(owner)
        {
        }
    }
}