using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class DropPlace : MonoBehaviour, IDropHandler
{
    public UnityAction<CardMovement> OnCardDrop;
    [SerializeField] CardAttribute attribute;
    [SerializeField] CardType cardType;
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
            }
            else
            {
                wasSet = true;
                card.defaultParent = this.transform;

                Debug.Log(subZone);

                // wasSetがtrueになったときにSubZoneをActiveにする
                if (subZone != null)
                {
                    subZone.SetActive(true);
                }
            }

            card.transform.localPosition = new Vector3(0, 0, 0);
        }
    }
}
