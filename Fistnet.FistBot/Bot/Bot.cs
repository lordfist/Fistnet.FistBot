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
        public bool IsDead { get; private set; }

        public Field ActiveField { get; private set; }

        public Dictionary<StrategyEnum, List<EvaluationBase>> Evaluations { get; private set; }

        public virtual void Init(Dictionary<StrategyEnum, List<EvaluationBase>> strategies)
        {
            this.ActiveField = new Field(this);
            this.Evaluations = strategies;
            this.IsDead = false;
        }

        #region Strategy events.

        public abstract void RequestChangeStrategy(StrategyEnum strategy);

        public override void OnBulletHit(BulletHitEvent evnt)
        {
            if (this.ActiveField != null)
                this.ActiveField.Observe(evnt);
            RequestChangeStrategy(StrategyEnum.OnBulletHit);
        }

        public override void OnBulletHitBullet(BulletHitBulletEvent evnt)
        {
            if (this.ActiveField != null)
                this.ActiveField.Observe(evnt);
            RequestChangeStrategy(StrategyEnum.OnBulletHitBullet);
        }

        public override void OnBulletMissed(BulletMissedEvent evnt)
        {
            if (this.ActiveField != null)
                this.ActiveField.Observe(evnt);
            RequestChangeStrategy(StrategyEnum.OnBulletMissed);
        }

        public override void OnHitByBullet(HitByBulletEvent evnt)
        {
            if (this.ActiveField != null)
                this.ActiveField.Observe(evnt);
            RequestChangeStrategy(StrategyEnum.OnHitByBullet);
        }

        public override void OnHitRobot(HitRobotEvent evnt)
        {
            if (this.ActiveField != null)
                this.ActiveField.Observe(evnt);
            RequestChangeStrategy(StrategyEnum.OnHitRobot);
        }

        public override void OnHitWall(HitWallEvent evnt)
        {
            if (this.ActiveField != null)
                this.ActiveField.Observe(evnt);
            RequestChangeStrategy(StrategyEnum.OnHitWall);
        }

        public override void OnScannedRobot(ScannedRobotEvent evnt)
        {
            if (this.ActiveField != null)
                this.ActiveField.Observe(evnt);
            RequestChangeStrategy(StrategyEnum.OnHitWall);
        }

        #endregion Strategy events.

        #region Death.

        public override void OnDeath(DeathEvent evnt)
        {
            this.IsDead = true;
        }

        #endregion Death.

        #region Statistical events.

        //public override void OnBattleEnded(BattleEndedEvent evnt)
        //{
        //    base.OnBattleEnded(evnt);
        //}

        //public override void OnRobotDeath(RobotDeathEvent evnt)
        //{
        //    base.OnRobotDeath(evnt);
        //}

        //public override void OnRoundEnded(RoundEndedEvent evnt)
        //{
        //    base.OnRoundEnded(evnt);
        //}

        public override void OnStatus(StatusEvent e)
        {
            if (this.ActiveField != null)
                this.ActiveField.Observe(e);
        }

        #endregion Statistical events.
    }
}