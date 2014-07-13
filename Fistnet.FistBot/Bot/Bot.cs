using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fistnet.FistBot.Evaluation;
using Robocode;

namespace Fistnet.FistBot.Bot
{
    /// <summary>
    /// Strategies orederd by priority
    /// </summary>
    public enum StrategyEnum : byte
    {
        OnHitWall = 0,
        OnScannedRobot = 1,
        OnHitRobot = 2,
        OnHitByBullet = 3,
        OnBulletHit = 4,
        OnBulletMissed = 5,
        OnBulletHitBullet = 6,
        Default = 7
    }

    public abstract class BotBase : AdvancedRobot
    {
        public BotStatistics Statistics { get; private set; }

        public bool IsDead { get; private set; }

        public Field ActiveField { get; private set; }

        public Dictionary<StrategyEnum, List<EvaluationBase>> Evaluations { get; private set; }

        public virtual void Init(Dictionary<StrategyEnum, List<EvaluationBase>> strategies)
        {
            this.ActiveField = new Field(this);
            this.Evaluations = strategies;
            this.IsDead = false;
            this.Statistics = new BotStatistics();
        }

        #region Strategy events.

        public abstract void RequestChangeStrategy(StrategyEnum strategy);

        public override void OnBulletHit(BulletHitEvent evnt)
        {
            this.Statistics.BulletHit++;

            if (this.ActiveField != null)
                this.ActiveField.Observe(evnt);
            RequestChangeStrategy(StrategyEnum.OnBulletHit);
        }

        public override void OnBulletHitBullet(BulletHitBulletEvent evnt)
        {
            this.Statistics.BulletHit++;
            this.Statistics.SelfDamage += (int)evnt.Bullet.Power;

            if (this.ActiveField != null)
                this.ActiveField.Observe(evnt);

            RequestChangeStrategy(StrategyEnum.OnBulletHitBullet);
        }

        public override void OnBulletMissed(BulletMissedEvent evnt)
        {
            this.Statistics.BulletMiss++;
            this.Statistics.SelfDamage += (int)evnt.Bullet.Power;

            if (this.ActiveField != null)
                this.ActiveField.Observe(evnt);
            RequestChangeStrategy(StrategyEnum.OnBulletMissed);
        }

        public override void OnHitByBullet(HitByBulletEvent evnt)
        {
            this.Statistics.SelfDamage += evnt.Bullet.GetDamage();

            if (this.ActiveField != null)
                this.ActiveField.Observe(evnt);
            RequestChangeStrategy(StrategyEnum.OnHitByBullet);
        }

        public override void OnHitRobot(HitRobotEvent evnt)
        {
            this.Statistics.SelfDamage += 1;

            if (this.ActiveField != null)
                this.ActiveField.Observe(evnt);
            RequestChangeStrategy(StrategyEnum.OnHitRobot);
        }

        public override void OnHitWall(HitWallEvent evnt)
        {
            this.Statistics.SelfDamage += this.GetWallDamage();

            if (this.ActiveField != null)
                this.ActiveField.Observe(evnt);
            RequestChangeStrategy(StrategyEnum.OnHitWall);
        }

        public override void OnScannedRobot(ScannedRobotEvent evnt)
        {
            if (this.ActiveField != null)
                this.ActiveField.Observe(evnt);
            RequestChangeStrategy(StrategyEnum.OnScannedRobot);
        }

        #endregion Strategy events.

        #region Death.

        public override void OnDeath(DeathEvent evnt)
        {
            this.Statistics.DeathAfterTicks = (int)this.Time;
            this.IsDead = true;
        }

        #endregion Death.

        #region Statistical events.

        //public override void OnRobotDeath(RobotDeathEvent evnt)
        //{
        //    base.OnRobotDeath(evnt);
        //}

        public override void OnStatus(StatusEvent e)
        {
            if (this.ActiveField != null)
                this.ActiveField.Observe(e);
        }

        #endregion Statistical events.
    }
}