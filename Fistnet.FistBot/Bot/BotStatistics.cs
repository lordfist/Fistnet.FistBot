using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fistnet.FistBot.Bot
{
    public class BotStatistics
    {
        public const string ROBOT_STATS_FILE_NAME = "stats.txt";

        public int BulletHit { get; set; }

        public int BulletMiss { get; set; }

        public int DeathAfterTicks { get; set; }

        public int SelfDamage { get; set; }

        public BotStatistics()
        {
            this.BulletHit = 0;
            this.BulletMiss = 0;
            this.DeathAfterTicks = -1;
            this.SelfDamage = 0;
        }

        private BotStatistics(int bulletHit, int bulletMiss, int deathAfterTicks, int selfDamage)
        {
            this.BulletHit = bulletHit;
            this.BulletMiss = bulletMiss;
            this.DeathAfterTicks = deathAfterTicks;
            this.SelfDamage = selfDamage;
        }

        public string Serialize()
        {
            return this.BulletHit.ToString() + ";" + this.BulletMiss.ToString() + ";" + this.DeathAfterTicks.ToString() + ";" + this.SelfDamage.ToString();
        }

        public static BotStatistics Deserialize(string data)
        {
            List<string> dataList = data.Split(new string[1] { ";" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            if (dataList.Count < 4)
                throw new FormatException("Data was not in correct format: " + data);

            return new BotStatistics(int.Parse(dataList[0]), int.Parse(dataList[1]), int.Parse(dataList[2]), int.Parse(dataList[3]));
        }

        public static List<BotStatistics> DeserializeList(string fullData)
        {
            List<BotStatistics> stats = new List<BotStatistics>();

            List<string> dataList = fullData.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            foreach (string data in dataList)
            {
                stats.Add(BotStatistics.Deserialize(data));
            }

            return stats;
        }
    }
}