using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fistnet.FistBot.Bot;

namespace Fistnet.FistBot.Actions
{
    public class TurnGunRight5 : ActionBase
    {
        public TurnGunRight5(BotBase owner)
            : base(owner)
        {
        }

        public override ActionTypeEnum ActionType
        {
            get { return ActionTypeEnum.TurnGunRight5; }
        }

        public override void Execute(double errorChance)
        {
            this.Owner.TurnGunRight(5 + 5 * errorChance);
        }
    }
}