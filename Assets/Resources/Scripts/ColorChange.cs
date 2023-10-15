using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorChange : MonoBehaviour
{
  //MeshRenderer mr;
  Image image;
  void Start ()
  {
        image = GetComponent<Image>();
        image.color = image.color - new Color32(0,0,0,255);
    //mr = GetComponent<MeshRenderer>();
    //mr.material.color = mr.material.color - new Color32(0,0,0,255);
  }
}