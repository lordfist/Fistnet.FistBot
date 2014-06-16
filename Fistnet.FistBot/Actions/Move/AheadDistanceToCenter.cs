using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fistnet.FistBot.Bot;

namespace Fistnet.FistBot.Actions
{
    public class AheadDistanceToCenter : ActionBase
    {
        public AheadDistanceToCenter(BotBase owner)
            : base(owner)
        {
        }

        public override ActionTypeEnum ActionType
        {
            get { return ActionTypeEnum.AheadDistanceToCenter; }
        }

        public override void Execute(double errorChance)
        {
            PointD myPosition = Common.GetMyPosition(this.Owner);
            PointD centerPosition = Common.GetCenterPosition(this.Owner);

            double moveDistance = myPosition.CalculateDistance(centerPosition);

            this.Owner.Ahead(moveDistance - moveDistance * errorChance);
        }
    }
}