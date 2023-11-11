using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubZone : MonoBehaviour
{
    [SerializeField] DropPlace dropPlace;

    private void Start()
    {
        // 初期状態で非表示にする
        gameObject.SetActive(false);

        dropPlace.OnCardDrop += SetCard;
    }

    public void SetCard(CardMovement cardMovement)
    {
        if (cardMovement.GetComponent<CardController>().cardType == CardType.Nutrition)
        {
            // カードがNutritionの場合、表示する
            gameObject.SetActive(true);
            cardMovement.defaultParent = transform;
        }
    }
}
