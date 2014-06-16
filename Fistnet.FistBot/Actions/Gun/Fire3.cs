using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fistnet.FistBot.Bot;

namespace Fistnet.FistBot.Actions
{
    public class Fire3 : ActionBase
    {
        public Fire3(BotBase owner)
            : base(owner)
        {
        }

        public override ActionTypeEnum ActionType
        {
            get { return ActionTypeEnum.Fire3; }
        }

        public override void Execute(double errorChance)
        {
            if (this.Owner.GunHeat == 0 && Math.Abs(this.Owner.GunTurnRemaining) < 10)
                this.Owner.Fire(3);
            else
                this.Owner.DoNothing();
        }
    }
}