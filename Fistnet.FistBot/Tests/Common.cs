using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fistnet.FistBot.Tests
{
    public enum TestTypeEnum
    {
        TestEnemyEnergy0 = 0,
        TestEnemyEnergyBelow10 = 1,
        TestEnergyBelow10 = 2,
        TestEnergyGreaterThanEnemy = 3,
        TestEnergyLesserThanEnemy = 4,
        TestEnemyWithin10 = 5,
        TestEnemyWithin50 = 6,
        TestEnemyWithin100 = 7,
        TestEnemyHeadingWithin10 = 8,
        TestEnemyHeadingWithin90 = 9,
        TestGunIsHot = 10,
        TestEnemyGunTurnWithin10 = 11,
        TestEnemyGunTurnWithin5 = 12,
        TestEnemyRadarTurnWithin20 = 13,
        TestEnemyRadarTurnWithin60 = 14,
        TestEnemyGunTurnOppositeWithin20 = 15,
        TestFire1DistanceCapable = 16,
        TestFire2DistanceCapable = 17,
        TestFire3DistanceCapable = 18,
        TestFire1DistanceWithin10 = 19,
        TestFire3DistanceWithin10 = 20,
        TestFire1DistanceWithin5 = 21,
        TestFire2DistanceWithin10 = 22,
        TestFire2DistanceWithin5 = 23,
        TestEnemyGunIsHot = 24,
        TestOthersMoreThan1 = 25,
        TestEnergyBelow30 = 26,
        TestEnemyHeadingOppositeWithin20 = 27,
        TestFire3DistanceWithin5 = 28
    }

    public static class Common
    {
        public const byte TEST_COUNT = 29;
        public const long MAX_TIME_DISTANCE_TEST = 30;
    }
}