﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fistnet.FistBot.Actions;
using Fistnet.FistBot.Bot;
using Fistnet.FistBot.Tests;

namespace Fistnet.FistBot.Evaluation
{
    public class JumpIfCondition : EvaluationBase
    {
        public override EvaluationTypeEnum EvalType
        {
            get { return EvaluationTypeEnum.JumpIf; }
        }

        protected override bool ApplyCondition(bool testResult)
        {
            return true;
        }

        public JumpIfCondition(BotBase owner, TestBase test, ActionBase action, ActionBase alternateAction, byte? jumpIdx, byte? alternateJumpIdx, byte index)
            : base(owner, test, action, alternateAction, jumpIdx, alternateJumpIdx, index)
        {
        }
    }
}