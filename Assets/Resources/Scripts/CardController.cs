using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{        
    //public CardModel model;        
    public CardMovement movement;  

    private void Awake()
    {
        movement = GetComponent<CardMovement>();
    }

    public void Init(int cardID)
    {
        //model = new CardModel(cardID);
    }

    public void Attack(CardController enemyCard)
    {
        //model.Attack(enemyCard);
    }

    public void CheckAlive()
    {
        // if (model.isAlive)
        // {

        // }
        // else
        // {
        //     Destroy(this.gameObject);
        // }
    }
}