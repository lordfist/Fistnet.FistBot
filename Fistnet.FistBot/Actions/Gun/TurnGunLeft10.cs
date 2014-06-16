using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fistnet.FistBot.Bot;

namespace Fistnet.FistBot.Actions
{
    public class TurnGunLeft10 : ActionBase
    {
        public TurnGunLeft10(BotBase owner)
            : base(owner)
        {
        }

        public override ActionTypeEnum ActionType
        {
            get { return ActionTypeEnum.TurnGunLeft10; }
        }

        public override void Execute(double errorChance)
        {
            this.Owner.TurnGunLeft(10 + 10 * errorChance);
        }
    }
}