using UnityEngine.EventSystems;
using TMPro;

public class Preisanzeige : BasisShop, IPointerEnterHandler, IPointerExitHandler {

    public TMP_Text hoverText;
    public TMP_Text Geldanzeige;


    public void OnPointerEnter(PointerEventData eventData) {
        hoverText.gameObject.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData) {
        hoverText.gameObject.SetActive(false);
    }

    void Update() {
        Geldanzeige.text = "Emeralds: " + GameManager.Instance.money;
    }
}
