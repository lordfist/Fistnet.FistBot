using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fistnet.FistBot.Bot;

namespace Fistnet.FistBot.Actions
{
    public class MoveAhead50Left90 : ActionBase
    {
        public MoveAhead50Left90(BotBase owner)
            : base(owner)
        {
        }

        public override ActionTypeEnum ActionType
        {
            get { return ActionTypeEnum.MoveAhead50Left90; }
        }

        public override void Execute(double errorChance)
        {
            this.Owner.SetAhead(50 - 50 * errorChance);
            this.Owner.SetTurnLeft(90 - 90 * errorChance);
            this.Owner.Execute();
        }
    }
}