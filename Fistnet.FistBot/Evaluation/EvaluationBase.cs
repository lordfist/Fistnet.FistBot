using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fistnet.FistBot.Actions;
using Fistnet.FistBot.Bot;
using Fistnet.FistBot.Tests;

namespace Fistnet.FistBot.Evaluation
{
    public abstract class EvaluationBase
    {
        #region Public properties.

        public abstract EvaluationTypeEnum EvalType { get; }

        public BotBase Owner { get; private set; }

        public TestBase Test { get; private set; }

        public ActionBase Action { get; private set; }

        public ActionBase AlternateAction { get; private set; }

        public byte? JumpIndex { get; private set; }

        public byte? AlternateJumpIndex { get; private set; }

        public byte Index { get; private set; }

        public byte? NextIndex
        {
            get;
            private set;
        }

        public double ErrorChance
        {
            get
            {
                return (double)(this.Index % 10) / 10.0;
            }
        }

        #endregion Public properties.

        #region Constructor.

        public EvaluationBase(BotBase owner, TestBase test, ActionBase action, ActionBase alternateAction, byte? jumpIdx, byte? alternateJumpIdx, byte index)
        {
            this.Owner = owner;
            this.Test = test;
            this.Action = action;
            this.AlternateAction = alternateAction;
            this.Index = index;
            if (index != jumpIdx)
                this.JumpIndex = jumpIdx;

            if (index != alternateJumpIdx)
                this.AlternateJumpIndex = alternateJumpIdx;
        }

        #endregion Constructor.

        #region TestAndExecute

        protected abstract bool ApplyCondition(bool testResult);

        public void TestAndExecute()
        {
            if (ApplyCondition(this.Test.Evaluate()))
            {
                if (this.Action != null)
                {
                    this.Action.Execute(this.ErrorChance);
                    this.NextIndex = this.Index++;
                    if (this.NextIndex >= GlobalConstants.DNA_SIZE)
                        this.NextIndex = 0;
                }
                else if (this.JumpIndex.HasValue)
                {
                    this.NextIndex = this.JumpIndex.Value;
                }
                else
                    this.Owner.DoNothing();
            }
            else
            {
                if (this.AlternateAction != null)
                {
                    this.AlternateAction.Execute(this.ErrorChance);
                    this.NextIndex = this.Index++;
                    if (this.NextIndex >= GlobalConstants.DNA_SIZE)
                        this.NextIndex = 0;
                }
                else if (this.AlternateJumpIndex.HasValue)
                {
                    this.NextIndex = this.AlternateJumpIndex.Value;
                }
                else
                    this.Owner.DoNothing();
            }
        }

        #endregion TestAndExecute
    }
}