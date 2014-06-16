using Fistnet.FistBot.Bot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fistnet.FistBot.Actions
{
    public class TurnRadarRightLeft20 : ActionBase
    {
        public TurnRadarRightLeft20(BotBase owner)
            : base(owner)
        {
        }

        public override ActionTypeEnum ActionType
        {
            get { return ActionTypeEnum.TurnRadarRightLeft20; }
        }

        public override void Execute(double errorChance)
        {
            this.Owner.TurnRadarLeft(10 + 10 * errorChance);
            this.Owner.TurnRadarRight(20 + 20 * errorChance);
            this.Owner.TurnRadarLeft(10 + 10 * errorChance);
        }
    }
}