using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using BayatGames.SaveGameFree;

public class Levelup : MonoBehaviour
{
    public static int Level = 0;
    bool LevelUp = false;
    public TMP_Text EpAnzeige;
    public TMP_Text LevelAnzeige;
    public List<int> LevelListe = new List<int>();
    
    void Start() {
        Level = Load.LoadLevel();
    } 

    void Update() {

        LevelListe.Add(50);
        LevelListe.Add(100);
        LevelListe.Add(200);
        LevelListe.Add(500);
        LevelListe.Add(1000);

        if(BasisEnemy.xp >= LevelListe[Level]) {
            BasisEnemy.xp = 0;
            LevelUp = true;
            LevelUpWait();
            LevelUp = false;
            Level++;
            Save.SaveLevel();

     /*   if(exp >= 50 && Level == 0) {
            exp = 0;
            LevelUp = true;
            LevelUpWait();
            LevelUp = false;
            PlayerPrefs.SetInt("Level", Level++);
        }
        if(exp >= 100 && Level == 1) {
            LevelUp = true;
            LevelUpWait();
            LevelUp = false;
            exp = 0;
            PlayerPrefs.SetInt("Level", Level++);
        }
        if(exp >= 200 && Level == 2) {
            exp = 0;
            LevelUp = true;
            LevelUpWait();
            LevelUp = false;
            PlayerPrefs.SetInt("Level", Level++);
        }
        if(exp >= 500 && Level == 3) {
            exp = 0;
            LevelUp = true;
            LevelUpWait();
            LevelUp = false;
            PlayerPrefs.SetInt("Level", Level++);
        }
        if(exp >= 1000 && Level == 4) {
            exp = 0;
            LevelUp = true;
            LevelUpWait();
            LevelUp = false;
            PlayerPrefs.SetInt("Level", Level++);
        }
    }       


    public void Level1() {
        if(LevelUp == true) {
            
        }
    } */

    IEnumerator LevelUpWait() {
        yield return new WaitForSeconds(2);
            }
        }
    }
}