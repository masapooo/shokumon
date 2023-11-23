using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnDisplay1 : MonoBehaviour
{
    public GameObject uiPanel;  // UIを管理するパネル

    void Start()
    {
        // 最初はUIを非表示にする
        uiPanel.SetActive(false);
    }

    public void Show()
    {
        uiPanel.SetActive(true);
        Invoke("HideUI", 1f);// 1秒後にHideUIメソッドを呼ぶ
    }

    public void HideUI()
    {
        // UIを非表示にする
        uiPanel.SetActive(false);
    }
}

