using UnityEngine;

[System.Serializable]
public class Item {
    public string itemName;
    public Sprite icon;
    public GameObject prefab; // Das "echte" Objekt, z. B. Schwert
}