using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
//カードを配る
//　プレハブのデータベース作成
// ランダムに生成する
//
    //[SerializeField] CardDatabase cardDatabase;

    [SerializeField]
    Transform playerHandTransform,
                               playerFieldTransform,
                               enemyHandTransform,
                               enemyFieldTransform;
    //[SerializeField] CardController cardPrefab;
    [SerializeField] CardDatabase cardDatabase;

    bool isPlayerTurn;

    List<int> playerDeck = new List<int>() {0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27};
    List<int> enemyDeck = new List<int>() {0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27};

    public static GameManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        StartGame();
    }

    void StartGame()
    {
        SettingInitHand();
        isPlayerTurn = true;
        TurnCalc();
    }

    void SettingInitHand()
    {
        // カードをそれぞれに五枚配る
        for (int i = 0; i < 5; i++)
        {
            GiveCardToHand(playerDeck, playerHandTransform);
            GiveCardToHand(enemyDeck, enemyHandTransform);
        }
    }
    void GiveCardToHand(List<int> deck, Transform hand)
    {
        int r = Random.Range(0, deck.Count);
            int cardID = deck[r];
            deck.RemoveAt(r);
            CreateCard(cardID, hand);
    }

    void CreateCard(int cardID, Transform hand)
    {
        //　カードの生成とデータの受け渡し
        CardController card = Instantiate(cardDatabase.GetCardPrefab(cardID),hand, false);
        //card.Init(cardID);
    }

    void TurnCalc()
    {
        if (isPlayerTurn)
        {
            PlayerTurn();
        }
        else
        {
            EnemyTurn();
        }
    }

    public void ChangeTurn()
    {
        isPlayerTurn = !isPlayerTurn;
        if (isPlayerTurn)
        {
            GiveCardToHand(playerDeck, playerHandTransform);
        }
        else
        {
            GiveCardToHand(enemyDeck, enemyHandTransform);
        }
        TurnCalc();
    }

    void PlayerTurn()
    {
        Debug.Log("PlayerTurn");
    }
    void EnemyTurn()
    {
        Debug.Log("EnemyTurn");
        CardController[] handCardList = enemyHandTransform.GetComponentsInChildren<CardController>();
        CardController enemyCard = handCardList[0];
        enemyCard.movement.SetCardTransform(enemyFieldTransform);
        CardController[] fieldCardList = enemyFieldTransform.GetComponentsInChildren<CardController>();
        CardController attacker = fieldCardList[0];
        CardController[] playerFieldCardList = playerFieldTransform.GetComponentsInChildren<CardController>();
        CardController defender = playerFieldCardList[0];

        ChangeTurn();
    }
}
