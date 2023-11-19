using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Comment : MonoBehaviour
{
    [SerializeField] private Text aiComment;
    void Update()
    {
        aiComment.text = Settings.comment;
    }
}
