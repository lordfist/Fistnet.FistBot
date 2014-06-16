using Fistnet.FistBot.Bot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fistnet.FistBot.Actions
{
    public class TurnRadarLeft60 : ActionBase
    {
        public TurnRadarLeft60(BotBase owner)
            : base(owner)
        {
        }

        public override ActionTypeEnum ActionType
        {
            get { return ActionTypeEnum.TurnRadarLeft60; }
        }

        public override void Execute(double errorChance)
        {
            this.Owner.TurnRadarLeft(60 + 60 * errorChance);
        }
    }
}