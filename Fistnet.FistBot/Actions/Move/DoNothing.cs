using Fistnet.FistBot.Bot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fistnet.FistBot.Actions
{
    public class DoNothing : ActionBase
    {
        public DoNothing(BotBase owner)
            : base(owner)
        {
        }

        public override ActionTypeEnum ActionType
        {
            get { return ActionTypeEnum.DoNothing; }
        }

        public override void Execute(double errorChance)
        {
            this.Owner.DoNothing();
        }
    }
}