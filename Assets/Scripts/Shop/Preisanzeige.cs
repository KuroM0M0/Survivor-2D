using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class Preisanzeige : BasisShop, IPointerEnterHandler, IPointerExitHandler
{

    public TMP_Text hoverText;


    public void OnPointerEnter(PointerEventData eventData) {
        hoverText.gameObject.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData) {
        hoverText.gameObject.SetActive(false);
    }

    void Update() {
        Geldanzeige.text = "Emeralds: " + Load.LoadCoin();
    }
}
