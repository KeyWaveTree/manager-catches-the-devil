using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDataBase : MonoBehaviour
{
    public static List<CardList> cardList = new List<CardList>();
    public static CardDataBase instace;
    void Awake()
    {
        if(instace != null)
        {
            Destroy(gameObject);
            return;
        }
        instace = this;
        DontDestroyOnLoad(gameObject);

        //�ó��� ���� ����S���� = RedSR ������ ������
        //ī�� �߰� ��� Add(���̵�, ī�� �̸�, ī�� ���, ���ݷ�, ü��, ����, �ó���, ����, �ʵ彺ų,
        //��ġ��ų, ����, ĳ���� �̹���, �ó��� �̹��� ������, �ó��� �̹��� ����, �޹��, �ʵ彺ų��Ÿ��, �ʵ彺ų�����Һ�, ��ġ��ų�����Һ�
        cardList.Add(new CardList(0, "", "", 0, 0, "", 0,
                    "", "", "", Resources.Load<Sprite>("Character/DefaultCard"), null, null, null, 0, 0, 0));
                                                                
        cardList.Add(new CardList(1, "��� ������", "�����", 20, 120, "������", 1,
            "���� ���� ������ 3�� ���ظ� ������. (��Ÿ�� 1��) (���� 3�Һ�)",
            "���� ���� �Ʊ��� ���ݷ� +2 (���� 1�Һ�)", "����", Resources.Load<Sprite>("Character/Braveheart"),
            Resources.Load<Sprite>("Synergy/RedSR"), Resources.Load<Sprite>("Synergy/RedSL"),
            Resources.Load<Sprite>("CardBackGround"), 1, 3, 1));

        cardList.Add(new CardList(2, "�ս� ���屺", "Ư����", 30, 135, "�ʷϻ�", 2,
            "���� ���� ���� ���� ������ �����Ѵ�. (��Ÿ�� 4��) (���� 6�Һ�)",
            "���� ���� �Ʊ��� ���ظ� ������ ������ ���� ���ݷ� -1 (���� 2�Һ�)", "����", Resources.Load<Sprite>("Character/Hammer"),
            Resources.Load<Sprite>("Synergy/GreenSR"), Resources.Load<Sprite>("Synergy/GreenSL"),
            Resources.Load<Sprite>("CardBackGround"), 4, 6, 2));

        cardList.Add(new CardList(3, "�߼� ��ɲ�", "�����", 30, 100, "�ʷϻ�", 2,
            "���� ���� ������ 25%�� Ȯ���� 10�� ���ظ� ������. (��Ÿ�� 3��) (���� 3�Һ�)",
            "���� ���� ���� �Ǹ���� ���� ������ 5%�� Ȯ���� �����ϰ� �����. (���� 6�Һ�)", "�ü�",
            Resources.Load<Sprite>("Character/Beasthunter"), Resources.Load<Sprite>("Synergy/GreenSR"), Resources.Load<Sprite>("Synergy/GreenSL"),
            Resources.Load<Sprite>("CardBackGround"), 3, 3, 6));

        cardList.Add(new CardList(4, "������ ������", "Ư����", 35, 120, "�����", 3,
            "���� ���� ������ 3�� ���ظ� ������. �� ��ų�� ����� �� ���� ���� �� ��� ���� (��Ÿ�� 3��) (���� 2�Һ�)",
            "�̹� �� ���� ���� ���� ���� ���ظ� ���� �� ���� 2�� ���ظ� �߰��� ������. (���� 4�Һ�)", "�ü�", Resources.Load<Sprite>("Character/Outlaw"),
            Resources.Load<Sprite>("Synergy/YellowSR"), Resources.Load<Sprite>("Synergy/YellowSL"), Resources.Load<Sprite>("CardBackGround"), 3, 2, 4));

        cardList.Add(new CardList(5, "�ұ��� ���к�", "�����", 15, 130, "�Ķ���", 2,
            "5�� ���� ���� ���� ���� ���ݷ� -2 (��Ÿ�� 5��) (���� 3�Һ�)",
            "���� ���� �Ʊ����� ���� + 4 (���� 3�Һ�)", "���к�", Resources.Load<Sprite>("Character/Shielder"),
            Resources.Load<Sprite>("Synergy/BlueSR"), Resources.Load<Sprite>("Synergy/BlueSL"), Resources.Load<Sprite>("CardBackGround"), 5, 3, 3));

        cardList.Add(new CardList(6, "â�⺴", "Ư����", 25, 140, "������", 2,
            "�̹� �� ���� ���� ���� ������ �Դ� ���ظ� �������� �Ѵ�. (��Ÿ�� 6��) (���� 7�Һ�)",
            "�̹� �� ���� ���� ���� ���� ������ ��� �´´�. (���� 4�Һ�)", "���к�", Resources.Load<Sprite>("Character/Lancer"),
            Resources.Load<Sprite>("Synergy/RedSR"), Resources.Load<Sprite>("Synergy/RedSL"), Resources.Load<Sprite>("CardBackGround"), 6, 7, 4));

        cardList.Add(new CardList(7, "ȭ�� ������", "�����", 23, 115, "������", 2,
            "���� ���� ������ 6�� ���ظ� ������ �ڽſ��� 2�� ���ظ� ������. (��Ÿ�� 3��) (���� 4�Һ�)",
            "���� ���� ������ 1�� ���ظ� ������. (���� 0�Һ�)", "������", Resources.Load<Sprite>("Character/FireMage"),
            Resources.Load<Sprite>("Synergy/RedSR"), Resources.Load<Sprite>("Synergy/RedSL"), Resources.Load<Sprite>("CardBackGround"), 3, 4, 0));

        cardList.Add(new CardList(8, "����ģ ����", "Ư����", 33, 128, "�Ķ���", 3,
            "���� ���� ������ 50�� ���ظ� ������. (��Ÿ�� 7��) (���� 15�Һ�)",
            "�̹� �� ���� ���� ���� �Ʊ� ��ų�� ���� �Ҹ� -1 (���� 0�Һ�)", "������", Resources.Load<Sprite>("Character/Wizard"),
            Resources.Load<Sprite>("Synergy/BlueSR"), Resources.Load<Sprite>("Synergy/BlueSL"), Resources.Load<Sprite>("CardBackGround"), 7, 15, 0));

        cardList.Add(new CardList(9, "�ʱ� �Ű�", "�����", 10, 110, "�����", 2,
            "��� �Ʊ��� ü���� 3ȸ���Ѵ�. (��Ÿ�� 4��) (���� 10�Һ�)",
            "������ �Ʊ��� �޽� -1 (���� 4�Һ�)", "����", Resources.Load<Sprite>("Character/Priest"),
            Resources.Load<Sprite>("Synergy/YellowSR"), Resources.Load<Sprite>("Synergy/YellowSL"), Resources.Load<Sprite>("CardBackGround"), 4, 10, 4));

        cardList.Add(new CardList(10, "���� ������", "Ư����", 25, 120, "ȸ��", 2,
            "������ �Ʊ��� ü���� 6ȸ���Ѵ�. (��Ÿ�� 3��) (���� 3�Һ�)",
            "���� ���� �Ʊ��� ü���� 3ȸ���Ѵ�. (���� 3�Һ�)", "����", Resources.Load<Sprite>("Character/HighPriest"),
            Resources.Load<Sprite>("Synergy/WhiteSR"), Resources.Load<Sprite>("Synergy/WhiteSL"), Resources.Load<Sprite>("CardBackGround"), 3, 3, 3));

        cardList.Add(new CardList(11, "����˻�", "�����", 20, 120, "�����", 1,
            "������ ���ظ� 15�����ϴ�. �̹� �� ���� ���� ���� ���� ���ݷ��� 5 �����մϴ�. (��Ÿ�� 7��) (���� 10�Һ�)",
            "�� ��ų�� 4�� ����ϸ� ü���� 20ȸ���Ѵ�. (���� 4�Һ�)", "�˰�", Resources.Load<Sprite>("Character/SwordMan"),
            Resources.Load<Sprite>("Synergy/YellowSR"), Resources.Load<Sprite>("Synergy/YellowSL"), Resources.Load<Sprite>("CardBackGround"), 7, 10, 4));

        cardList.Add(new CardList(12, "���� �ڰ�", "�����", 25, 115, "ȸ��", 1,
            "���� ���� ������ 10�� ���ظ� ������. �̹� �� ���� ���� ���� ������ ������ ���� ������ ������ �� �� ����. (��Ÿ�� 4��) (���� 4�Һ�)",
            "���� ���� ������ 50%�� Ȯ���� 4�� ���ظ� ������. (���� 2�Һ�)", "�ϻ���", Resources.Load<Sprite>("Character/Assassin"),
            Resources.Load<Sprite>("Synergy/WhiteSR"), Resources.Load<Sprite>("Synergy/WhiteSL"), Resources.Load<Sprite>("CardBackGround"), 4, 4, 2));

        cardList.Add(new CardList(13, "������ �߸�", "�����", 15, 120, "ȸ��", 2,
            "���� ���� ������ 3�� ���ظ� ������ 5�� ���¸� ��´�. (��Ÿ�� 2��) (���� 3�Һ�)",
            "���� ���� �Ʊ����� �̹� �� ���� ���ݷ� +2 ���� +2 (���� 3�Һ�)", "�߸�", Resources.Load<Sprite>("Character/Dr"),
            Resources.Load<Sprite>("Synergy/WhiteSR"), Resources.Load<Sprite>("Synergy/WhiteSL"), Resources.Load<Sprite>("CardBackGround"), 2, 3, 3));

        cardList.Add(new CardList(14, "������", "�����", 20, 120, "�ʷϻ�", 1,
            "�̹� �� ���� �ƹ��� ���ظ� ���� �ʴ´�. (��Ÿ�� 10��) (���� 8�Һ�)",
            "�� ī���� ���ݷ� + 1 �� ��ų�� ������ ���ݷ��� ���� �����ϸ� �������. (���� 3�Һ�)", "������", Resources.Load<Sprite>("Character/Fighter"),
            Resources.Load<Sprite>("Synergy/GreenSR"), Resources.Load<Sprite>("Synergy/GreenSL"), Resources.Load<Sprite>("CardBackGround"), 10, 8, 3));

        cardList.Add(new CardList(15, "�Ҹ��� ���", "�����", 20, 120, "�Ķ���", 1,
            "�� ī�尡 ���� ���� �� ���� ���ݷ��� ������ �̹� �� ���� ���ݷ� + 10 (��Ÿ�� 2��) (���� 4�Һ�)",
            "�̹� �� ���� ���� ���� ���� ������ �� �������� ���� �� ī���� ���ݷ� + 3 (���� 0�Һ�)", "���", Resources.Load<Sprite>("Character/Knight"),
            Resources.Load<Sprite>("Synergy/BlueSR"), Resources.Load<Sprite>("Synergy/BlueSL"), Resources.Load<Sprite>("CardBackGround"), 2, 4, 0));
    }
}
