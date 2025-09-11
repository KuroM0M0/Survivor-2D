using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using BayatGames.SaveGameFree;

public class Menü : MonoBehaviour
{

    public TMP_Text HighscoreMenü;
    public TMP_Text PauseAus;

    //Auflösung
    [SerializeField] private TMP_Dropdown resolutionDropdown;
    private Resolution[] resolutions;
    private List<Resolution> filteredResolutions;
    private float currentRefreshRate;
    private int currentResolutionIndex = 0;

    //Laden
    public static bool IsLoaded = false;
    public GameObject LoadButton;
    private int LebenFürButton; //regelt ob Laden Button im Menü angezeigt wird oder nicht

    void Start() {
        LebenFürButton = Load.LoadLeben();

        if(resolutionDropdown == null) {
            return;
        }
        resolutions = Screen.resolutions;
        filteredResolutions = new List<Resolution>();
        //resolutionDropdown.ClearOptions();
        currentRefreshRate = Screen.currentResolution.refreshRate;

        for(int i = 0; i < resolutions.Length; i++) {
            if(resolutions[i].refreshRate == currentRefreshRate) {
                filteredResolutions.Add(resolutions[i]);
            }
        }

        List<string> options = new List<string>();
        for(int i = 0; i < filteredResolutions.Count; i++) {
            string resolutionOption = filteredResolutions[i].width + "x" + filteredResolutions[i].height + " " + filteredResolutions[i].refreshRate + " Hz";
            options.Add(resolutionOption);
            if(filteredResolutions[i].width == Screen.width && filteredResolutions[i].height == Screen.height) {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        HighscoreMenü.text = "Highscore: " + Load.LoadHighscore();
    }

    public void SetResolution(int resolutionIndex) {
        Resolution resolution = filteredResolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, true);
    }

    void Update() {
        if (LoadButton != null) {
            if (LebenFürButton <= 0) {
                LoadButton.SetActive(false);
            } else {
                LoadButton.SetActive(true);
            }
        }
    }

    public void OnStart() {
        SceneManager.LoadScene("Game");
        Highscore.score = 0;
        Schuss.ammo = 24;
        Leben.health = 3;
        Wurfmesser.wurfmesserAnzahl = 3;
        Time.timeScale = 1f;
        Pause.pausiert = false;
        ItemEinfrieren.eingefroren = false;
        Save.SaveLeben();
        Save.SaveAmmo();
        Save.SaveWurfmesser();
    }

    public void OnMenu() {
        Save.SaveAll();
        SceneManager.LoadScene("Hauptmenü");
        IsLoaded = false;
    }

    public void OnQuit() {
        Save.SaveAll();
        Application.Quit();
    }

   public void OnTutorial() {
    SceneManager.LoadScene("Tutorial");
   }

   public void OnLoad() {
    SceneManager.LoadScene("Game");
    Schuss.ammo = Load.LoadAmmo();
    Leben.health = Load.LoadLeben();
    Wurfmesser.wurfmesserAnzahl = Load.LoadWurfmesser();
    Bewegung.PlayerPos = Load.LoadPosition();
    Load.LoadSpawnedEnemys();
    IsLoaded = true;
    Pause.pausiert = false;
   }
}