using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="CardEntity", menuName ="Create CardEntity")]
//カードデータ
public class CardEntity : ScriptableObject 
{
    public new string type;
    public new string subtype;

}
