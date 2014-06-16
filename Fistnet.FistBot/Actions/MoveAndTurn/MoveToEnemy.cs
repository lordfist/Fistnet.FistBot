using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fistnet.FistBot.Bot;

namespace Fistnet.FistBot.Actions
{
    public class MoveToEnemy : ActionBase
    {
        public MoveToEnemy(BotBase owner)
            : base(owner)
        {
        }

        public override ActionTypeEnum ActionType
        {
            get { return ActionTypeEnum.MoveToEnemy; }
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
            this.Owner.SetTurnRight(turn.NormalizeBearing());
            this.Owner.SetAhead(this.Owner.ActiveField.TrackedEnemy.Distance);
            this.Owner.Execute();
        }
    }
}