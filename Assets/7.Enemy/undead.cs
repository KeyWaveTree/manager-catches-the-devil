using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class undead : MonoBehaviour
{
    [SerializeField]
    private GameObject undeadPrefab;
    public int select;
    public int undead_hp;
    public int undead_attck;
    public int item_count;
    public int usercard_hp;
    public int all_item_count;

    public void undead_defult_passive()
    {
        if(undead_hp <= 0)
        {
            gameObject.SetActive(false);
            GameObject goblin_soldier1 = Instantiate(undeadPrefab, new Vector3(-1, 2, 0), Quaternion.identity) as GameObject;
            undead_hp = 1;
            undead_attck = 10;
            Debug.Log("부활한 언데드 체력 = "+ undead_hp);
        }
    }

    public void undead_mid_boss_passive()
    {
        Debug.Log("전투 만든이후 도트뎀 구현");
    }

    public int OnMouseDown()
    {
        switch (select)
        {
            case 1:
                undead_defult_passive();
                return undead_hp;
            case 2:
                undead_mid_boss_passive();
                break;
        }
        Debug.Log("----------------");

        return usercard_hp;

    }
}
