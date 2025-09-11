using UnityEngine;
using UnityEngine.UI;

public class Hotbar : MonoBehaviour {
    public int maxSlots = 4;                 // max 4 Items gleichzeitig
    public Item[] slots;                     // feste Größe = maxSlots
    public Image[] slotImages;               // UI-Slots (muss size == maxSlots sein)
    public GameObject itemHolder;
    private GameObject equippedItem;
    public int activeSlot = -1;

    void Awake() {
        if (slots == null || slots.Length != maxSlots) {
            slots = new Item[maxSlots];
        }
    }

    void Start() {
        if (itemHolder == null) {
            itemHolder = new GameObject("ItemHolder");
            itemHolder.transform.SetParent(transform, false);
        }

        if (slotImages != null && slotImages.Length != maxSlots) {
            Debug.LogWarning($"Hotbar: slotImages.Length ({slotImages.Length}) != maxSlots ({maxSlots}). Bitte anpassen.");
        }

        UpdateUI();
    }

    // Aufnahme eines Items: fülle erstes freie Feld
    public bool PickupItem(Item item) {
        for (int i = 0; i < maxSlots; i++) {
            if (slots[i] == null) {
                slots[i] = item;
                Debug.Log($"Hotbar: '{item.itemName}' in Slot {i} aufgenommen.");
                UpdateUI();
                if (activeSlot == -1) SelectSlot(i);
                return true; // Erfolg
            }
        }
        Debug.Log("Hotbar voll!");
        return false; // kein Platz
    }

    public void UpdateUI() {
        for (int i = 0; i < slotImages.Length; i++) {
            if (i < slots.Length && slots[i] != null) {
                slotImages[i].sprite = slots[i].icon;
                slotImages[i].enabled = true;
            } else {
                slotImages[i].sprite = null;
                slotImages[i].enabled = false;
            }
        }
    }

    public void SelectSlot(int index) {
        if (index < 0 || index >= maxSlots) return;

        activeSlot = index;

        if (equippedItem != null) Destroy(equippedItem);

        if (slots[index] != null && slots[index].prefab != null) {
            // Instantiate at player, not under UI
            Transform player = GameObject.FindGameObjectWithTag("Player").transform;

            GameObject swordHolder = GameObject.Find("swordHolder");
            if (swordHolder == null) {
                swordHolder = new GameObject("swordHolder");
                swordHolder.transform.SetParent(player);
            }

            equippedItem = Instantiate(slots[index].prefab, swordHolder.transform);
            equippedItem.transform.localPosition = Vector3.zero;

            Debug.Log($"Hotbar: '{slots[index].itemName}' equipped in slot {index}");
        } else {
            Debug.Log($"Hotbar: Slot {index} leer oder kein Prefab.");
        }
    }

    void Update() {
        KeyCode[] keys = { KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4 };
        for (int i = 0; i < keys.Length; i++) {
            if (Input.GetKeyDown(keys[i])) {
                if (i < maxSlots) SelectSlot(i);
            }
        }
    }
}