using Fistnet.FistBot.Bot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fistnet.FistBot.Actions
{
    public class Ahead50 : ActionBase
    {
        public Ahead50(BotBase owner)
            : base(owner)
        {
        }

        public override ActionTypeEnum ActionType
        {
            get { return ActionTypeEnum.Ahead50; }
        }

        public override void Execute(double errorChance)
        {
            this.Owner.Ahead(50 - 50 * errorChance);
        }
    }
}