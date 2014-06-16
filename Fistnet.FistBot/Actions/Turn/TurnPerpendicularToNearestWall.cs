using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fistnet.FistBot.Bot;

namespace Fistnet.FistBot.Actions
{
    public class TurnPerpendicularToNearestWall : ActionBase
    {
        public TurnPerpendicularToNearestWall(BotBase owner)
            : base(owner)
        {
        }

        public override ActionTypeEnum ActionType
        {
            get { return ActionTypeEnum.TurnPerpendicularToNearestWall; }
        }

        public override void Execute(double errorChance)
        {
            double xmid = this.Owner.BattleFieldWidth / 2;
            double ymid = this.Owner.BattleFieldHeight / 2;

            double absDistX = Math.Abs(xmid - this.Owner.X);
            double absDistY = Math.Abs(ymid - this.Owner.Y);

            double turn = 0;

            if (absDistX <= absDistY)
            {
                double absBearingToPoint = this.Owner.GetAbsolutBearingFromPoint(new PointD(xmid, this.Owner.Y));
                turn = absBearingToPoint - this.Owner.Heading;
            }
            else
            {
                double absBearingToPoint = this.Owner.GetAbsolutBearingFromPoint(new PointD(this.Owner.X, ymid));
                turn = absBearingToPoint - this.Owner.Heading;
            }

            turn = turn.NormalizeBearing();
            if (turn > 0)
                turn = turn - 90;
            else
                turn = turn + 90;
            this.Owner.TurnRight(turn);
        }
    }
}