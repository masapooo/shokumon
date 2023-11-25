using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PointzoneManager : MonoBehaviour
{
    [SerializeField] List<Pointzone> pointzones;
    public UnityAction OnAllFull;

    //GameManagerから渡されるCardを受け取り、PointzoneのCardAttributeと一致するPointzoneにCardを追加する
    public void AddCard(CardController card)
    {
        //Cardの属性を取得する
        CardAttribute cardAttribute = card.attribute;
        //Cardの属性と一致するPointzoneを探す
        foreach (Pointzone pointzone in pointzones)
        {
            if (pointzone.cardAttribute == cardAttribute)
            {
                //一致したPointzoneにCardを追加する
                pointzone.AddCard(card.gameObject);
                break;
            }
        }
        //勝利条件が揃ったらGameManagerに通知する
        if (IsAllFull())
        {
            OnAllFull?.Invoke();
        }
    }
    //全てのPointzoneにCardがあるか判定する
    //勝利判定
    public bool IsAllFull()
    {
        foreach (Pointzone pointzone in pointzones )
        {
            if(!pointzone.IsFull())
            {
                return false;
            }
        }
        return true;
    }

}
