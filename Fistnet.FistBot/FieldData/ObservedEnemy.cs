using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Robocode;

namespace Fistnet.FistBot.FieldData
{
    public class ObservedEnemy
    {
        public static int EnemyScanCount { get; private set; }

        public static int EnemyHitCount { get; private set; }

        public long Time { get; private set; }

        public string Name { get; private set; }

        public double Bearing { get; private set; }

        public double BearingRadians { get; private set; }

        public double Distance { get; private set; }

        public double Energy { get; private set; }

        public double? Heading { get; private set; }

        public double? HeadingRadians { get; private set; }

        public bool? IsSentryRobot { get; private set; }

        public double Velocity { get; private set; }

        public ObservedEnemy(ScannedRobotEvent scannedRobot)
        {
            this.Time = scannedRobot.Time;
            this.Name = scannedRobot.Name;
            this.Bearing = scannedRobot.Bearing;
            this.BearingRadians = scannedRobot.BearingRadians;
            this.Distance = scannedRobot.Distance;
            this.Energy = scannedRobot.Energy;
            this.Heading = scannedRobot.Heading;
            this.HeadingRadians = scannedRobot.HeadingRadians;
            this.IsSentryRobot = scannedRobot.IsSentryRobot;
            this.Velocity = scannedRobot.Velocity;
        }

        public ObservedEnemy(HitRobotEvent hitRobot)
        {
            this.Time = hitRobot.Time;
            this.Name = hitRobot.Name;
            this.Bearing = hitRobot.Bearing;
            this.BearingRadians = hitRobot.BearingRadians;
            this.Distance = 0;
            this.Energy = hitRobot.Energy;
            this.Heading = null;
            this.HeadingRadians = null;
            this.IsSentryRobot = null;
            this.Velocity = 0;
        }
    }
}