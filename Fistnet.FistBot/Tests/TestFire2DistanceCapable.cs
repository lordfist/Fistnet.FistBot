﻿using Fistnet.FistBot.Actions;
using Fistnet.FistBot.Bot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fistnet.FistBot.Tests
{
    public class TestFire2DistanceCapable : TestBase
    {
        public override TestTypeEnum TestType
        {
            get { return TestTypeEnum.TestFire2DistanceCapable; }
        }

        public override bool Evaluate()
        {
            bool eval = false;

            if (this.Owner.ActiveField.TrackedEnemy != null
                && (this.Owner.Time - this.Owner.ActiveField.TrackedEnemy.Time) < Common.MAX_TIME_DISTANCE_TEST)
            {
                eval = (this.Owner.ActiveField.TrackedEnemy.Distance / GlobalConstants.BULLET_VELOCITY_2) < Common.MAX_TIME_DISTANCE_TEST;
            }

            return eval;
        }

        public TestFire2DistanceCapable(BotBase owner)
            : base(owner)
        {
        }
    }
}