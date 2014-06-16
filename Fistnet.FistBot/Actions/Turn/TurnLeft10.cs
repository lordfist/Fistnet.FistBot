using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fistnet.FistBot.Bot;

namespace Fistnet.FistBot.Actions
{
    public class TurnLeft10 : ActionBase
    {
        public TurnLeft10(BotBase owner)
            : base(owner)
        {
        }

        public override ActionTypeEnum ActionType
        {
            get { return ActionTypeEnum.TurnLeft10; }
        }

        public override void Execute(double errorChance)
        {
            this.Owner.TurnLeft(10);
        }
    }
}