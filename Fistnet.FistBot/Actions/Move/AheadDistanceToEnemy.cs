using Fistnet.FistBot.Bot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fistnet.FistBot.Actions
{
    public class AheadDistanceToEnemy : ActionBase
    {
        public AheadDistanceToEnemy(BotBase owner)
            : base(owner)
        {
        }

        public override ActionTypeEnum ActionType
        {
            get { return ActionTypeEnum.AheadDistanceToEnemy; }
        }

        public override void Execute(double errorChance)
        {
            PointD myPosition = Common.GetMyPosition(this.Owner);
            if (this.Owner.ActiveField.TrackedEnemy != null)
            {
                PointD enemyFuturePosition = this.Owner.GetEnemyPositionWithPrediction(this.Owner.ActiveField.TrackedEnemy);

                double moveDistance = myPosition.CalculateDistance(enemyFuturePosition);
                this.Owner.Ahead(moveDistance - moveDistance * errorChance);
            }
        }
    }
}