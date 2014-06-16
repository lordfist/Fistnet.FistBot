using Fistnet.FistBot.Bot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fistnet.FistBot.Actions
{
    public class TurnRadarRightLeft60 : ActionBase
    {
        public TurnRadarRightLeft60(BotBase owner)
            : base(owner)
        {
        }

        public override ActionTypeEnum ActionType
        {
            get { return ActionTypeEnum.TurnRadarRightLeft60; }
        }

        public override void Execute(double errorChance)
        {
            this.Owner.TurnRadarLeft(30 + 30 * errorChance);
            this.Owner.TurnRadarRight(60 + 60 * errorChance);
            this.Owner.TurnRadarLeft(30 + 30 * errorChance);
        }
    }
}