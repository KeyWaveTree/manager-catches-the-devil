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
            Debug.Log("����� ü�� : " + usercard_hp);
            usercard_hp = usercard_hp - (goblin_attck + (all_item_count * 2));
            Debug.Log("��� ���ݷ� : " + goblin_attck);
            Debug.Log("�߰� ���ݷ� : " + all_item_count * 2);
            Debug.Log("����� ü�� : " + usercard_hp);
        }*/

    /*    public void goblin_executives_B_skill()
        {
            Debug.Log("����� ü�� : " + usercard_hp);
            usercard_hp = usercard_hp - (goblin_attck + (dead_goblin*2));
            Debug.Log("��� ���ݷ� : " + goblin_attck);
            Debug.Log("�߰� ���ݷ� : " + dead_goblin*2);
            Debug.Log("����� ü�� : " + usercard_hp);
        }*/

    /*    public void goblin_mid_boss()
        {
            if(goblin_hp <= 10)
            {
                Debug.Log("ü���� 10����!");
                gameObject.SetActive(false);
                Debug.Log("���� ������ �̺� �θ��� ����!");
                GameObject goblin_soldier1 = Instantiate(goblinPrefab, new Vector3(-1, 1, 0), Quaternion.identity) as GameObject;
                GameObject goblin_soldier2 = Instantiate(goblinPrefab, new Vector3(0, 1, 0), Quaternion.identity) as GameObject;
            }
        }*/

    public void goblin_boss()
    {
        // -------------------------------------------------------------------------
        Debug.Log("���� ���� ���� ���鿹��(���� ������ ȿ�� ��ȿ)");
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
