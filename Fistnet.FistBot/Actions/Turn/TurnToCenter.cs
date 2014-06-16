using Fistnet.FistBot.Bot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fistnet.FistBot.Actions
{
    public class TurnToCenter : ActionBase
    {
        public TurnToCenter(BotBase owner)
            : base(owner)
        {
        }

        public override ActionTypeEnum ActionType
        {
            get { return ActionTypeEnum.TurnToCenter; }
        }

        public override void Execute(double errorChance)
        {
            double xmid = this.Owner.BattleFieldWidth / 2;
            double ymid = this.Owner.BattleFieldHeight / 2;
            double absBearingToCenter = this.Owner.GetAbsolutBearingFromPoint(new PointD(xmid, ymid));
            double turn = absBearingToCenter - this.Owner.Heading;
            this.Owner.TurnRight(turn.NormalizeBearing());
        }
    }
}