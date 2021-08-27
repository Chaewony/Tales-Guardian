using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LibraryButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public LibraryButtonType librarybuttonType;
    public GameObject SeePercentage;
    public Transform Scale;
    public Draw draw;

    [SerializeField]
    private List<CharacterInfo> allCharacter = new List<CharacterInfo>();
    [SerializeField]
    public Image OnceDrawcharSlot;
    [SerializeField]
    public Image[] TenTimesDrawcharSlot;

    public GameObject OnceDrawPanel;
    public GameObject TenTimesDrawPanel;
    // OnceDraw 1회뽑기
    //TenTimesDraw 10회뽑기
    //SeePercentage 확률확인
    //Close 창 닫기
    private int a;

    public void OnButtonClick()
    {
        switch (librarybuttonType)
        {
            case LibraryButtonType.OnceDraw:
                if (draw.HaveBookmarker > 0)
                {
                    OnceDrawPanel.SetActive(true);

                    a = draw.FunctionDraw();

                    OnceDrawcharSlot.sprite = allCharacter[a].mySprite; // 큰 카드 이미지로 변경 요망
                    OnceDrawcharSlot.color = new Color(OnceDrawcharSlot.color.r, OnceDrawcharSlot.color.g, OnceDrawcharSlot.color.b, 1.0f);

                    allCharacter[a].myHaveManyCard++;

                    if(allCharacter[a].myIsOwning == false)
                    {
                        allCharacter[a].myIsOwning = true;
                    }

                    if(allCharacter[a].myHaveManyCard == 2 || allCharacter[a].myHaveManyCard == 5 || allCharacter[a].myHaveManyCard == 9 || allCharacter[a].myHaveManyCard == 14 || allCharacter[a].myHaveManyCard == 20) {
                        allCharacter[a].myEnhanceStep++;
                        allCharacter[a].myHp = allCharacter[a].myHp * (1 + allCharacter[a].myEnhanceStep / 10);
                        allCharacter[a].myAr = allCharacter[a].myAr * (1 + allCharacter[a].myEnhanceStep / 10);
                        allCharacter[a].myAtk = allCharacter[a].myAtk * (1 + allCharacter[a].myEnhanceStep / 10);
                        allCharacter[a].myMr = allCharacter[a].myMr * (1 + allCharacter[a].myEnhanceStep / 10);
                    }

                    draw.HaveBookmarker--;
                }
                break;
            case LibraryButtonType.TenTimesDraw:
                if (draw.HaveBookmarker >= 10)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        TenTimesDrawPanel.SetActive(true);

                        a = draw.FunctionDraw();

                        if (allCharacter[a].myIsOwning == false)
                        {
                            allCharacter[a].myIsOwning = true;
                        }

                        TenTimesDrawcharSlot[i].sprite = allCharacter[a].mySprite; // 큰 카드 이미지로 변경 요망
                        TenTimesDrawcharSlot[i].color = new Color(TenTimesDrawcharSlot[i].color.r, TenTimesDrawcharSlot[i].color.g, TenTimesDrawcharSlot[i].color.b, 1.0f);

                        allCharacter[a].myHaveManyCard++;

                        if (allCharacter[a].myHaveManyCard == 2 || allCharacter[a].myHaveManyCard == 5|| allCharacter[a].myHaveManyCard == 9 || allCharacter[a].myHaveManyCard == 14|| allCharacter[a].myHaveManyCard == 20) {
                            allCharacter[a].myEnhanceStep++;
                            allCharacter[a].myHp = allCharacter[a].myHp * (1 + allCharacter[a].myEnhanceStep / 10);
                            allCharacter[a].myAr = allCharacter[a].myAr * (1 + allCharacter[a].myEnhanceStep / 10);
                            allCharacter[a].myAtk = allCharacter[a].myAtk * (1 + allCharacter[a].myEnhanceStep / 10);
                            allCharacter[a].myMr = allCharacter[a].myMr * (1 + allCharacter[a].myEnhanceStep / 10);
                        }
                    }
                    
                    draw.HaveBookmarker -= 10;
                }
                break;
            case LibraryButtonType.SeePercentage:
                SeePercentage.SetActive(true);
                break;
            case LibraryButtonType.CloseSeepercnetage:
                SeePercentage.SetActive(false);
                break;
            case LibraryButtonType.CloseTenTimesDraw:
                TenTimesDrawPanel.SetActive(false);
                break;
            case LibraryButtonType.CloseOnceDraw:
                OnceDrawPanel.SetActive(false);
                break;
            case LibraryButtonType.Close:
                SceneManager.LoadScene("Lobby");
                break;
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        Scale.localScale = new Vector3(1, 1, 1) * 1.1f;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        Scale.localScale = new Vector3(1, 1, 1);
    }

}

