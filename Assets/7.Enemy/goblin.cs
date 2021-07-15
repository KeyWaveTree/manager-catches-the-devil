using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goblin : MonoBehaviour
{
    [SerializeField]
    private GameObject goblinPrefab;
    public int select;
    public int goblin_hp;
    public int goblin_attck;
    public int item_count;
    public int usercard_hp;
    public int all_item_count;
    public int dead_goblin;
    /*    public void goblin_boss_passive()
        {
            Debug.Log("방어전 체력 : " + usercard_hp);
            usercard_hp = usercard_hp - (goblin_attck + (all_item_count * 2));
            Debug.Log("고블린 공격력 : " + goblin_attck);
            Debug.Log("추가 공격력 : " + all_item_count * 2);
            Debug.Log("방어후 체력 : " + usercard_hp);
        }*/

    /*    public void goblin_executives_B_skill()
        {
            Debug.Log("방어전 체력 : " + usercard_hp);
            usercard_hp = usercard_hp - (goblin_attck + (dead_goblin*2));
            Debug.Log("고블린 공격력 : " + goblin_attck);
            Debug.Log("추가 공격력 : " + dead_goblin*2);
            Debug.Log("방어후 체력 : " + usercard_hp);
        }*/

    /*    public void goblin_mid_boss()
        {
            if(goblin_hp <= 10)
            {
                Debug.Log("체력이 10이하!");
                gameObject.SetActive(false);
                Debug.Log("보스 런이후 쫄병 두마리 생성!");
                GameObject goblin_soldier1 = Instantiate(goblinPrefab, new Vector3(-1, 1, 0), Quaternion.identity) as GameObject;
                GameObject goblin_soldier2 = Instantiate(goblinPrefab, new Vector3(0, 1, 0), Quaternion.identity) as GameObject;
            }
        }*/

    public void goblin_boss()
    {
        // -------------------------------------------------------------------------
        Debug.Log("전투 구현 이후 만들예정(유저 아이템 효과 무효)");
        // -------------------------------------------------------------------------
    }

    //public int OnMouseDown()
    //{
    //    switch (select)
    //    {
    //        case 1:
    //            goblin_A_passive();
    //            break;
    //        case 2:
    //            goblin_mid_boss_passive();
    //            break;
    //        case 3:
    //            goblin_boss();
    //            break;
    //    }
    //    Debug.Log("----------------");

    //    return usercard_hp;

    //}
}
