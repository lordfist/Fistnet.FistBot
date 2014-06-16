using Fistnet.FistBot.Bot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fistnet.FistBot.Actions
{
    public class TurnRadarToBody : ActionBase
    {
        public TurnRadarToBody(BotBase owner)
            : base(owner)
        {
        }

        public override ActionTypeEnum ActionType
        {
            get { return ActionTypeEnum.TurnRadarToBody; }
        }

        public override void Execute(double errorChance)
        {
            double turn = this.Owner.Heading - this.Owner.RadarHeading;
            this.Owner.TurnRadarRight(turn);
        }
    }
}