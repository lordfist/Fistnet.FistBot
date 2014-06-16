using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fistnet.FistBot.Bot;

namespace Fistnet.FistBot.Actions
{
    public class TurnGunLeft5 : ActionBase
    {
        public TurnGunLeft5(BotBase owner)
            : base(owner)
        {
        }

        public override ActionTypeEnum ActionType
        {
            get { return ActionTypeEnum.TurnGunLeft5; }
        }

        public override void Execute(double errorChance)
        {
            this.Owner.TurnGunLeft(5 + 5 * errorChance);
        }
    }
}