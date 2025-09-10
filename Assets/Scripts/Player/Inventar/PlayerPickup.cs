using UnityEngine;

public class PlayerPickup : MonoBehaviour {
    [SerializeField] private Hotbar hotbar;

    private void OnTriggerStay2D(Collider2D other) {
        if (Input.GetKeyDown(KeyCode.E)) {
            Pickup pickup = other.GetComponent<Pickup>();
            if (pickup != null && pickup.itemData != null) {
                Debug.Log("Pickup erkannt: " + pickup.itemData.itemName);
                hotbar.PickupItem(pickup.itemData);
                Destroy(other.gameObject);
            } else {
                Debug.Log("Pickup oder ItemData fehlt auf " + other.name);
            }
        }
    }
}