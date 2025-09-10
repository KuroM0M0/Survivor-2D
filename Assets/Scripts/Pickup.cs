using UnityEngine;

public class Pickup : MonoBehaviour {
    public Item itemData;
    [SerializeField] private Hotbar hotbar;
    private void OnTriggerStay2D(Collider2D other) {
        if (Input.GetKeyDown(KeyCode.E)) {
            if (hotbar != null && itemData != null) {
                hotbar.PickupItem(itemData);
                Destroy(gameObject);
            }
        }
    }
}