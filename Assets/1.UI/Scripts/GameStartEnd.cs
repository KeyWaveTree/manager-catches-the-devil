using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public delegate void Poster();
public class GameStartEnd : MonoBehaviour
{
    public event Poster poster;
    public static bool openingEnd = false;
    bool _animGo = false;
    public bool animGO
    {
        get { return _animGo; }
        set
        {
            _animGo = value;
            if (animGO) poster();
        }
    }
    bool go = false;
    Vector2 target = new Vector2(0, 0);
    Vector2 scale = new Vector2(10, 10);

    private void Start()
    {
        poster += new Poster(PosterAnim);
    }
    private void Update()
    {
        if (openingEnd)
        {
            transform.position = Vector2.MoveTowards(transform.position, target, 1f);
            if (transform.localScale.x > 4 || transform.localScale.y > 4)
            {
                scale.x -= 1f;
                scale.y -= 1f;

                transform.localScale = scale;
            } 
            if(transform.localScale.x <= 4 && transform.localScale.y <= 4 && !go)
            {
                go = true;
                animGO = true;
            }
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene("Tutorial");
            }
        }
    }

    void PosterAnim()
    {
        print("ÀÌÀ×");
        GetComponent<Animator>().Play("GameStart", -1, 0);
    }
}
