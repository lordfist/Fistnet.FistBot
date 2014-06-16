using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fistnet.FistBot.Bot;

namespace Fistnet.FistBot.Actions
{
    public abstract class ActionBase
    {
        public BotBase Owner { get; private set; }

        public abstract ActionTypeEnum ActionType { get; }

        public abstract void Execute(double errorChance);

        public ActionBase(BotBase owner)
        {
            this.Owner = owner;
        }
    }
}