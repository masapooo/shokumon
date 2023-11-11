using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceController : MonoBehaviour
{
    [SerializeField] Text numText;

    private void Start()
    {
        Roll();
    }

    public void Roll()
    {
        StartCoroutine(RollAnimation());
    }

    IEnumerator RollAnimation()
    {
        int rolls = 20; // サイコロの回転回数
        float rollDuration = 0.05f; // 1回の回転にかかる時間

        for (int i = 0; i < rolls; i++)
        {
            int randomNum = Random.Range(1, 7);
            numText.text = randomNum.ToString();
            yield return new WaitForSeconds(rollDuration);
        }

        int finalNum = Random.Range(1, 7);
        numText.text = finalNum.ToString();
    }
}
