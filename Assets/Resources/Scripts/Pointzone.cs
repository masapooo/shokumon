using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointzone : MonoBehaviour
{
   //Cardの属性を設定
   public CardAttribute cardAttribute;

   //引数で渡されたカードを子要素にする
   public void AddCard(GameObject card)
    {
        card.transform.SetParent(transform);
        //位置の調整
        card.transform.localPosition = Vector3.zero;
    }
    public bool IsFull()
    {
        if (transform.childCount == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
