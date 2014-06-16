using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fistnet.FistBot.Bot;

namespace Fistnet.FistBot.Actions
{
    public class UntrackTarget : ActionBase
    {
        public UntrackTarget(BotBase owner)
            : base(owner)
        {
        }

        public override ActionTypeEnum ActionType
        {
            get { return ActionTypeEnum.UntrackTarget; }
        }

        public override void Execute(double errorChance)
        {
            this.Owner.ActiveField.UnsetTracking();
            this.Owner.Ahead(10 * errorChance);
        }
    }
}