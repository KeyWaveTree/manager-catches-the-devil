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
        itemList.Add(new ItemList(1, 500, "행운의 네잎클로버", "행운의 네잎클로버 : 장착한 용사의 공격력 +6", Resources.Load<Sprite>("Item/clover")));
        itemList.Add(new ItemList(2, 1200, "대량 회복포션", "대량 회복포션 : 장착한 용사의 체력을 스테이지 진입 시 40회복", Resources.Load<Sprite>("Item/FullPotion")));
        itemList.Add(new ItemList(3, 800, "중량 회복포션", "중량 회복포션 : 장착한 용사의 체력을 스테이지 진입 시 30회복", Resources.Load<Sprite>("Item/MiddlePotion")));
        itemList.Add(new ItemList(4, 400, "소량 회복포션", "소량 회복포션 : 장착한 용사의 체력을 스테이지 진입 시 20회복", Resources.Load<Sprite>("Item/LessPotion")));
        itemList.Add(new ItemList(5, 600, "붉은 마법석", "붉은 마법석 : 장착한 용사의 공격력 +4 체력 +3", Resources.Load<Sprite>("Item/magic_jewel")));
        itemList.Add(new ItemList(6, 500, "마력 스태프", "마력 스태프 : 장착한 용사의 공격력 +5", Resources.Load<Sprite>("Item/Magic_Staff")));
        itemList.Add(new ItemList(7, 1300, "성스러운 펜던트", "성스러운 펜던트 : 장착한 용사의 방어력 +10", Resources.Load<Sprite>("Item/pandant")));
        itemList.Add(new ItemList(8, 700, "용사전용 방패", "용사전용 방패 : 장착한 용사의 방어력 +8", Resources.Load<Sprite>("Item/RoundShield")));
        itemList.Add(new ItemList(9, 400, "싸구려 장화", "싸구려 장화 : 장착한 용사의 공격력 +3", Resources.Load<Sprite>("Item/shoes")));
        itemList.Add(new ItemList(10, 1500, "신의 앙크", "신의 앙크 : 장착한 용사의 체력 +10", Resources.Load<Sprite>("Item/TheCross")));
        itemList.Add(new ItemList(11, 1200, "저주받은 부두인형", "저주받은 부두인형 : 장착한 용사의 공격력 +10 체력 -10", Resources.Load<Sprite>("Item/Voodoo_Doll_Cursed")));
        itemList.Add(new ItemList(12, 2300, "용사의 브로드소드", "용사의 브로드소드 : 장착한 용사의 공격력 +15", Resources.Load<Sprite>("Item/BroadSword")));
        itemList.Add(new ItemList(13, 1900, "무쇠 건틀릿", "무쇠 건틀릿 : 장착한 용사의 공격력 +7 방어력 +7", Resources.Load<Sprite>("Item/Gauntlets")));
        itemList.Add(new ItemList(14, 2000, "왕실 체력반지", "왕실 체력반지 : 장착한 용사의 체력 +15", Resources.Load<Sprite>("Item/Healthy_Ring")));
        itemList.Add(new ItemList(15, 2000, "왕실 마법반지", "왕실 마법반지 : 장착한 용사의 공격력 +13", Resources.Load<Sprite>("Item/Magic_Damage_Ring")));
        itemList.Add(new ItemList(16, 1900, "무쇠 철퇴", "무쇠 철퇴 : 장착한 용사의 공격력 +7 체력 +7", Resources.Load<Sprite>("Item/Mace")));
        itemList.Add(new ItemList(17, 1500, "용사 모집서", "용사 모집서 : 사용 시 용사를 한 명 더 모집할 수 있다.", Resources.Load<Sprite>("Item/yongsamozip")));
        itemList.Add(new ItemList(18, 800, "고양이의 시선", "고양이의 시선 : 장착한 용사의 공격력 +5 방어력 +3", Resources.Load<Sprite>("Item/cat and anjfqhk")));
        itemList.Add(new ItemList(19, 1600, "고급진 새총", "고급진 새총 : 장착한 용사의 공격력 +10", Resources.Load<Sprite>("Item/Bird_Gun")));
        itemList.Add(new ItemList(20, 3000, "기분 나쁜 가면", "기분 나쁜 가면 : 장착한 용사의 공격력 +20 체력 -20", Resources.Load<Sprite>("Item/Bad_Mood_Mask")));
    }
}
