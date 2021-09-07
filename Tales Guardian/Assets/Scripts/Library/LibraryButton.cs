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
    private List<GameObject> allCharacter;
    [SerializeField]
    public Image OnceDrawcharSlot;
    [SerializeField]
    public Image[] TenTimesDrawcharSlot;

    public GameObject OnceDrawPanel;
    public GameObject TenTimesDrawPanel;

    [SerializeField]
    private GameObject User;

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
                if (User.GetComponent<UserInformation>().MyHaveBookIndx > 0)
                {
                    OnceDrawPanel.SetActive(true);

                    a = draw.FunctionDraw();

                    OnceDrawcharSlot.sprite = allCharacter[a].GetComponent<CharactersPrefab>().mySprite; // 큰 카드 이미지로 변경 요망
                    OnceDrawcharSlot.color = new Color(OnceDrawcharSlot.color.r, OnceDrawcharSlot.color.g, OnceDrawcharSlot.color.b, 1.0f);

                    allCharacter[a].GetComponent<CharactersPrefab>().myHaveManyCard++;

                    if(allCharacter[a].GetComponent<CharactersPrefab>().myIsOwning == false)
                    {
                        allCharacter[a].GetComponent<CharactersPrefab>().myIsOwning = true;
                    }

                    if(allCharacter[a].GetComponent<CharactersPrefab>().myHaveManyCard == 2 || allCharacter[a].GetComponent<CharactersPrefab>().myHaveManyCard == 5 || allCharacter[a].GetComponent<CharactersPrefab>().myHaveManyCard == 9 || allCharacter[a].GetComponent<CharactersPrefab>().myHaveManyCard == 14 || allCharacter[a].GetComponent<CharactersPrefab>().myHaveManyCard == 20) {
                        allCharacter[a].GetComponent<CharactersPrefab>().myEnhanceStep++;
                        allCharacter[a].GetComponent<CharactersPrefab>().myHp = allCharacter[a].GetComponent<CharactersPrefab>().myHp * (1 + allCharacter[a].GetComponent<CharactersPrefab>().myEnhanceStep / 10);
                        allCharacter[a].GetComponent<CharactersPrefab>().myAr = allCharacter[a].GetComponent<CharactersPrefab>().myAr * (1 + allCharacter[a].GetComponent<CharactersPrefab>().myEnhanceStep / 10);
                        allCharacter[a].GetComponent<CharactersPrefab>().myAtk = allCharacter[a].GetComponent<CharactersPrefab>().myAtk * (1 + allCharacter[a].GetComponent<CharactersPrefab>().myEnhanceStep / 10);
                        allCharacter[a].GetComponent<CharactersPrefab>().myMr = allCharacter[a].GetComponent<CharactersPrefab>().myMr * (1 + allCharacter[a].GetComponent<CharactersPrefab>().myEnhanceStep / 10);
                    }

                    User.GetComponent<UserInformation>().MyHaveBookIndx--;
                    draw.DrawUserHaveBookMarker();
                }
                break;
            case LibraryButtonType.TenTimesDraw:
                if (User.GetComponent<UserInformation>().MyHaveBookIndx >= 10)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        TenTimesDrawPanel.SetActive(true);

                        a = draw.FunctionDraw();

                        if (allCharacter[a].GetComponent<CharactersPrefab>().myIsOwning == false)
                        {
                            allCharacter[a].GetComponent<CharactersPrefab>().myIsOwning = true;
                        }

                        TenTimesDrawcharSlot[i].sprite = allCharacter[a].GetComponent<CharactersPrefab>().mySprite; // 큰 카드 이미지로 변경 요망
                        TenTimesDrawcharSlot[i].color = new Color(TenTimesDrawcharSlot[i].color.r, TenTimesDrawcharSlot[i].color.g, TenTimesDrawcharSlot[i].color.b, 1.0f);

                        allCharacter[a].GetComponent<CharactersPrefab>().myHaveManyCard++;

                        if (allCharacter[a].GetComponent<CharactersPrefab>().myHaveManyCard == 2 || allCharacter[a].GetComponent<CharactersPrefab>().myHaveManyCard == 5|| allCharacter[a].GetComponent<CharactersPrefab>().myHaveManyCard == 9 || allCharacter[a].GetComponent<CharactersPrefab>().myHaveManyCard == 14|| allCharacter[a].GetComponent<CharactersPrefab>().myHaveManyCard == 20) {
                            allCharacter[a].GetComponent<CharactersPrefab>().myEnhanceStep++;
                            allCharacter[a].GetComponent<CharactersPrefab>().myHp = allCharacter[a].GetComponent<CharactersPrefab>().myHp * (1 + allCharacter[a].GetComponent<CharactersPrefab>().myEnhanceStep / 10);
                            allCharacter[a].GetComponent<CharactersPrefab>().myAr = allCharacter[a].GetComponent<CharactersPrefab>().myAr * (1 + allCharacter[a].GetComponent<CharactersPrefab>().myEnhanceStep / 10);
                            allCharacter[a].GetComponent<CharactersPrefab>().myAtk = allCharacter[a].GetComponent<CharactersPrefab>().myAtk * (1 + allCharacter[a].GetComponent<CharactersPrefab>().myEnhanceStep / 10);
                            allCharacter[a].GetComponent<CharactersPrefab>().myMr = allCharacter[a].GetComponent<CharactersPrefab>().myMr * (1 + allCharacter[a].GetComponent<CharactersPrefab>().myEnhanceStep / 10);
                        }
                    }

                    User.GetComponent<UserInformation>().MyHaveBookIndx -= 10;
                    draw.DrawUserHaveBookMarker();
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

