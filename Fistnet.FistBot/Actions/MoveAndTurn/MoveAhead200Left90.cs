using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fistnet.FistBot.Bot;

namespace Fistnet.FistBot.Actions
{
    public class MoveAhead200Left90 : ActionBase
    {
        public MoveAhead200Left90(BotBase owner)
            : base(owner)
        {
        }

        public override ActionTypeEnum ActionType
        {
            get { return ActionTypeEnum.MoveAhead200Left90; }
        }

        public override void Execute(double errorChance)
        {
            this.Owner.SetAhead(200 - 200 * errorChance);
            this.Owner.SetTurnLeft(90 - 90 * errorChance);
            this.Owner.Execute();
        }
    }
}