using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fistnet.FistBot.Bot;

namespace Fistnet.FistBot.Actions
{
    public class AheadHalfDistanceToEnemy : ActionBase
    {
        public AheadHalfDistanceToEnemy(BotBase owner)
            : base(owner)
        {
        }

        public override ActionTypeEnum ActionType
        {
            get { return ActionTypeEnum.AheadHalfDistanceToEnemy; }
        }

        public override void Execute(double errorChance)
        {
            PointD myPosition = Common.GetMyPosition(this.Owner);
            if (this.Owner.ActiveField.TrackedEnemy != null)
            {
                PointD enemyFuturePosition = this.Owner.GetEnemyPositionWithPrediction(this.Owner.ActiveField.TrackedEnemy);

                double moveDistance = myPosition.CalculateDistance(enemyFuturePosition) / 2;
                this.Owner.SetAhead(moveDistance - moveDistance * errorChance);

                double absBearingToEnemy = this.Owner.GetAbsolutBearingFromPoint(this.Owner.GetEnemyPositionWithPrediction(this.Owner.ActiveField.TrackedEnemy));
                double turn = absBearingToEnemy - this.Owner.GunHeading;
                turn = turn.NormalizeBearing();

                this.Owner.SetTurnGunRight(turn);
                this.Owner.Execute();
            }
        }
    }
}