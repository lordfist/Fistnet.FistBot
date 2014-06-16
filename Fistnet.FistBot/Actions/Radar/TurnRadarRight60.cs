using Fistnet.FistBot.Bot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fistnet.FistBot.Actions
{
    public class TurnRadarRight60 : ActionBase
    {
        public TurnRadarRight60(BotBase owner)
            : base(owner)
        {
        }

        public override ActionTypeEnum ActionType
        {
            get { return ActionTypeEnum.TurnRadarRight60; }
        }

        public override void Execute(double errorChance)
        {
            this.Owner.TurnRadarRight(60 + 60 * errorChance);
        }
    }
}