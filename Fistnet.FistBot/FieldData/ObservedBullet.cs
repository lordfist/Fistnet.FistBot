using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fistnet.FistBot.Bot;
using Robocode;

namespace Fistnet.FistBot.FieldData
{
    public class ObservedBullet : Bullet
    {
        public static int BulletFiredCount { get; private set; }

        public static int MyBulletFiredCount { get; private set; }

        public static int EnemyBulletFiredCount { get; private set; }

        public static int EnemyBulletHitCount { get; private set; }

        public static int MyBulletHitCount { get; private set; }

        public long Time { get; private set; }

        public bool IsMine { get; private set; }

        public ObservedBullet(Bullet bullet, long time, BotBase me)
            : base(bullet.Heading, bullet.X, bullet.Y, bullet.Power, bullet.Name, bullet.Victim, bullet.IsActive, ObservedBullet.BulletFiredCount)
        {
            this.Time = time;
            ObservedBullet.BulletFiredCount++;

            this.IsMine = (me.Name == bullet.Name);

            if (this.IsMine)
                ObservedBullet.MyBulletFiredCount++;
            else
                ObservedBullet.EnemyBulletFiredCount++;

            if (bullet.Victim == me.Name)
                ObservedBullet.EnemyBulletHitCount++;
            else if (!string.IsNullOrWhiteSpace(bullet.Victim))
                ObservedBullet.MyBulletHitCount++;
        }
    }
}