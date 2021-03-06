﻿using Fistnet.FistBot.Bot;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fistnet.FistBot.Actions
{
    public class BackDistanceToCenter : ActionBase
    {
        public BackDistanceToCenter(BotBase owner)
            : base(owner)
        {
        }

        public override ActionTypeEnum ActionType
        {
            get { return ActionTypeEnum.BackDistanceToCenter; }
        }

        public override void Execute(double errorChance)
        {
            PointD myPosition = Common.GetMyPosition(this.Owner);
            PointD centerPosition = Common.GetCenterPosition(this.Owner);

            double moveDistance = myPosition.CalculateDistance(centerPosition);

            this.Owner.Back(moveDistance - moveDistance * errorChance);
        }
    }
}