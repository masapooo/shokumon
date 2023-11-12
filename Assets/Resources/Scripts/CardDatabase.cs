using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDatabase : MonoBehaviour
{
    [SerializeField] List<CardController> cardControllers = new List<CardController>();
    public CardController GetCardPrefab(int cardID)
    {
        return cardControllers[cardID];
    }
}