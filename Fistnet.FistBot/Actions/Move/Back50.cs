using Fistnet.FistBot.Bot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fistnet.FistBot.Actions
{
    public class Back50 : ActionBase
    {
        public Back50(BotBase owner)
            : base(owner)
        {
        }

        public override ActionTypeEnum ActionType
        {
            get { return ActionTypeEnum.Back50; }
        }

        public override void Execute(double errorChance)
        {
            this.Owner.Back(50 - 50 * errorChance);
        }
    }
}