using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemDrag : MonoBehaviour
{
    public int itemId;
    public bool _isUse = false;

    private Vector2 myPos;
    public Sprite defalutSprite;
    bool equip = false;
    GameObject tempSr;
    EquipManager equipManager;
    string tempStr;
    public TextMeshPro infoText;

    private void Start()
    {
        myPos = transform.localPosition;
        infoText = GameObject.Find("ItemInfoText").GetComponent<TextMeshPro>();
        equipManager = GameObject.Find("InvenManager").GetComponent<EquipManager>();
    }
    
    private void OnMouseUp()
    {
        if (equip)
        {
            if (GetComponent<SpriteRenderer>().sprite.name.Equals("yongsamozip"))
            {
                transform.localPosition = myPos;
                Mozip();
                GetComponent<SpriteRenderer>().sortingOrder = 5;
            }
            else
            {
                if (tempStr.Equals("0")) equipManager.merc[equipManager.nowUseMercId].GetComponent<ThisCard>().items[0] = itemId;
                else if (tempStr.Equals("1")) equipManager.merc[equipManager.nowUseMercId].GetComponent<ThisCard>().items[1] = itemId;

                tempSr.GetComponent<SpriteRenderer>().sprite = GetComponent<SpriteRenderer>().sprite;
                GetComponent<SpriteRenderer>().sprite = defalutSprite;
                transform.localPosition = myPos;
                equip = false;
                _isUse = false;
                GetComponent<SpriteRenderer>().sortingOrder = 5;
            }
        }
        transform.localPosition = myPos;
    }
    void OnMouseDrag()
    {
        if (!GetComponent<SpriteRenderer>().sprite.name.Equals("Square"))
        {
            GetComponent<SpriteRenderer>().sortingOrder = 6;
            Vector2 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = objPosition;
        }
    }

    private void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.CompareTag("ItemSlot"))
        {
            if (coll.GetComponent<SpriteRenderer>().sprite.name.Equals("Square"))
            {
                tempStr = coll.gameObject.name;
                equip = true;
                tempSr = coll.gameObject;
            }
        } else
        {
            equip = false;
        }
    }
    private void OnMouseDown()
    {
        if (!GetComponent<SpriteRenderer>().sprite.name.Equals("Square"))
        {
            infoText.text = ItemDB.itemList[itemId].explanation;
        }
    }

    void Mozip()
    {
        infoText.text = "용사 모집권을 사용하셨습니다! 용사를 한 명 추가로 영입할 수 있습니다.";
        GotchaData.poolToken++;
        GetComponent<SpriteRenderer>().sprite = defalutSprite;
    }
}
