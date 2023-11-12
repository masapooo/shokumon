using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.EventSystems;

public class DiceController : MonoBehaviour
{
    public GameObject diceObject;
    Rigidbody2D rb2D;
    private Image diceImage;
    private int preNum;
    private bool isRandom = false;
    Sprite[] images;

    [SerializeField] Text numText;

    private void Start()
    {
        diceImage = diceObject.GetComponent<Image>();
        rb2D = diceObject.GetComponent<Rigidbody2D>();
        images = Resources.LoadAll<Sprite>("Dice");
        images = Resources.LoadAll<Sprite>("Dice");
    }

    public void Roll()
    {
        Debug.Log(diceObject);
        Debug.Log(isRandom);
        if (diceObject == null)
        {
            return;
        }

        if (isRandom)
        {
            Debug.Log("ロール3");
            if (rb2D != null && !rb2D.IsSleeping())
            {
                int num = Random.Range(1, 7); // 1から6に変更
                Debug.Log(images[num - 1]);
                diceImage.sprite = images[num - 1]; // 0から5に変更
                preNum = num;
            }
            else
            {
                Debug.Log(preNum + 1);
                isRandom = false;
            }
        }
        StartCoroutine(RollAnimation());
    }

    public void OnClickDice()
    {
        Roll();
        Debug.Log("サイコロ");
        if (rb2D != null && rb2D.IsSleeping() && !isRandom)
        {
            rb2D.AddForce(new Vector2(0f, 10000f));
            isRandom = true;
        }
    }

    IEnumerator RollAnimation()
    {
        int rolls = 50; // サイコロの回転回数
        float rollDuration = 0.05f; // 1回の回転にかかる時間

        for (int i = 0; i < rolls; i++)
        {
            int randomNum = Random.Range(1, 7);

            // 画像の切り替え
            diceImage.sprite = images[randomNum - 1];

            // 画像を切り替えた後に待機
            yield return new WaitForSeconds(rollDuration);
        }

        int finalNum = Random.Range(1, 7);

        // 最終的な結果の画像を表示
        diceImage.sprite = images[finalNum - 1];

        // テキストも更新
        numText.text = finalNum.ToString();
    }

}
