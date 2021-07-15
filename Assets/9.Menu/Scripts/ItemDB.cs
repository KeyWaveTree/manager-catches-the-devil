using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDB : MonoBehaviour
{
    public static List<ItemList> itemList = new List<ItemList>();
    public static ItemDB instace;
    void Awake()
    {
        if (instace != null)
        {
            Destroy(gameObject);
            return;
        }
        instace = this;
        DontDestroyOnLoad(gameObject);

        itemList.Add(new ItemList(0, 0, "", "", Resources.Load<Sprite>("Item/Square")));
        itemList.Add(new ItemList(1, 500, "����� ����Ŭ�ι�", "����� ����Ŭ�ι� : ������ ����� ���ݷ� +6", Resources.Load<Sprite>("Item/clover")));
        itemList.Add(new ItemList(2, 1200, "�뷮 ȸ������", "�뷮 ȸ������ : ������ ����� ü���� �������� ���� �� 40ȸ��", Resources.Load<Sprite>("Item/FullPotion")));
        itemList.Add(new ItemList(3, 800, "�߷� ȸ������", "�߷� ȸ������ : ������ ����� ü���� �������� ���� �� 30ȸ��", Resources.Load<Sprite>("Item/MiddlePotion")));
        itemList.Add(new ItemList(4, 400, "�ҷ� ȸ������", "�ҷ� ȸ������ : ������ ����� ü���� �������� ���� �� 20ȸ��", Resources.Load<Sprite>("Item/LessPotion")));
        itemList.Add(new ItemList(5, 600, "���� ������", "���� ������ : ������ ����� ���ݷ� +4 ü�� +3", Resources.Load<Sprite>("Item/magic_jewel")));
        itemList.Add(new ItemList(6, 500, "���� ������", "���� ������ : ������ ����� ���ݷ� +5", Resources.Load<Sprite>("Item/Magic_Staff")));
        itemList.Add(new ItemList(7, 1300, "�������� ���Ʈ", "�������� ���Ʈ : ������ ����� ���� +10", Resources.Load<Sprite>("Item/pandant")));
        itemList.Add(new ItemList(8, 700, "������� ����", "������� ���� : ������ ����� ���� +8", Resources.Load<Sprite>("Item/RoundShield")));
        itemList.Add(new ItemList(9, 400, "�α��� ��ȭ", "�α��� ��ȭ : ������ ����� ���ݷ� +3", Resources.Load<Sprite>("Item/shoes")));
        itemList.Add(new ItemList(10, 1500, "���� ��ũ", "���� ��ũ : ������ ����� ü�� +10", Resources.Load<Sprite>("Item/TheCross")));
        itemList.Add(new ItemList(11, 1200, "���ֹ��� �ε�����", "���ֹ��� �ε����� : ������ ����� ���ݷ� +10 ü�� -10", Resources.Load<Sprite>("Item/Voodoo_Doll_Cursed")));
        itemList.Add(new ItemList(12, 2300, "����� ��ε�ҵ�", "����� ��ε�ҵ� : ������ ����� ���ݷ� +15", Resources.Load<Sprite>("Item/BroadSword")));
        itemList.Add(new ItemList(13, 1900, "���� ��Ʋ��", "���� ��Ʋ�� : ������ ����� ���ݷ� +7 ���� +7", Resources.Load<Sprite>("Item/Gauntlets")));
        itemList.Add(new ItemList(14, 2000, "�ս� ü�¹���", "�ս� ü�¹��� : ������ ����� ü�� +15", Resources.Load<Sprite>("Item/Healthy_Ring")));
        itemList.Add(new ItemList(15, 2000, "�ս� ��������", "�ս� �������� : ������ ����� ���ݷ� +13", Resources.Load<Sprite>("Item/Magic_Damage_Ring")));
        itemList.Add(new ItemList(16, 1900, "���� ö��", "���� ö�� : ������ ����� ���ݷ� +7 ü�� +7", Resources.Load<Sprite>("Item/Mace")));
        itemList.Add(new ItemList(17, 1500, "��� ������", "��� ������ : ��� �� ��縦 �� �� �� ������ �� �ִ�.", Resources.Load<Sprite>("Item/yongsamozip")));
        itemList.Add(new ItemList(18, 800, "������� �ü�", "������� �ü� : ������ ����� ���ݷ� +5 ���� +3", Resources.Load<Sprite>("Item/cat and anjfqhk")));
        itemList.Add(new ItemList(19, 1600, "����� ����", "����� ���� : ������ ����� ���ݷ� +10", Resources.Load<Sprite>("Item/Bird_Gun")));
        itemList.Add(new ItemList(20, 3000, "��� ���� ����", "��� ���� ���� : ������ ����� ���ݷ� +20 ü�� -20", Resources.Load<Sprite>("Item/Bad_Mood_Mask")));
    }
}
