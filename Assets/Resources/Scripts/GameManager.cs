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
    [SerializeField] DropPlace[] dropPlaces;
    [SerializeField] PointzoneManager pointzoneManager;
    //デバッグ用フラグ
    [SerializeField] bool isDemo;
    [SerializeField] TurnDisplay1 turnDisplay;
    [SerializeField] TurnDisplay2 turnDisplay2;
    [SerializeField] ScreenHidden screenHidden;

    bool isPlayerTurn;

    List<int> playerDeck = new List<int>() {0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19};
    List<int> enemyDeck = new List<int>() {0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19};

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
        //PointzoneManagerにOnAllFullを登録
        pointzoneManager.OnAllFull += OnAllFull;
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
        // Showメソッドを呼び出す
        turnDisplay.Show();
    }

    void EnemyTurn()
    {
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
        // Showメソッドを呼び出す
        turnDisplay2.Show();
    }

    public void OnTurnEndButton()
    {
        //サイコロを振る
        diceManager.RollDice();
    }
    void OnRollEnd()
    {
        Debug.Log($"GameManager OnRollEnd:{diceManager.DiceList[0].number},{diceManager.DiceList[1].number}");
        foreach (var place in dropPlaces)
        {
            if (place.IsFull())
            {
                //2つのDiceの目とplaceにあるCardのDiceの目に含まれるか確認する
                if (
                    ((place.cardController.cardDice[0] ==(CardDice)diceManager.DiceList[0].number) && (place.cardController.cardDice[1] ==(CardDice)diceManager.diceList[1].number))
                    ||((place.cardController.cardDice[0] ==(CardDice)diceManager.DiceList[1].number) && (place.cardController.cardDice[1] ==(CardDice)diceManager.diceList[1].number)))
                {
                    //Logで一致すると出す
                    Debug.Log("一致");
                    //PointzoneManagerにCardを渡す
                    pointzoneManager.AddCard(place.cardController);
                    //Cardを削除する
                    place.RemoveChild();
                    place.RemoveCardController();
                }
            }
        }
    }
    //勝利判定　PointzoneにCardが配置されているなら勝利通知を出す
    public void OnAllFull()
    {
        screenHidden.Show();
        Debug.Log("勝利");
    }
}