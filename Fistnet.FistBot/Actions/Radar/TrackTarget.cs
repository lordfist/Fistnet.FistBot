using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fistnet.FistBot.Bot;

namespace Fistnet.FistBot.Actions
{
    public class TrackTarget : ActionBase
    {
        public TrackTarget(BotBase owner)
            : base(owner)
        {
        }

        public override ActionTypeEnum ActionType
        {
            get { return ActionTypeEnum.TrackTarget; }
        }

        public override void Execute(double errorChance)
        {
            if (this.Owner.ActiveField.LastSeenEnemy != null)
                this.Owner.ActiveField.SetTracking(this.Owner.ActiveField.LastSeenEnemy.Name);

            this.Owner.Ahead(10 * errorChance);
        }
    }
}