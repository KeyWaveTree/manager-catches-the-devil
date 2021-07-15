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
        tutorialText.text = "우리는 마왕에게 패배하였다...";
        StartCoroutine(FadeIn(tutorialText));
        yield return new WaitForSeconds(5f);
        tutorialText.text = "모두가 죽었을 때 나만 도망쳐\n살아남을 수 있었다...";
        StartCoroutine(FadeIn(tutorialText));
        yield return new WaitForSeconds(5f);
        tutorialText.text = "매니저인 나만...";
        StartCoroutine(FadeIn(tutorialText));
        yield return new WaitForSeconds(5f);
        tutorialText.text = "처음부터 다시 시작할 것이다";
        StartCoroutine(FadeIn(tutorialText));
        yield return new WaitForSeconds(5f);
        tutorialText.text = "용사들을 모아 마왕에게 이끌어\n복수할 것이다";
        StartCoroutine(FadeIn(tutorialText));
        yield return new WaitForSeconds(5f);
        tutorialText.text = "용사 매니저인\n 나만이 가능한 일이다...";
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
