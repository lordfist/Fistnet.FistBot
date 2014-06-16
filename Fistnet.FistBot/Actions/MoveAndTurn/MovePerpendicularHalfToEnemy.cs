using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fistnet.FistBot.Bot;

namespace Fistnet.FistBot.Actions
{
    public class MovePerpendicularHalfToEnemy : ActionBase
    {
        public MovePerpendicularHalfToEnemy(BotBase owner)
            : base(owner)
        {
        }

        public override ActionTypeEnum ActionType
        {
            get { return ActionTypeEnum.MovePerpendicularHalfToEnemy; }
        }

        public override void Execute(double errorChance)
        {
            if (this.Owner.ActiveField.TrackedEnemy == null)
            {
                this.Owner.DoNothing();
                return;
            }
            double absBearingToEnemy = this.Owner.GetAbsolutBearingFromPoint(this.Owner.GetEnemyPositionWithPrediction(this.Owner.ActiveField.TrackedEnemy));
            double turn = absBearingToEnemy - this.Owner.Heading;

            turn = turn.NormalizeBearing();
            this.Owner.SetTurnGunRight(turn);

            if (turn > 0)
                turn = turn - 90;
            else
                turn = turn + 90;

            PointD enemyFuturePosition = this.Owner.GetEnemyPositionWithPrediction(this.Owner.ActiveField.TrackedEnemy);

            double moveDistance = this.Owner.GetMyPosition().CalculateDistance(enemyFuturePosition) / 2;

            this.Owner.SetAhead(moveDistance - moveDistance * errorChance);
            this.Owner.SetTurnRight(turn);
            this.Owner.Execute();
        }
    }
}