using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneySC : MonoBehaviour
{
    private TextMeshPro tmp;
    private void Start()
    {
        tmp = GetComponent<TextMeshPro>();
    }
    private void Update()
    {
        tmp.text = CardData.gold + "°ñµå";
    }
}
