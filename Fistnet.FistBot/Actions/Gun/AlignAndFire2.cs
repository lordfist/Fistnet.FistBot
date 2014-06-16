using Fistnet.FistBot.Bot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fistnet.FistBot.Actions
{
    public class AlignAndFire2 : ActionBase
    {
        public AlignAndFire2(BotBase owner)
            : base(owner)
        {
        }

        public override ActionTypeEnum ActionType
        {
            get { return ActionTypeEnum.AlignAndFire2; }
        }

        public override void Execute(double errorChance)
        {
            if (this.Owner.ActiveField.TrackedEnemy == null)
            {
                this.Owner.Fire(2);
                return;
            }

            double? turn = this.Owner.LinearRightTurnToFire(this.Owner.ActiveField.TrackedEnemy, 1);
            if (turn.HasValue)
            {
                this.Owner.TurnGunRight(turn.Value.NormalizeBearing());
                this.Owner.Fire(2);
            }
            else
            {
                double absBearingToEnemy = this.Owner.GetAbsolutBearingFromPoint(this.Owner.GetEnemyPositionWithPrediction(this.Owner.ActiveField.TrackedEnemy));
                turn = absBearingToEnemy - this.Owner.GunHeading;
                this.Owner.TurnGunRight(turn.Value.NormalizeBearing());
                this.Owner.Fire(2);
            }
        }
    }
}