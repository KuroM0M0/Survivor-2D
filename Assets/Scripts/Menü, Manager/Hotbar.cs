using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hotbar : MonoBehaviour {
    public int maxSlots = 4;                 // max 4 Items gleichzeitig
    public List<Item> slots = new List<Item>(); // dynamisch
    public Image[] slotImages;               // UI-Slots
    public GameObject itemHolder;
    private GameObject equippedItem;
    public int activeSlot = -1;

    void Start() {
        if (itemHolder == null) {
            itemHolder = new GameObject("ItemHolder");
            itemHolder.transform.SetParent(transform, false);
        }
    }

    // Aufheben eines Items
    public void PickupItem(Item item) {
        if (slots.Count >= maxSlots) {
            Debug.Log("Hotbar voll!");
            return;
        }

        slots.Add(item);

        // UI aktualisieren
        UpdateUI();

        // aktiven Slot setzen, falls noch keiner aktiv
        if (activeSlot == -1) SelectSlot(0);
    }

    public void UpdateUI() {
        for (int i = 0; i < slotImages.Length; i++) {
            if (i < slots.Count && slots[i] != null) {
                slotImages[i].sprite = slots[i].icon;
                slotImages[i].enabled = true;
            } else {
                slotImages[i].sprite = null;
                slotImages[i].enabled = false;
            }
        }
    }

    public void SelectSlot(int index) {
        if (index < 0 || index >= slots.Count) return;

        activeSlot = index;

        if (equippedItem != null) Destroy(equippedItem);

        
        if (slots[index] != null && slots[index].prefab != null) {
            equippedItem = Instantiate(slots[index].prefab, itemHolder.transform);
            equippedItem.transform.localPosition = Vector3.zero;
        }
    }

    void Update() {
        KeyCode[] keys = { KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4 };
        for (int i = 0; i < slots.Count && i < keys.Length; i++) {
            if (Input.GetKeyDown(keys[i])) SelectSlot(i);
        }
    }
}