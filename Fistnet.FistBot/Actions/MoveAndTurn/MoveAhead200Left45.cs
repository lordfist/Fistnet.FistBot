using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fistnet.FistBot.Bot;

namespace Fistnet.FistBot.Actions
{
    public class MoveAhead200Left45 : ActionBase
    {
        public MoveAhead200Left45(BotBase owner)
            : base(owner)
        {
        }

        public override ActionTypeEnum ActionType
        {
            get { return ActionTypeEnum.MoveAhead200Left45; }
        }

        public override void Execute(double errorChance)
        {
            this.Owner.SetAhead(200 - 200 * errorChance);
            this.Owner.SetTurnLeft(45 - 45 * errorChance);
            this.Owner.Execute();
        }
    }
}