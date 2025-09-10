using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BayatGames.SaveGameFree;

public class Load : MonoBehaviour {

    public static void LoadAll() {
        LoadWurfmesser();
        LoadLeben();
        LoadAmmo();
        LoadCoin();
        LoadLevel();
        LoadPosition();
        LoadSlimeKills();
        LoadHighscore();
        LoadSchwert();
        LoadStatKills();
        LoadStats();
        LoadSpawnedEnemys();
        LoadDash();
        LoadDashFreigeschaltet();
        LoadWurfmesserFreigeschaltet();
        LoadSpeed();
        LoadMuniDrop();
        LoadGeldDrop();
        LoadAllDrop();
        LoadAdditionalDropChance();
        LoadMehrfachschuss();
    }

    public static int LoadWurfmesser() {
        if(Check("Wurfmesser")) {
            return SaveGame.Load<int>("Wurfmesser");
        }
        return 0;
    }

    public static int LoadLeben() {
        if(Check("Leben")) {
            return SaveGame.Load<int>("Leben");
        }
        return 0;
    }

    public static int LoadAmmo() {
        if(Check("Ammo")) {
            return SaveGame.Load<int>("Ammo");
        }
        return 0;
    }

    public static int LoadCoin() {
        if(Check("Coin")) {
            return SaveGame.Load<int>("Coin");
        }
        return 0;
    }

    public static int LoadLevel() {
        if(Check("Level")) {
            return SaveGame.Load<int>("Level");
        }
        return 0;
    }

     public static Vector2 LoadPosition() { 
        if(Check("PlayerPos")) {
            return SaveGame.Load<Vector2>("PlayerPos");
        }
        return LoadPosition();
    } 

    public static int LoadSlimeKills() {
        if(Check("SlimeKills")) {
            return SaveGame.Load<int>("SlimeKills");
        } 
        return 0;
    }

    public static int LoadHighscore() {
        if(Check("Highscore")) {
            return SaveGame.Load<int>("Highscore");
        }
        return 0;
    }

    public static bool LoadSchwert() {
        if(Check("Schwert")) {
            return SaveGame.Load<bool>("Schwert");
        }
        return true;
    }

    public static int LoadDash() {
        if(Check("Dash")) {
            return SaveGame.Load<int>("Dash");
        } 
        return 0;
    }

    public static bool LoadDashFreigeschaltet() {
        if(Check("DashFreigeschaltet")) {
            return SaveGame.Load<bool>("DashFreigeschaltet");
        }
        return false;
    }

    public static bool LoadWurfmesserFreigeschaltet() {
        if(Check("WurfmesserFreigeschaltet")) {
            return SaveGame.Load<bool>("WurfmesserFreigeschaltet");
        }
        return false;
    }

    public static float LoadSpeed() {
        if(Check("Speed")) {
            return SaveGame.Load<float>("Speed");
        }
        return BasisPlayer.speed;
    }

    public static int LoadMuniDrop() {
        if(Check("MuniDrop")) {
            return SaveGame.Load<int>("MuniDrop");
        } 
        return 1;
    }

    public static int LoadGeldDrop() {
        if(Check("GeldDrop")) {
            return SaveGame.Load<int>("GeldDrop");
        } 
        return 1;
    }

    public static bool LoadAllDrop() {
        if(Check("AllDrop")) {
            return SaveGame.Load<bool>("AllDrop");
        }
        return false;
    }

    public static int LoadAdditionalDropChance() {
        if(Check("DropChance")) {
            return SaveGame.Load<int>("AdditionalDropChance");
        }
        return 0;
    }

    public static int LoadMehrfachschuss() {
        if(Check("Mehrfachschuss")) {
            return SaveGame.Load<int>("Mehrfachschuss");
        }
        return 1;
    }

    public static Dictionary<string, int> LoadStatKills() {
        if(Check("StatKills")) {
            return SaveGame.Load<Dictionary<string, int>>("StatKills");
        }
        return null;
    } 

    


    public static Dictionary<string, int> LoadStats() {
        if(Check("Stats")) {
            return SaveGame.Load<Dictionary<string, int>>("Stats");
        } 
        return new Dictionary<string, int>();
    }

    public static bool Check(string fileName) {
       return SaveGame.Exists(fileName);
    }


[Header("Prefabs")]
public GameObject DiscoZombiePrefab;
public GameObject GoblinPrefab;
public GameObject ZombiePrefab;
public GameObject HexePrefab;
public GameObject SkelettPrefab;
public GameObject SlimePrefab;
public GameObject KSlimePrefab;
public GameObject SlimeBossPrefab;
public GameObject BaumPrefab;
private static Dictionary<string, GameObject> enemyPrefabs;


void Awake() {
        enemyPrefabs = new Dictionary<string, GameObject> {
            {"DiscoZombie", DiscoZombiePrefab},
            {"Zombie", ZombiePrefab},
            {"Goblin", GoblinPrefab},
            {"Hexe", HexePrefab},
            {"Skelett", SkelettPrefab},
            {"Slime", SlimePrefab},
            {"KSlime", KSlimePrefab},
            {"SlimeBoss", SlimeBossPrefab},
            {"Baum", BaumPrefab}
        };
    }


    public static Dictionary<string, List<Vector2>> LoadSpawnedEnemys() {
        if(Check("SpawnedEnemys")) {
            Dictionary<string, List<Vector2>> spawnedEnemys = SaveGame.Load<Dictionary<string, List<Vector2>>>("SpawnedEnemys");
            foreach(string enemyType in spawnedEnemys.Keys) {
                if(enemyPrefabs.ContainsKey(enemyType)) {
                    foreach(Vector2 position in spawnedEnemys[enemyType]) {
                        Instantiate(enemyPrefabs[enemyType], position, Quaternion.identity);
                    }
                }
            }
        }
        return new Dictionary<string, List<Vector2>>();
    }


    void Start() {
        if(Menü.IsLoaded) {
            LoadSpawnedEnemys();
        }
    }
}