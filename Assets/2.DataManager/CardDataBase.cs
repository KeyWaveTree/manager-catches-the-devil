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

        //시너지 예시 색깔S방향 = RedSR 빨간색 오른쪽
        //카드 추가 방법 Add(아이디, 카드 이름, 카드 레어도, 공격력, 체력, 방어력, 시너지, 마나, 필드스킬,
        //벤치스킬, 직업, 캐릭터 이미지, 시너지 이미지 오른쪽, 시너지 이미지 왼쪽, 뒷배경, 필드스킬쿨타임, 필드스킬마나소비량, 벤치스킬마나소비량
        cardList.Add(new CardList(0, "", "", 0, 0, "", 0,
                    "", "", "", Resources.Load<Sprite>("Character/DefaultCard"), null, null, null, 0, 0, 0));
                                                                
        cardList.Add(new CardList(1, "용사 지망생", "평범한", 20, 120, "빨간색", 1,
            "출전 중인 적에게 3의 피해를 입힌다. (쿨타임 1턴) (마나 3소비)",
            "출전 중인 아군의 공격력 +2 (마나 1소비)", "전사", Resources.Load<Sprite>("Character/Braveheart"),
            Resources.Load<Sprite>("Synergy/RedSR"), Resources.Load<Sprite>("Synergy/RedSL"),
            Resources.Load<Sprite>("CardBackGround"), 1, 3, 1));

        cardList.Add(new CardList(2, "왕실 대장군", "특별한", 30, 135, "초록색", 2,
            "출전 중인 적의 다음 공격을 봉인한다. (쿨타임 4턴) (마나 6소비)",
            "출전 중인 아군이 피해를 입으면 공격한 적의 공격력 -1 (마나 2소비)", "전사", Resources.Load<Sprite>("Character/Hammer"),
            Resources.Load<Sprite>("Synergy/GreenSR"), Resources.Load<Sprite>("Synergy/GreenSL"),
            Resources.Load<Sprite>("CardBackGround"), 4, 6, 2));

        cardList.Add(new CardList(3, "야수 사냥꾼", "평범한", 30, 100, "초록색", 2,
            "출전 중인 적에게 25%의 확률로 10의 피해를 입힌다. (쿨타임 3턴) (마나 3소비)",
            "출전 중인 적을 실명시켜 다음 공격을 5%의 확률로 실패하게 만든다. (마나 6소비)", "궁수",
            Resources.Load<Sprite>("Character/Beasthunter"), Resources.Load<Sprite>("Synergy/GreenSR"), Resources.Load<Sprite>("Synergy/GreenSL"),
            Resources.Load<Sprite>("CardBackGround"), 3, 3, 6));

        cardList.Add(new CardList(4, "석양의 무법자", "특별한", 35, 120, "노란색", 3,
            "출전 중인 적에게 3의 피해를 입힌다. 이 스킬을 사용한 턴 동안 여러 번 사용 가능 (쿨타임 3턴) (마나 2소비)",
            "이번 턴 동안 출전 중인 적이 피해를 입을 때 마다 2의 피해를 추가로 입힌다. (마나 4소비)", "궁수", Resources.Load<Sprite>("Character/Outlaw"),
            Resources.Load<Sprite>("Synergy/YellowSR"), Resources.Load<Sprite>("Synergy/YellowSL"), Resources.Load<Sprite>("CardBackGround"), 3, 2, 4));

        cardList.Add(new CardList(5, "불굴의 방패병", "평범한", 15, 130, "파란색", 2,
            "5턴 동안 출전 중인 적의 공격력 -2 (쿨타임 5턴) (마나 3소비)",
            "출전 중인 아군에게 방어력 + 4 (마나 3소비)", "방패병", Resources.Load<Sprite>("Character/Shielder"),
            Resources.Load<Sprite>("Synergy/BlueSR"), Resources.Load<Sprite>("Synergy/BlueSL"), Resources.Load<Sprite>("CardBackGround"), 5, 3, 3));

        cardList.Add(new CardList(6, "창기병", "특별한", 25, 140, "빨간색", 2,
            "이번 턴 동안 출전 중인 적에게 입는 피해를 절반으로 한다. (쿨타임 6턴) (마나 7소비)",
            "이번 턴 동안 출전 중인 적의 공격을 대신 맞는다. (마나 4소비)", "방패병", Resources.Load<Sprite>("Character/Lancer"),
            Resources.Load<Sprite>("Synergy/RedSR"), Resources.Load<Sprite>("Synergy/RedSL"), Resources.Load<Sprite>("CardBackGround"), 6, 7, 4));

        cardList.Add(new CardList(7, "화염 마법사", "평범한", 23, 115, "빨간색", 2,
            "출전 중인 적에게 6의 피해를 입히고 자신에게 2의 피해를 입힌다. (쿨타임 3턴) (마나 4소비)",
            "출전 중인 적에게 1의 피해를 입힌다. (마나 0소비)", "마법사", Resources.Load<Sprite>("Character/FireMage"),
            Resources.Load<Sprite>("Synergy/RedSR"), Resources.Load<Sprite>("Synergy/RedSL"), Resources.Load<Sprite>("CardBackGround"), 3, 4, 0));

        cardList.Add(new CardList(8, "깨우친 현자", "특별한", 33, 128, "파란색", 3,
            "출전 중인 적에게 50의 피해를 입힌다. (쿨타임 7턴) (마나 15소비)",
            "이번 턴 동안 출전 중인 아군 스킬의 마나 소모량 -1 (마나 0소비)", "마법사", Resources.Load<Sprite>("Character/Wizard"),
            Resources.Load<Sprite>("Synergy/BlueSR"), Resources.Load<Sprite>("Synergy/BlueSL"), Resources.Load<Sprite>("CardBackGround"), 7, 15, 0));

        cardList.Add(new CardList(9, "초급 신관", "평범한", 10, 110, "노란색", 2,
            "모든 아군의 체력을 3회복한다. (쿨타임 4턴) (마나 10소비)",
            "지정한 아군의 휴식 -1 (마나 4소비)", "사제", Resources.Load<Sprite>("Character/Priest"),
            Resources.Load<Sprite>("Synergy/YellowSR"), Resources.Load<Sprite>("Synergy/YellowSL"), Resources.Load<Sprite>("CardBackGround"), 4, 10, 4));

        cardList.Add(new CardList(10, "고위 성직자", "특별한", 25, 120, "회색", 2,
            "지정한 아군의 체력을 6회복한다. (쿨타임 3턴) (마나 3소비)",
            "출전 중인 아군의 체력을 3회복한다. (마나 3소비)", "사제", Resources.Load<Sprite>("Character/HighPriest"),
            Resources.Load<Sprite>("Synergy/WhiteSR"), Resources.Load<Sprite>("Synergy/WhiteSL"), Resources.Load<Sprite>("CardBackGround"), 3, 3, 3));

        cardList.Add(new CardList(11, "방랑검사", "평범한", 20, 120, "노란색", 1,
            "적에게 피해를 15입힙니다. 이번 턴 동안 출전 중인 적의 공격력이 5 감소합니다. (쿨타임 7턴) (마나 10소비)",
            "이 스킬을 4번 사용하면 체력을 20회복한다. (마나 4소비)", "검객", Resources.Load<Sprite>("Character/SwordMan"),
            Resources.Load<Sprite>("Synergy/YellowSR"), Resources.Load<Sprite>("Synergy/YellowSL"), Resources.Load<Sprite>("CardBackGround"), 7, 10, 4));

        cardList.Add(new CardList(12, "밤의 자객", "평범한", 25, 115, "회색", 1,
            "출전 중인 적에게 10의 피해를 입힌다. 이번 턴 동안 출전 중인 적에게 공격을 받지 않으며 공격을 할 수 없다. (쿨타임 4턴) (마나 4소비)",
            "출전 중인 적에게 50%의 확률로 4의 피해를 입힌다. (마나 2소비)", "암살자", Resources.Load<Sprite>("Character/Assassin"),
            Resources.Load<Sprite>("Synergy/WhiteSR"), Resources.Load<Sprite>("Synergy/WhiteSL"), Resources.Load<Sprite>("CardBackGround"), 4, 4, 2));

        cardList.Add(new CardList(13, "광기의 발명가", "평범한", 15, 120, "회색", 2,
            "출전 중인 적에게 3의 피해를 입히고 5의 방어력를 얻는다. (쿨타임 2턴) (마나 3소비)",
            "출전 중인 아군에게 이번 턴 동안 공격력 +2 방어력 +2 (마나 3소비)", "발명가", Resources.Load<Sprite>("Character/Dr"),
            Resources.Load<Sprite>("Synergy/WhiteSR"), Resources.Load<Sprite>("Synergy/WhiteSL"), Resources.Load<Sprite>("CardBackGround"), 2, 3, 3));

        cardList.Add(new CardList(14, "무도가", "평범한", 20, 120, "초록색", 1,
            "이번 턴 동안 아무런 피해를 입지 않는다. (쿨타임 10턴) (마나 8소비)",
            "이 카드의 공격력 + 1 이 스킬로 증가된 공격력은 적을 공격하면 사라진다. (마나 3소비)", "격투가", Resources.Load<Sprite>("Character/Fighter"),
            Resources.Load<Sprite>("Synergy/GreenSR"), Resources.Load<Sprite>("Synergy/GreenSL"), Resources.Load<Sprite>("CardBackGround"), 10, 8, 3));

        cardList.Add(new CardList(15, "불멸의 기사", "평범한", 20, 120, "파란색", 1,
            "이 카드가 출전 중인 적 보다 공격력이 높으면 이번 턴 동안 공격력 + 10 (쿨타임 2턴) (마나 4소비)",
            "이번 턴 동안 출전 중인 적이 죽으면 이 스테이지 동안 이 카드의 공격력 + 3 (마나 0소비)", "기사", Resources.Load<Sprite>("Character/Knight"),
            Resources.Load<Sprite>("Synergy/BlueSR"), Resources.Load<Sprite>("Synergy/BlueSL"), Resources.Load<Sprite>("CardBackGround"), 2, 4, 0));
    }
}
