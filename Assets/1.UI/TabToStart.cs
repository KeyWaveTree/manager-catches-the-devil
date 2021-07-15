using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabToStart : MonoBehaviour
{
    public GameObject posterAnim;
    private void Start()
    {
        StartCoroutine(FadeTextToFullAlpha());
    }
    public IEnumerator FadeTextToFullAlpha() // 알파값 0에서 1로 전환
    {
        //GetComponent<Text>().color = new Color(GetComponent<Text>().color.r, GetComponent<Text>().color.g, GetComponent<Text>().color.b, 0);
        while (GetComponent<Text>().color.a < 1.0f)
        {
            GetComponent<Text>().color = new Color(GetComponent<Text>().color.r, GetComponent<Text>().color.g, GetComponent<Text>().color.b, GetComponent<Text>().color.a + (Time.deltaTime / 1.0f));
            yield return null;
        }
        StartCoroutine(FadeTextToZero());
    }

    public IEnumerator FadeTextToZero()  // 알파값 1에서 0으로 전환
    {
        //GetComponent<Text>().color = new Color(GetComponent<Text>().color.r, GetComponent<Text>().color.g, GetComponent<Text>().color.b, 1);
        while (GetComponent<Text>().color.a > 0.4f)
        {
            GetComponent<Text>().color = new Color(GetComponent<Text>().color.r, GetComponent<Text>().color.g, GetComponent<Text>().color.b, GetComponent<Text>().color.a - (Time.deltaTime / 1.0f));
            yield return null;
        }
        StartCoroutine(FadeTextToFullAlpha());
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Destroy(this.gameObject);
            posterAnim.SetActive(true);
            GameStartEnd.openingEnd = true;
        }
    }
}
