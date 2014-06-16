using Fistnet.FistBot.Bot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fistnet.FistBot.Actions
{
    public class TurnRadarLeft20 : ActionBase
    {
        public TurnRadarLeft20(BotBase owner)
            : base(owner)
        {
        }

        public override ActionTypeEnum ActionType
        {
            get { return ActionTypeEnum.TurnRadarLeft20; }
        }

        public override void Execute(double errorChance)
        {
            this.Owner.TurnRadarLeft(20 + 20 * errorChance);
        }
    }
}