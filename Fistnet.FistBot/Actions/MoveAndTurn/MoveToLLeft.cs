using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fistnet.FistBot.Bot;

namespace Fistnet.FistBot.Actions
{
    public class MoveToLLeft : ActionBase
    {
        public MoveToLLeft(BotBase owner)
            : base(owner)
        {
        }

        public override ActionTypeEnum ActionType
        {
            get { return ActionTypeEnum.MoveToLLeft; }
        }

        public override void Execute(double errorChance)
        {
            double absBearingToPt = this.Owner.GetAbsolutBearingFromPoint(new PointD(GlobalConstants.BOT_HALF_SIZE * 2, GlobalConstants.BOT_HALF_SIZE * 2));
            double turn = absBearingToPt - this.Owner.Heading;
            this.Owner.SetTurnRight(turn.NormalizeBearing());
            this.Owner.SetAhead(this.Owner.GetMyPosition().CalculateDistance(new PointD(GlobalConstants.BOT_HALF_SIZE * 2, GlobalConstants.BOT_HALF_SIZE * 2)));
            this.Owner.Execute();
        }
    }
}