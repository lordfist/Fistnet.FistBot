using Fistnet.FistBot.Bot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fistnet.FistBot.Actions
{
    public class BackDistanceToEnemy : ActionBase
    {
        public BackDistanceToEnemy(BotBase owner)
            : base(owner)
        {
        }

        public override ActionTypeEnum ActionType
        {
            get { return ActionTypeEnum.BackDistanceToEnemy; }
        }

        public override void Execute(double errorChance)
        {
            PointD myPosition = Common.GetMyPosition(this.Owner);
            if (this.Owner.ActiveField.TrackedEnemy != null)
            {
                PointD enemyFuturePosition = this.Owner.GetEnemyPositionWithPrediction(this.Owner.ActiveField.TrackedEnemy);

                double moveDistance = myPosition.CalculateDistance(enemyFuturePosition);
                this.Owner.Back(moveDistance - moveDistance * errorChance);
            }
        }
    }
}