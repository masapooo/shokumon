using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenHidden : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // オブジェクトを非アクティブにする
        gameObject.SetActive(false);
    }
}
   