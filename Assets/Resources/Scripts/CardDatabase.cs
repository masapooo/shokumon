using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDatabase : MonoBehaviour
{
    [SerializeField] List<CardController> cardControllers = new List<CardController>();
    public CardController GetCardPrefab(int cardID)
    {
        Debug.Log("CardDatabase:" + cardID);
        Debug.Log("CardDatabase:" + cardControllers[cardID]);
        return cardControllers[cardID];
    }
}