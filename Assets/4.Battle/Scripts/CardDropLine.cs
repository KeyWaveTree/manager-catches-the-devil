using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDropLine : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.CompareTag("Card"))
        {
            coll.GetComponent<CardBattle>().cardDrop = true;
            //Debug.Log(coll.GetComponent<CardBattle>().cardDrop);
        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        coll.GetComponent<CardBattle>().cardDrop = false;
        //Debug.Log(coll.GetComponent<CardBattle>().cardDrop);
    }
}
