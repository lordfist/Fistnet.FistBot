using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Robocode;

namespace Fistnet.FistBot.FieldData
{
    public class ObservedWall
    {
        public long Time { get; private set; }

        public double Bearing { get; private set; }

        public double BearingRadians { get; private set; }

        public ObservedWall(HitWallEvent wall)
        {
            this.Time = wall.Time;
            this.Bearing = wall.Bearing;
            this.BearingRadians = wall.BearingRadians;
        }
    }
}