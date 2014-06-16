using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fistnet.FistBot.Bot;

namespace Fistnet.FistBot.Actions
{
    public class TurnAwayFromCenter : ActionBase
    {
        public TurnAwayFromCenter(BotBase owner)
            : base(owner)
        {
        }

        public override ActionTypeEnum ActionType
        {
            get { return ActionTypeEnum.TurnAwayFromCenter; }
        }

        public override void Execute(double errorChance)
        {
            double xmid = this.Owner.BattleFieldWidth / 2;
            double ymid = this.Owner.BattleFieldHeight / 2;
            double absBearingToCenter = this.Owner.GetAbsolutBearingFromPoint(new PointD(xmid, ymid));
            double turn = absBearingToCenter - this.Owner.Heading;

            turn = turn.NormalizeBearing();

            if (turn > 0)
                turn = turn - 180;
            else
                turn = turn + 180;

            this.Owner.TurnRight(turn);
        }
    }
}