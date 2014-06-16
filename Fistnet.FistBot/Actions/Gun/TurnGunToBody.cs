using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fistnet.FistBot.Bot;

namespace Fistnet.FistBot.Actions
{
    public class TurnGunToBody : ActionBase
    {
        public TurnGunToBody(BotBase owner)
            : base(owner)
        {
        }

        public override ActionTypeEnum ActionType
        {
            get { return ActionTypeEnum.TurnGunToBody; }
        }

        public override void Execute(double errorChance)
        {
            double turn = this.Owner.Heading - this.Owner.GunHeading;
            this.Owner.TurnGunRight(turn);
        }
    }
}