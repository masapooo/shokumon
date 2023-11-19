using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DiceManager : MonoBehaviour
{
    public UnityAction OnRollEndAction;

    // Dice1,2の管理
    [SerializeField] DiceController[] diceList;
    
    public DiceController[] DiceList { get => diceList; set => diceList = value;}

    private void Awake()
    {
        foreach (var dice in diceList)
        {
            dice.OnRollEnd += OnRollEnd;
        }
    }

    // ターンエンドしたらサイコロを振る
    public void RollDice()
    {
        foreach (var dice in diceList)
        {
            dice.OnClickDice();
        }
    }

    void OnRollEnd()
    {
        if (diceList[0].wasRolled && diceList[1].wasRolled)
        {
            // Dice1,2の目が決定した
            OnRollEndAction?.Invoke();
        }
    }
}
