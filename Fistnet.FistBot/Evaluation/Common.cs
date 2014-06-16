using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fistnet.FistBot.Evaluation
{
    public enum EvaluationTypeEnum
    {
        True = 0,
        JumpTrue = 1,
        JumpFalse = 2,
        JumpIf = 3
    }

    public static class Common
    {
        public const byte EVALUATION_COUNT = 4;
    }
}