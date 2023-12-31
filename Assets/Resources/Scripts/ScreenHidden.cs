using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenHidden : MonoBehaviour
{
    public GameObject uiPanel;  // UIを管理するパネル

    void Start()
    {
        // 最初はUIを非表示にする
        uiPanel.SetActive(false);
    }

    public void Show()
    {
        Debug.Log(uiPanel);
        uiPanel.SetActive(true);
    }
}
