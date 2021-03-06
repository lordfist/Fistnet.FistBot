﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fistnet.FistBot.Bot;

namespace Fistnet.FistBot.Actions
{
    public class Fire2 : ActionBase
    {
        public Fire2(BotBase owner)
            : base(owner)
        {
        }

        public override ActionTypeEnum ActionType
        {
            get { return ActionTypeEnum.Fire2; }
        }

        public override void Execute(double errorChance)
        {
            if (this.Owner.GunHeat == 0 && Math.Abs(this.Owner.GunTurnRemaining) < 10)
                this.Owner.Fire(2);
            else
                this.Owner.DoNothing();
        }
    }
}