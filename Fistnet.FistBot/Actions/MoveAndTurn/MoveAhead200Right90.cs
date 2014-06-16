using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fistnet.FistBot.Bot;

namespace Fistnet.FistBot.Actions
{
    public class MoveAhead200Right90 : ActionBase
    {
        public MoveAhead200Right90(BotBase owner)
            : base(owner)
        {
        }

        public override ActionTypeEnum ActionType
        {
            get { return ActionTypeEnum.MoveAhead200Right90; }
        }

        public override void Execute(double errorChance)
        {
            this.Owner.SetAhead(200 - 200 * errorChance);
            this.Owner.SetTurnRight(90 - 90 * errorChance);
            this.Owner.Execute();
        }
    }
}