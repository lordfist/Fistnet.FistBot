using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fistnet.FistBot.Actions;
using Fistnet.FistBot.Bot;
using Fistnet.FistBot.Tests;

namespace Fistnet.FistBot
{
    public static class GlobalConstants
    {
        #region Constant.

        public const byte DNA_SIZE = 16;
        public const byte HISTORY_SIZE = 20;
        public const byte BOT_HALF_SIZE = 16;
        public const double BULLET_VELOCITY_1 = 17;
        public const double BULLET_VELOCITY_2 = 14;
        public const double BULLET_VELOCITY_3 = 11;
        public const byte DNA_STRANDS = 8;

        #endregion Constant.
    }

    public static class Factory
    {
        public static ActionBase CreateAction(BotBase owner, ActionTypeEnum actionType)
        {
            switch (actionType)
            {
                case ActionTypeEnum.Ahead50:
                    return new Ahead50(owner);

                case ActionTypeEnum.AheadDistanceToCenter:
                    return new AheadDistanceToCenter(owner);

                case ActionTypeEnum.AheadDistanceToEnemy:
                    return new AheadDistanceToEnemy(owner);

                case ActionTypeEnum.AheadHalfDistanceToEnemy:
                    return new AheadHalfDistanceToEnemy(owner);

                case ActionTypeEnum.Back50:
                    return new Back50(owner);

                case ActionTypeEnum.BackDistanceToCenter:
                    return new BackDistanceToCenter(owner);

                case ActionTypeEnum.BackDistanceToEnemy:
                    return new BackDistanceToEnemy(owner);

                case ActionTypeEnum.TurnToCenter:
                    return new TurnToCenter(owner);

                case ActionTypeEnum.TurnAwayFromCenter:
                    return new TurnAwayFromCenter(owner);

                case ActionTypeEnum.TurnAwayFromEnemy:
                    return new TurnAwayFromEnemy(owner);

                case ActionTypeEnum.TurnToEnemy:
                    return new TurnToEnemy(owner);

                case ActionTypeEnum.TurnPerpendicularToEnemy:
                    return new TurnPerpendicularToEnemy(owner);

                case ActionTypeEnum.TurnParallelToNearestWall:
                    return new TurnParallelToNearestWall(owner);

                case ActionTypeEnum.TurnLeft10:
                    return new TurnLeft10(owner);

                case ActionTypeEnum.TurnLeft90:
                    return new TurnLeft90(owner);

                case ActionTypeEnum.TurnRight10:
                    return new TurnRight10(owner);

                case ActionTypeEnum.TurnRight90:
                    return new TurnRight90(owner);

                case ActionTypeEnum.MoveToCenter:
                    return new MoveToCenter(owner);

                case ActionTypeEnum.MoveToLLeft:
                    return new MoveToLLeft(owner);

                case ActionTypeEnum.MoveToTLeft:
                    return new MoveToTLeft(owner);

                case ActionTypeEnum.MoveToTRight:
                    return new MoveToTRight(owner);

                case ActionTypeEnum.MoveToLRight:
                    return new MoveToLRight(owner);

                case ActionTypeEnum.MoveToEnemy:
                    return new MoveToEnemy(owner);

                case ActionTypeEnum.MoveAhead50Left45:
                    return new MoveAhead50Left45(owner);

                case ActionTypeEnum.MoveAhead50Left90:
                    return new MoveAhead50Left90(owner);

                case ActionTypeEnum.MoveAhead200Left45:
                    return new MoveAhead200Left45(owner);

                case ActionTypeEnum.MoveAhead200Right45:
                    return new MoveAhead200Right45(owner);

                case ActionTypeEnum.MoveAhead50Right90:
                    return new MoveAhead50Right90(owner);

                case ActionTypeEnum.MoveAhead50Right45:
                    return new MoveAhead50Right45(owner);

                case ActionTypeEnum.TurnGunToEnemy:
                    return new TurnGunToEnemy(owner);

                case ActionTypeEnum.TurnGunLeft5:
                    return new TurnGunLeft5(owner);

                case ActionTypeEnum.TurnGunLeft10:
                    return new TurnGunLeft10(owner);

                case ActionTypeEnum.TurnGunRight5:
                    return new TurnGunRight5(owner);

                case ActionTypeEnum.TurnGunRight10:
                    return new TurnGunRight10(owner);

                case ActionTypeEnum.TurnGunToBody:
                    return new TurnGunToBody(owner);

                case ActionTypeEnum.TurnPerpendicularToNearestWall:
                    return new TurnPerpendicularToNearestWall(owner);

                case ActionTypeEnum.MovePerpendicularHalfToEnemy:
                    return new MovePerpendicularHalfToEnemy(owner);

                case ActionTypeEnum.MoveAhead200Right90:
                    return new MoveAhead200Right90(owner);

                case ActionTypeEnum.MoveAhead200Left90:
                    return new MoveAhead200Left90(owner);

                case ActionTypeEnum.TurnRadarLeft20:
                    return new TurnRadarLeft20(owner);

                case ActionTypeEnum.TurnRadarLeft60:
                    return new TurnRadarLeft60(owner);

                case ActionTypeEnum.TurnRadarRight20:
                    return new TurnRadarRight20(owner);

                case ActionTypeEnum.TurnRadarRight60:
                    return new TurnRadarRight60(owner);

                case ActionTypeEnum.TurnRadarToBody:
                    return new TurnRadarToBody(owner);

                case ActionTypeEnum.TurnRadarToEnemy:
                    return new TurnRadarToEnemy(owner);

                case ActionTypeEnum.TurnRadarRightLeft60:
                    return new TurnRadarRightLeft60(owner);

                case ActionTypeEnum.TurnRadarRightLeft20:
                    return new TurnRadarRightLeft20(owner);

                case ActionTypeEnum.TurnRadarToGun:
                    return new TurnRadarToGun(owner);

                case ActionTypeEnum.AlignAndFire2:
                    return new AlignAndFire2(owner);

                case ActionTypeEnum.Fire05:
                    return new Fire05(owner);

                case ActionTypeEnum.Fire1:
                    return new Fire1(owner);

                case ActionTypeEnum.Fire2:
                    return new Fire2(owner);

                case ActionTypeEnum.Fire3:
                    return new Fire3(owner);

                case ActionTypeEnum.AlignAndFire1:
                    return new AlignAndFire1(owner);

                case ActionTypeEnum.TrackTarget:
                    return new TrackTarget(owner);

                case ActionTypeEnum.UntrackTarget:
                    return new UntrackTarget(owner);

                case ActionTypeEnum.DoNothing:
                    return new DoNothing(owner);

                default:
                    return null;
            }
        }

        public static TestBase CreateTest(BotBase owner, TestTypeEnum testType)
        {
            switch (testType)
            {
                case TestTypeEnum.TestEnemyEnergy0:
                    return new TestEnemyEnergy0(owner);

                case TestTypeEnum.TestEnemyEnergyBelow10:
                    return new TestEnemyEnergyBelow10(owner);

                case TestTypeEnum.TestEnergyBelow10:
                    return new TestEnergyBelow10(owner);

                case TestTypeEnum.TestEnergyGreaterThanEnemy:
                    return new TestEnergyGreaterThanEnemy(owner);

                case TestTypeEnum.TestEnergyLesserThanEnemy:
                    return new TestEnergyLesserThanEnemy(owner);

                case TestTypeEnum.TestEnemyWithin10:
                    return new TestEnemyWithin10(owner);

                case TestTypeEnum.TestEnemyWithin50:
                    return new TestEnemyWithin50(owner);

                case TestTypeEnum.TestEnemyWithin100:
                    return new TestEnemyWithin100(owner);

                case TestTypeEnum.TestEnemyHeadingWithin10:
                    return new TestEnemyHeadingWithin10(owner);

                case TestTypeEnum.TestEnemyHeadingWithin90:
                    return new TestEnemyHeadingWithin90(owner);

                case TestTypeEnum.TestGunIsHot:
                    return new TestGunIsHot(owner);

                case TestTypeEnum.TestEnemyGunTurnWithin10:
                    return new TestEnemyGunTurnWithin10(owner);

                case TestTypeEnum.TestEnemyGunTurnWithin5:
                    return new TestEnemyGunTurnWithin5(owner);

                case TestTypeEnum.TestEnemyRadarTurnWithin20:
                    return new TestEnemyRadarTurnWithin20(owner);

                case TestTypeEnum.TestEnemyRadarTurnWithin60:
                    return new TestEnemyRadarTurnWithin60(owner);

                case TestTypeEnum.TestEnemyGunTurnOppositeWithin20:
                    return new TestEnemyGunTurnOppositeWithin20(owner);

                case TestTypeEnum.TestFire1DistanceCapable:
                    return new TestFire1DistanceCapable(owner);

                case TestTypeEnum.TestFire2DistanceCapable:
                    return new TestFire2DistanceCapable(owner);

                case TestTypeEnum.TestFire3DistanceCapable:
                    return new TestFire3DistanceCapable(owner);

                case TestTypeEnum.TestFire1DistanceWithin10:
                    return new TestFire1DistanceWithin10(owner);

                case TestTypeEnum.TestFire3DistanceWithin10:
                    return new TestFire3DistanceWithin10(owner);

                case TestTypeEnum.TestFire1DistanceWithin5:
                    return new TestFire1DistanceWithin5(owner);

                case TestTypeEnum.TestFire2DistanceWithin10:
                    return new TestFire2DistanceWithin10(owner);

                case TestTypeEnum.TestFire2DistanceWithin5:
                    return new TestFire2DistanceWithin5(owner);

                case TestTypeEnum.TestFire3DistanceWithin5:
                    return new TestFire3DistanceWithin5(owner);

                case TestTypeEnum.TestEnemyGunIsHot:
                    return new TestEnemyGunIsHot(owner);

                case TestTypeEnum.TestOthersMoreThan1:
                    return new TestOthersMoreThan1(owner);

                case TestTypeEnum.TestEnergyBelow30:
                    return new TestEnergyBelow30(owner);

                case TestTypeEnum.TestEnemyHeadingOppositeWithin20:
                    return new TestEnemyHeadingOppositeWithin20(owner);

                default:
                    return null;
            }
        }
    }
}