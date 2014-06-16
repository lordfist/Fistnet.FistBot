using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fistnet.FistBot.Bot;

namespace Fistnet.FistBot.Actions
{
    public class TurnRight10 : ActionBase
    {
        public TurnRight10(BotBase owner)
            : base(owner)
        {
        }

        public override ActionTypeEnum ActionType
        {
            get { return ActionTypeEnum.TurnRight10; }
        }

        public override void Execute(double errorChance)
        {
            this.Owner.TurnRight(10);
        }
    }
}