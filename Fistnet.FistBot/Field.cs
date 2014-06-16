using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fistnet.FistBot.Bot;
using Fistnet.FistBot.FieldData;
using Robocode;

namespace Fistnet.FistBot
{
    public class Field
    {
        public StatusEvent TurnStatus { get; private set; }

        public ObservedWall LastWall { get; private set; }

        private string _tracking;

        public ObservedEnemy TrackedEnemy { get; private set; }

        public ObservedEnemy LastSeenEnemy { get; private set; }

        public ObservedBullet TrackedBullet { get; private set; }

        public ObservedBullet LastSeenBullet { get; private set; }

        public Dictionary<string, List<ObservedEnemy>> EnemyHistory { get; private set; }

        public Dictionary<string, List<ObservedBullet>> BulletHistory { get; private set; }

        public BotBase Owner { get; private set; }

        public Field(BotBase owner)
        {
            this.Owner = owner;
            this.EnemyHistory = new Dictionary<string, List<ObservedEnemy>>();
            this.BulletHistory = new Dictionary<string, List<ObservedBullet>>();
        }

        #region Private observe.

        private void ObservationAdd(ObservedEnemy enemy)
        {
            if (this.EnemyHistory.ContainsKey(enemy.Name))
                this.EnemyHistory[enemy.Name].Add(enemy);
            else
            {
                this.EnemyHistory.Add(enemy.Name, new List<ObservedEnemy>());
                this.EnemyHistory[enemy.Name].Add(enemy);
            }

            if (this._tracking == null || this._tracking == enemy.Name)
                this.TrackedEnemy = enemy;

            this.LastSeenEnemy = enemy;
            if (this.EnemyHistory[enemy.Name].Count > GlobalConstants.HISTORY_SIZE)
                this.EnemyHistory[enemy.Name].RemoveAt(this.EnemyHistory[enemy.Name].Count - 1);
        }

        private void ObservationAdd(ObservedBullet bullet)
        {
            if (this.BulletHistory.ContainsKey(bullet.Name))
                this.BulletHistory[bullet.Name].Add(bullet);
            else
            {
                this.BulletHistory.Add(bullet.Name, new List<ObservedBullet>());
                this.BulletHistory[bullet.Name].Add(bullet);
            }

            this.LastSeenBullet = bullet;
            if (this.BulletHistory[bullet.Name].Count > GlobalConstants.HISTORY_SIZE)
                this.BulletHistory[bullet.Name].RemoveAt(this.BulletHistory[bullet.Name].Count - 1);
        }

        #endregion Private observe.

        #region Public observers.

        public void Observe(BulletHitEvent bullet)
        {
            ObservationAdd(new ObservedBullet(bullet.Bullet, bullet.Time, this.Owner));
        }

        public void Observe(BulletHitBulletEvent bullet)
        {
            ObservationAdd(new ObservedBullet(bullet.Bullet, bullet.Time, this.Owner));
            ObservationAdd(new ObservedBullet(bullet.HitBullet, bullet.Time, this.Owner));
        }

        public void Observe(BulletMissedEvent bullet)
        {
            ObservationAdd(new ObservedBullet(bullet.Bullet, bullet.Time, this.Owner));
        }

        public void Observe(HitByBulletEvent bullet)
        {
            ObservationAdd(new ObservedBullet(bullet.Bullet, bullet.Time, this.Owner));
        }

        public void Observe(HitRobotEvent robot)
        {
            ObservationAdd(new ObservedEnemy(robot));
        }

        public void Observe(StatusEvent status)
        {
            this.TurnStatus = status;
        }

        public void Observe(ScannedRobotEvent robot)
        {
            ObservationAdd(new ObservedEnemy(robot));
        }

        public void Observe(HitWallEvent wall)
        {
            this.LastWall = new ObservedWall(wall);
        }

        #endregion Public observers.

        #region Tracking.

        public void SetTracking(string target)
        {
            this._tracking = target;
        }

        public void UnsetTracking()
        {
            this._tracking = null;
            this.TrackedEnemy = this.LastSeenEnemy;
            this.TrackedBullet = this.LastSeenBullet;
        }

        #endregion Tracking.
    }
}