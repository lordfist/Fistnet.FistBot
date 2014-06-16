using Fistnet.FistBot.Bot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fistnet.FistBot.Actions
{
    public class Fire05 : ActionBase
    {
        public Fire05(BotBase owner)
            : base(owner)
        {
        }

        public override ActionTypeEnum ActionType
        {
            get { return ActionTypeEnum.Fire05; }
        }

        public override void Execute(double errorChance)
        {
            this.Owner.Fire(0.5 + 0.5 * errorChance);
        }
    }
}