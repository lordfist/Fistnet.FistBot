using Fistnet.FistBot.Bot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fistnet.FistBot.Tests
{
    public abstract class TestBase
    {
        public BotBase Owner { get; private set; }

        public abstract TestTypeEnum TestType { get; }

        public abstract bool Evaluate();

        public TestBase(BotBase owner)
        {
            this.Owner = owner;
        }
    }
}