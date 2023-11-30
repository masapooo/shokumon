using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenHidden2 : MonoBehaviour

{
    public GameObject uiPanel;  // UIを管理するパネル
    void Start()
    {
        // オブジェクトを非アクティブにする
        gameObject.SetActive(false);
    }
    public void Show()
    {
        uiPanel.SetActive(true);
    }
}
   