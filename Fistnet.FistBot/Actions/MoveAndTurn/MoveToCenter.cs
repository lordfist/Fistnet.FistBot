using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fistnet.FistBot.Bot;

namespace Fistnet.FistBot.Actions
{
    public class MoveToCenter : ActionBase
    {
        public MoveToCenter(BotBase owner)
            : base(owner)
        {
        }

        public override ActionTypeEnum ActionType
        {
            get { return ActionTypeEnum.MoveToCenter; }
        }

        public override void Execute(double errorChance)
        {
            double xmid = this.Owner.BattleFieldWidth / 2;
            double ymid = this.Owner.BattleFieldHeight / 2;
            double absBearingToCenter = this.Owner.GetAbsolutBearingFromPoint(new PointD(xmid, ymid));
            double turn = absBearingToCenter - this.Owner.Heading;
            this.Owner.SetTurnRight(turn.NormalizeBearing());
            this.Owner.SetAhead(this.Owner.GetMyPosition().CalculateDistance(new PointD(xmid, ymid)));
            this.Owner.Execute();
        }
    }
}