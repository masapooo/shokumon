using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{   
    public CardType cardType;    
    public CardAttribute attribute;
    //public CardModel model;        
    public CardMovement movement;  
    public List<CardDice> cardDice;

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

public enum CardAttribute
{
    Energy,
    Balance,
    Power,
    None,
}
public enum CardType
{
    Food,
    Nutrition,
    Human,
}   
public enum CardDice
{
    One = 1,
    Two = 2,
    Three = 3,
    Four = 4,
    Five = 5,
    Six = 6,
}

