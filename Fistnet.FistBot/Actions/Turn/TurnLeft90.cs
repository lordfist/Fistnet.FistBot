using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fistnet.FistBot.Bot;

namespace Fistnet.FistBot.Actions
{
    public class TurnLeft90 : ActionBase
    {
        public TurnLeft90(BotBase owner)
            : base(owner)
        {
        }

        public override ActionTypeEnum ActionType
        {
            get { return ActionTypeEnum.TurnLeft90; }
        }

        public override void Execute(double errorChance)
        {
            this.Owner.TurnLeft(90);
        }
    }
}