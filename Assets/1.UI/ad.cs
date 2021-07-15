using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ad : MonoBehaviour
{
    public static GameObject myText;
    // Start is called before the first frame update
    void Start()
    {
        myText = transform.GetChild(0).gameObject;
    }
}
