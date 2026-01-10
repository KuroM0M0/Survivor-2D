[System.Serializable]
public class Stats {
    public PlayerStats playerStats = new();
    public CombatStats combatStats = new();
    public EnemyKillEntry enemyKillEntry = new();

    [System.Serializable]
    public class PlayerStats {
        public int level;
        public int health;
    }

    [System.Serializable]
    public class CombatStats {
        public int totalShotsFired;
        public int totalShotsHit;
        public int totalShotsMissed;
        public int totalDamageDealt;
        //public List<EnemyKillEntry> enemyKills = new List<EnemyKillEntry>();
    }

    [System.Serializable]
    public class EnemyKillEntry {
    public string enemyID;
    public int killCount;
    }
}