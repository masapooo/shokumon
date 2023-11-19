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
    [SerializeField] DiceManager diceManager;

    bool isPlayerTurn;

    List<int> playerDeck = new List<int>() {0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20};
    List<int> enemyDeck = new List<int>() {0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20};

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
        diceManager.OnRollEndAction += OnRollEnd;
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

        // 手札にカードを追加する処理が必要
        CardController cardController = hand.GetComponentInChildren<CardController>();
        if (cardController != null)
        {
            // 手札に追加されたカードの処理を行う（例: 表示位置を設定するなど）
            // 以下は例示で実際の処理に合わせて変更してください
            cardController.movement.SetCardTransform(hand);
        }
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
        // 手札が空でないことを確認
        if (handCardList.Length > 0)
        {
            CardController enemyCard = handCardList[0];
            //enemyCard.movement.SetCardTransform(enemyFieldTransform);

            CardController[] fieldCardList = enemyFieldTransform.GetComponentsInChildren<CardController>();

            // フィールドにカードがあるかどうかを確認
            if (fieldCardList.Length > 0)
            {
                CardController attacker = fieldCardList[0];
                CardController[] playerFieldCardList = playerFieldTransform.GetComponentsInChildren<CardController>();

                // プレイヤーのフィールドにカードがあるかどうかを確認
                if (playerFieldCardList.Length > 0)
                {
                    CardController defender = playerFieldCardList[0];
                    ChangeTurn();
                }
                else
                {
                    // プレイヤーのフィールドにカードがない場合の処理
                }
            }
            else
            {
                // フィールドにカードがない場合の処理
            }
        }
        else
        {
            // 手札が空の場合の処理
        }
    }

    public void OnTurnEndButton()
    {
        //サイコロを振る
        Debug.Log("OnTurnEndButton");
        diceManager.RollDice();
    }
    void OnRollEnd()
    {
        Debug.Log($"GameManager OnRollEnd:{diceManager.DiceList[0].number},{diceManager.DiceList[1].number}");
    }
}
