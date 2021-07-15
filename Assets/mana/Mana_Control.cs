using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mana_Control : MonoBehaviour
{
    [SerializeField]
    private GameObject manaPrefab;

    int control = 1;
    int count = 10;
    int mana_line = 0;
    List<GameObject> ManaList = new List<GameObject>();

    public void Start()
    {

    }

    public void mana_create()
    {
        if (control == 0)
        {
            if (count != 1 || count == 1)
            {
                count++;
            }

        }

        control = 1;

        if (count > 10)
        {
            count = 10;
        }
        foreach (GameObject destroyArray in ManaList)
        {
            Destroy(destroyArray);
        }
        for (int a = 1; a <= count; a++)
        {
            GameObject Mana = Instantiate(manaPrefab, new Vector3(mana_line - 4, 1, 0), Quaternion.identity) as GameObject;
            ManaList.Add(Mana);
            mana_line++;
        }
        Debug.Log("+" + count);
        if (count != 10)
        {
            count++;
            Debug.Log("+" + count);
        }
        mana_line = 0;   

    }

    public void mana_del()
    {
        if (control == 1)
        {
            if(count != 10)
            {
                count--;
            }
            
        }

        control = 0;

        foreach (GameObject destroyArray in ManaList)
        {
            Destroy(destroyArray);
        }
        if (count < 1)
        {
            count = 0;
            Debug.Log("-" + count);
            Debug.Log("-max");
            //count++;
            Debug.Log("-" + count);
        }
        else
        {
            count--;
            Debug.Log("-" + count);
            for (int a = 1; a <= count; a++)
            {
                GameObject Mana = Instantiate(manaPrefab, new Vector3(mana_line - 4, 1, 0), Quaternion.identity) as GameObject;
                ManaList.Add(Mana);
                mana_line++;
            }
            mana_line = 0; 
        }
    }

    public void Mana_Control_create(int plus)
    {
        int c = 0;
        for(int b = 0; b < plus; b++)
        {
            Debug.Log(c);
            c++;
            mana_create();
        }
    }

    public void Mana_Control_del(int minus)
    {
        int c = 0;
        for (int b = 0; b < minus; b++)
        {
            Debug.Log(c);
            c++;
            mana_del();
        }
    }
}
