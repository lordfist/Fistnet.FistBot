using Fistnet.FistBot.Bot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fistnet.FistBot.Actions
{
    public class TurnRadarToGun : ActionBase
    {
        public TurnRadarToGun(BotBase owner)
            : base(owner)
        {
        }

        public override ActionTypeEnum ActionType
        {
            get { return ActionTypeEnum.TurnRadarToGun; }
        }

        public override void Execute(double errorChance)
        {
            double turn = this.Owner.GunHeading - this.Owner.RadarHeading;
            this.Owner.TurnRadarRight(turn);
        }
    }
}