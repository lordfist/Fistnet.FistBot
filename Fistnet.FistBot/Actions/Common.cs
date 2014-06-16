using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fistnet.FistBot.Bot;
using Fistnet.FistBot.FieldData;
using Robocode;

namespace Fistnet.FistBot.Actions
{
    public enum ActionTypeEnum : byte
    {
        Ahead50 = 0,
        AheadDistanceToCenter = 1,
        AheadDistanceToEnemy = 2,
        DoNothing = 3,
        AheadHalfDistanceToEnemy = 4,
        Back50 = 5,
        BackDistanceToCenter = 6,
        BackDistanceToEnemy = 7,
        TurnToCenter = 8,
        TurnAwayFromCenter = 9,
        TurnAwayFromEnemy = 10,
        TurnToEnemy = 11,
        TurnPerpendicularToEnemy = 12,
        TurnParallelToNearestWall = 13,
        TrackTarget = 14,
        TurnLeft90 = 15,
        TurnRight10 = 16,
        TurnRight90 = 17,
        MoveToCenter = 18,
        MoveToLLeft = 19,
        MoveToTLeft = 20,
        MoveToTRight = 21,
        MoveToLRight = 22,
        MoveToEnemy = 23,
        MoveAhead50Left45 = 24,
        MoveAhead50Left90 = 25,
        MoveAhead200Left45 = 26,
        MoveAhead200Right45 = 27,
        MoveAhead50Right90 = 28,
        MoveAhead50Right45 = 29,
        AlignAndFire1 = 30,
        TurnGunLeft5 = 31,
        TurnGunLeft10 = 32,
        TurnGunRight5 = 33,
        TurnGunRight10 = 34,
        TurnGunToBody = 35,
        TurnPerpendicularToNearestWall = 36,
        MovePerpendicularHalfToEnemy = 37,
        MoveAhead200Right90 = 38,
        MoveAhead200Left90 = 39,
        UntrackTarget = 40,
        TurnRadarLeft60 = 41,
        TurnRadarRight20 = 42,
        TurnRadarRight60 = 43,
        TurnRadarToBody = 44,
        TurnRadarToEnemy = 45,
        TurnRadarRightLeft60 = 46,
        TurnRadarRightLeft20 = 47,
        TurnRadarToGun = 48,
        AlignAndFire2 = 49,
        Fire05 = 50,
        Fire1 = 51,
        Fire2 = 52,
        Fire3 = 53,
        TurnGunToEnemy = 54,
        TurnLeft10 = 55,
        TurnRadarLeft20 = 56
    }

    public class PointD
    {
        public PointD(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double X { get; set; }

        public double Y { get; set; }
    }

    public static class Common
    {
        public const byte ACTION_COUNT = 57;

        public static double CalculateDistance(this PointD point, PointD otherPoint)
        {
            return Math.Sqrt(Math.Pow((otherPoint.X - point.X), 2) + Math.Pow((otherPoint.Y - point.Y), 2));
        }

        public static double Limit(this double value, double min, double max)
        {
            return Math.Min(max, Math.Max(min, value));
        }

        public static double GetClosestWallDistance(this BotBase me)
        {
            double battleFieldHeight, battleFieldWidth, centerX, centerY;

            battleFieldWidth = me.BattleFieldHeight;
            battleFieldHeight = me.BattleFieldWidth;
            centerX = battleFieldWidth / 2.0;
            centerY = battleFieldHeight / 2.0;

            if (me.ActiveField.TurnStatus.Status.X > centerX)
            {
                if (me.ActiveField.TurnStatus.Status.Y > centerY)
                    return Math.Min(battleFieldHeight - me.ActiveField.TurnStatus.Status.Y, battleFieldWidth - me.ActiveField.TurnStatus.Status.X);

                return Math.Min(me.ActiveField.TurnStatus.Status.Y, battleFieldWidth - me.ActiveField.TurnStatus.Status.X);
            }
            if (me.ActiveField.TurnStatus.Status.Y > centerY) return Math.Min(battleFieldHeight - me.ActiveField.TurnStatus.Status.Y, me.ActiveField.TurnStatus.Status.X);

            return Math.Min(me.ActiveField.TurnStatus.Status.Y, me.ActiveField.TurnStatus.Status.X);
        }

        public static PointD GetMyPosition(this BotBase bot)
        {
            return new PointD(bot.ActiveField.TurnStatus.Status.X + GlobalConstants.BOT_HALF_SIZE, bot.ActiveField.TurnStatus.Status.Y + GlobalConstants.BOT_HALF_SIZE);
        }

        public static double GetAbsolutBearingFromEnemy(this BotBase me, ObservedEnemy enemy)
        {
            double absBearingDeg = (me.ActiveField.TurnStatus.Status.Heading + enemy.Bearing);
            if (absBearingDeg < 0) absBearingDeg += 360;

            return absBearingDeg;
        }

        public static double NormalizeBearing(this double angle)
        {
            if (double.IsNaN(angle) || double.IsPositiveInfinity(angle) || double.IsNegativeInfinity(angle))
                angle = 0;

            while (angle > 180) angle -= 360;
            while (angle < -180) angle += 360;
            return angle;
        }

        public static double GetAbsolutBearingFromPoint(this BotBase me, PointD position)
        {
            double xo = position.X - me.ActiveField.TurnStatus.Status.X;
            double yo = position.Y - me.ActiveField.TurnStatus.Status.Y;
            double hyp = CalculateDistance(me.GetMyPosition(), position);
            double arcSin = Math.Asin(xo / hyp).ToDegrees();
            double bearing = 0;

            if (xo > 0 && yo > 0)
            { // both pos: lower-Left
                bearing = arcSin;
            }
            else if (xo < 0 && yo > 0)
            { // x neg, y pos: lower-right
                bearing = 360 + arcSin; // arcsin is negative here, actually 360 - ang
            }
            else if (xo > 0 && yo < 0)
            { // x pos, y neg: upper-left
                bearing = 180 - arcSin;
            }
            else if (xo < 0 && yo < 0)
            { // both neg: upper-right
                bearing = 180 - arcSin; // arcsin is negative here, actually 180 + ang
            }

            return bearing;
        }

        public static PointD GetMyFuturePosition(this BotBase me)
        {
            double x = me.ActiveField.TurnStatus.Status.X + me.DistanceRemaining * Math.Sin(me.Heading.ToRadians());
            double y = me.ActiveField.TurnStatus.Status.Y + me.DistanceRemaining * Math.Cos(me.Heading.ToRadians());
            return new PointD(x, y);
        }

        public static PointD GetEnemyPositionWithPrediction(this BotBase me, ObservedEnemy enemy)
        {
            double absBearingRad = me.GetAbsolutBearingFromEnemy(enemy).ToRadians();
            double enemyX = me.ActiveField.TurnStatus.Status.X + Math.Sin(absBearingRad) * enemy.Distance;
            double enemyY = me.ActiveField.TurnStatus.Status.Y + Math.Cos(absBearingRad) * enemy.Distance;

            long timeDistance = me.ActiveField.TurnStatus.Status.Time - enemy.Time;

            if (timeDistance < 10)
            {
                double enemyFutureX = enemyX + Math.Sin(me.ActiveField.TurnStatus.Status.Heading.ToRadians()) * me.ActiveField.TurnStatus.Status.Velocity * timeDistance;
                double enemyFutureY = enemyY + Math.Cos(me.ActiveField.TurnStatus.Status.Heading.ToRadians()) * me.ActiveField.TurnStatus.Status.Velocity * timeDistance;

                return new PointD(enemyFutureX, enemyFutureY);
            }

            return new PointD(enemyX, enemyY);
        }

        public static double? LinearLeftTurnToFire(this BotBase me, ObservedEnemy enemy, double firePower)
        {
            double? rightTurn = me.LinearRightTurnToFire(enemy, firePower);

            if (rightTurn.HasValue)
                return -1 * rightTurn.Value;
            else
                return null;
        }

        public static double? LinearRightTurnToFire(this BotBase me, ObservedEnemy enemy, double firePower)
        {
            double enemyHeadingRad = 0;

            if (enemy.HeadingRadians.HasValue)
                enemyHeadingRad = me.ActiveField.TurnStatus.Status.HeadingRadians;

            // Variables prefixed with e- refer to enemy, b- refer to bullet and r- refer to robot
            double eAbsBearing = me.ActiveField.TurnStatus.Status.HeadingRadians + enemy.BearingRadians;
            double rX = me.ActiveField.TurnStatus.Status.X, rY = me.ActiveField.TurnStatus.Status.Y, bV = Rules.GetBulletSpeed(firePower);
            double eX = rX + enemy.Distance * Math.Sin(eAbsBearing),
               eY = rY + enemy.Distance * Math.Cos(eAbsBearing),
               eV = enemy.Velocity,
               eHd = enemyHeadingRad;

            // These constants make calculating the quadratic coefficients below easier
            double A = (eX - rX) / bV;

            double B = eV / bV * Math.Sin(eHd);
            double C = (eY - rY) / bV;
            double D = eV / bV * Math.Cos(eHd);

            // Quadratic coefficients: a*(1/t)^2 + b*(1/t) + c = 0
            double a = A * A + C * C;

            double b = 2 * (A * B + C * D);
            double c = (B * B + D * D - 1);
            double discrim = b * b - 4 * a * c;
            if (discrim >= 0)
            {
                // Reciprocal of quadratic formula
                double t1 = 2 * a / (-b - Math.Sqrt(discrim));

                double t2 = 2 * a / (-b + Math.Sqrt(discrim));
                double t = Math.Min(t1, t2) >= 0 ? Math.Min(t1, t2) : Math.Max(t1, t2);

                // Assume enemy stops at walls
                double wallStopX = eX + eV * t * Math.Sin(eHd);
                double wallStopY = eY + eV * t * Math.Cos(eHd);

                double endX = wallStopX.Limit(GlobalConstants.BOT_HALF_SIZE, me.BattleFieldWidth - GlobalConstants.BOT_HALF_SIZE);
                double endY = wallStopY.Limit(GlobalConstants.BOT_HALF_SIZE, me.BattleFieldHeight - GlobalConstants.BOT_HALF_SIZE);

                return Robocode.Util.Utils.NormalRelativeAngle(Math.Atan2(endX - rX, endY - rY) - me.ActiveField.TurnStatus.Status.GunHeadingRadians);
            }

            return null;
        }

        public static PointD GetCenterPosition(BotBase bot)
        {
            return new PointD(bot.BattleFieldWidth / 2, bot.BattleFieldHeight / 2);
        }

        public static double ToRadians(this double val)
        {
            return (Math.PI / 180) * val;
        }

        public static double ToDegrees(this double val)
        {
            return val * (180 / Math.PI);
        }
    }
}