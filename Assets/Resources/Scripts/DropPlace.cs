using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class DropPlace : MonoBehaviour, IDropHandler
{
    public UnityAction<CardMovement> OnCardDrop;
    [SerializeField] CardAttribute attribute;
    [SerializeField] CardType cardType;
    public CardController cardController;
    bool wasSet;
    [SerializeField] GameObject subZone; // SubZoneの参照をInspectorから設定

    public void OnDrop(PointerEventData eventData)
    {
        CardMovement card = eventData.pointerDrag.GetComponent<CardMovement>();
        if (card != null)
        {
            if (card.GetComponent<CardController>().attribute != attribute || card.GetComponent<CardController>().cardType != cardType)
            {
                return;
            }

            if (wasSet)
            {
                OnCardDrop?.Invoke(card);
                /*if ()
                {

                }*/
            }
            else
            {
                wasSet = true;
                card.defaultParent = this.transform;
                card.GetComponent<Image>().raycastTarget = false;
                cardController = card.GetComponent<CardController>();
                Debug.Log(subZone);

                // wasSetがtrueになったときにSubZoneをActiveにする
                if (subZone != null)
                {
                    Debug.Log("アクティブ");
                    subZone.SetActive(true);
                }
            }

            card.transform.localPosition = new Vector3(0, 0, 0);
        }
    
    }
    //SubZoneに子要素が1つあるかどうか判定する
    public bool IsFull()
    {
        if (subZone.transform.childCount == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    //subZoneにある子要素を削除する
    public void RemoveChild()
    {
        if (subZone.transform.childCount == 1)
        {
            Destroy(subZone.transform.GetChild(0).gameObject);
        }
    }
    // cardControllerをnullにする
    public void RemoveCardController()
    {
        cardController = null;
    }
}