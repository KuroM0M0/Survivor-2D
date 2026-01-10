using UnityEngine;

public class WeaponHolder : MonoBehaviour {
    private Transform player;
    private GameObject swordHolder;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        swordHolder = new GameObject("swordHolder");
        swordHolder.transform.SetParent(player); // wichtig -> an den Player hängen
        swordHolder.transform.localPosition = Vector3.zero;
    }

    void Update() {
        if (swordHolder.transform.childCount == 0) return; // nichts equipped

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - player.position;

        // Position am Spieler ausrichten
        swordHolder.transform.position = player.position;

        // Rotation berechnen
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        swordHolder.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        // Flip, wenn Maus links ist
        if (angle > 90 || angle < -90) {
            swordHolder.transform.localScale = new Vector3(1, -1, 1);
        } else {
            swordHolder.transform.localScale = new Vector3(1, 1, 1);
        }

        // Offset nach vorne
        swordHolder.transform.position += swordHolder.transform.right * 0.35f;
    }
}