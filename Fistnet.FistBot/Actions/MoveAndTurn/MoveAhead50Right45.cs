using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fistnet.FistBot.Bot;

namespace Fistnet.FistBot.Actions
{
    public class MoveAhead50Right45 : ActionBase
    {
        public MoveAhead50Right45(BotBase owner)
            : base(owner)
        {
        }

        public override ActionTypeEnum ActionType
        {
            get { return ActionTypeEnum.MoveAhead50Right45; }
        }

        public override void Execute(double errorChance)
        {
            this.Owner.SetAhead(50 - 50 * errorChance);
            this.Owner.SetTurnRight(45 - 45 * errorChance);
            this.Owner.Execute();
        }
    }
}