using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialSC : MonoBehaviour
{
    public Text tutorialText;
    public float speed = 4;

    private void Start()
    {
        tutorialText = GetComponent<Text>();
        StartCoroutine(TutorialsEvent());
    }

    IEnumerator TutorialsEvent()
    {
        tutorialText.text = "�츮�� ���տ��� �й��Ͽ���...";
        StartCoroutine(FadeIn(tutorialText));
        yield return new WaitForSeconds(5f);
        tutorialText.text = "��ΰ� �׾��� �� ���� ������\n��Ƴ��� �� �־���...";
        StartCoroutine(FadeIn(tutorialText));
        yield return new WaitForSeconds(5f);
        tutorialText.text = "�Ŵ����� ����...";
        StartCoroutine(FadeIn(tutorialText));
        yield return new WaitForSeconds(5f);
        tutorialText.text = "ó������ �ٽ� ������ ���̴�";
        StartCoroutine(FadeIn(tutorialText));
        yield return new WaitForSeconds(5f);
        tutorialText.text = "������ ��� ���տ��� �̲���\n������ ���̴�";
        StartCoroutine(FadeIn(tutorialText));
        yield return new WaitForSeconds(5f);
        tutorialText.text = "��� �Ŵ�����\n ������ ������ ���̴�...";
        StartCoroutine(FadeIn(tutorialText));
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("Main");
    }

    IEnumerator FadeIn(Text tutorial)
    {
        //tutorial.color = new Color(tutorial.color.r, tutorial.color.g, tutorial.color.b, 0);
        while (tutorial.color.a < 1.0f)
        {   
            tutorial.color = new Color(tutorial.color.r, tutorial.color.g, tutorial.color.b, 
                tutorial.color.a + (Time.deltaTime / speed));
            yield return null;
        }

        //tutorial.color = new Color(tutorial.color.r, tutorial.color.g, tutorial.color.b, 1);
        while (tutorial.color.a > 0.0f)
        {
            tutorial.color = new Color(tutorial.color.r, tutorial.color.g, tutorial.color.b,
                tutorial.color.a - (Time.deltaTime / speed));
            yield return null;
        }
    }
}
