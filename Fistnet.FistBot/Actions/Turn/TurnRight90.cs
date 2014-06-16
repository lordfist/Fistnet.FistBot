using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fistnet.FistBot.Bot;

namespace Fistnet.FistBot.Actions
{
    public class TurnRight90 : ActionBase
    {
        public TurnRight90(BotBase owner)
            : base(owner)
        {
        }

        public override ActionTypeEnum ActionType
        {
            get { return ActionTypeEnum.TurnRight90; }
        }

        public override void Execute(double errorChance)
        {
            this.Owner.TurnRight(90);
        }
    }
}