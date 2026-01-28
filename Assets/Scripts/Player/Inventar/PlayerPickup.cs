using UnityEngine;

public class PlayerPickup : MonoBehaviour {
    [SerializeField] private Hotbar hotbar;
    private Pickup nearbyPickup;

    private void OnTriggerEnter2D(Collider2D other) {
        Pickup pickup = other.GetComponent<Pickup>();
        if (pickup != null && pickup.itemData != null) {
            nearbyPickup = pickup;
            //Debug.Log($"Item in Reichweite: {pickup.itemData.itemName}");
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        Pickup pickup = other.GetComponent<Pickup>();
        if (pickup != null && pickup == nearbyPickup) {
            nearbyPickup = null;
            //Debug.Log("Pickup nicht mehr in Reichweite");
        }
    }

    private void Update() {
        if (nearbyPickup != null && Input.GetKeyDown(KeyCode.E)) {
            if (hotbar == null) {
                Debug.LogError("PlayerPickup: hotbar reference ist nicht gesetzt!");
                return;
            }
            Debug.Log("Pickup erkannt: " + nearbyPickup.itemData.itemName);
            if(nearbyPickup.itemData.itemName == "Schwert") {
                BasisPlayer.hatSchwert = true;
            }

            bool aufgenommen = hotbar.PickupItem(nearbyPickup.itemData);
            if (aufgenommen) {
                Destroy(nearbyPickup.gameObject);
                nearbyPickup = null;
            } else {
                Debug.Log("Konnte Item nicht aufnehmen, Inventar ist voll!");
            }
        }
    }
}