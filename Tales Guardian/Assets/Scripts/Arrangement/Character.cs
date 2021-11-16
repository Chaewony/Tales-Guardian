using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> allCharacter;
    [SerializeField]
    private Image[] charSlot; //캐릭터 선택창에 띄워질 이미지 슬롯들
    [SerializeField]
    private Image illustSlot; //캐릭터 선택후 배경에 띄워질 일러스트 이미지 슬롯z
    [SerializeField]
    private GameObject[] slot;
    public GameObject RepresentativeCharacterImage;

    public void Start()
    {
        for(int i = 0; i < allCharacter.Count; i++)
        {
            allCharacter[i] = GameObject.Find("DDCharacters").transform.GetChild(i).gameObject;
        }

        //실험용 코드
        for (int i = 0; i < allCharacter.Count; i++)
        {
            //모든 캐릭터 이미지들 이미지 슬롯에 넣기
            if (allCharacter[i].GetComponent<CharactersPrefab>().myIsOwning && allCharacter[i].GetComponent<CharactersPrefab>().myLocation == -1)
            {
                //Debug.Log(i);
                slot[i].SetActive(true);
                charSlot[i].sprite = allCharacter[i].GetComponent<CharactersPrefab>().mySprite;
            }
        }
    }

    public void UpdateRepresentativeChar(int CharNum)
    {
        for (int i = 0; i < allCharacter.Count; i++)
        {
            allCharacter[i].GetComponent<CharactersPrefab>().IsRepreChar = false;
        }
        allCharacter[CharNum].GetComponent<CharactersPrefab>().IsRepreChar = true;
        //RepresentativeCharacterImage.GetComponent<Image>().sprite = allCharacter[CharNum].GetComponent<CharactersPrefab>().mySprite;
        RepresentativeCharacterImage.GetComponent<Image>().sprite = allCharacter[CharNum].GetComponent<CharactersPrefab>().myIllustSprite;
        RepresentativeCharacterImage.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    }

    public void ShowCharacters()
    {
        for (int i = 0; i < allCharacter.Count; i++)
        {
            //모든 캐릭터 이미지들 이미지 슬롯에 넣기
            if (allCharacter[i].GetComponent<CharactersPrefab>().myIsOwning)
            {
                charSlot[i].sprite = allCharacter[i].GetComponent<CharactersPrefab>().mySprite;
                charSlot[i].color = new Color(charSlot[i].color.r, charSlot[i].color.g, charSlot[i].color.b, 1.0f);
            }
            else
            {
                charSlot[i].sprite = allCharacter[i].GetComponent<CharactersPrefab>().mySprite;
                //흑백처리 알아보기 or 검정 반투명 레이어 끼얹기
                charSlot[i].color = new Color(charSlot[i].color.r, charSlot[i].color.g, charSlot[i].color.b, 0.5f);
            }
        }
    }

    public void SelectMainCharacter(int index) //메인캐릭터 선택 후 화면에 보이지는 이미지
    {
        for(int i = 0; i<allCharacter.Count;i++)
        {
            allCharacter[i].GetComponent<CharactersPrefab>().IsRepreChar = false;
        }
        allCharacter[index].GetComponent<CharactersPrefab>().IsRepreChar = true;
        illustSlot.sprite = allCharacter[index].GetComponent<CharactersPrefab>().myIllustSprite;
    }
    /*
    public void IfSetArrangementShowSlotCharacters() //가지고있는 캐릭터들만 표시
    {
        for (int i = 0; i < allCharacter.Count; i++)
        {
            //모든 캐릭터 이미지들 이미지 슬롯에 넣기
            if (allCharacter[i].GetComponent<CharactersPrefab>().myIsOwning && allCharacter[i].GetComponent<CharactersPrefab>().myLocation == -1)
            {
                //Debug.Log(i);
                slot[i].SetActive(true);
                charSlot[i].sprite = allCharacter[i].GetComponent<CharactersPrefab>().mySprite;
            }
        }
    }
    */
    public void ShowOwningCharacters() //가지고있는 캐릭터들만 표시
    {
        for (int i = 0; i < allCharacter.Count; i++)
        {
            slot[i].SetActive(false);
        }
        for (int i = 0; i < allCharacter.Count; i++)
        {
            //모든 캐릭터 이미지들 이미지 슬롯에 넣기
            if (allCharacter[i].GetComponent<CharactersPrefab>().myIsOwning && allCharacter[i].GetComponent<CharactersPrefab>().myLocation == -1)
            {
                slot[i].SetActive(true);
                //charSlot[i].sprite = allCharacter[i].GetComponent<CharactersPrefab>().mySprite;
                charSlot[i].sprite = allCharacter[i].GetComponent<CharactersPrefab>().myCardSprite;
            }
        }
    }

    public void ShowDefTypeCharacters() //가지고있는 캐릭터들만 표시
    {
        for (int i = 0; i < allCharacter.Count; i++)
        {
            //모든 캐릭터 이미지들 이미지 슬롯에 넣기
            if (allCharacter[i].GetComponent<CharactersPrefab>().myIsOwning && allCharacter[i].GetComponent<CharactersPrefab>().myPosType == "Def")
            {
                slot[i].SetActive(true);
                charSlot[i].sprite = allCharacter[i].GetComponent<CharactersPrefab>().mySprite;
            }
            else slot[i].SetActive(false);
        }
    }

    public void ShowAtkTypeCharacters() //가지고있는 캐릭터들만 표시
    {
        for (int i = 0; i < allCharacter.Count; i++)
        {
            //모든 캐릭터 이미지들 이미지 슬롯에 넣기
            if (allCharacter[i].GetComponent<CharactersPrefab>().myIsOwning && allCharacter[i].GetComponent<CharactersPrefab>().myPosType == "Atk")
            {
                slot[i].SetActive(true);
                charSlot[i].sprite = allCharacter[i].GetComponent<CharactersPrefab>().mySprite;
            }
            else slot[i].SetActive(false);
        }
    }

    public void ShowSupTypeCharacters() //가지고있는 캐릭터들만 표시
    {
        for (int i = 0; i < allCharacter.Count; i++)
        {
            //모든 캐릭터 이미지들 이미지 슬롯에 넣기
            if (allCharacter[i].GetComponent<CharactersPrefab>().myIsOwning && allCharacter[i].GetComponent<CharactersPrefab>().myPosType == "Sup")
            {
                slot[i].SetActive(true);
                charSlot[i].sprite = allCharacter[i].GetComponent<CharactersPrefab>().mySprite;
            }
            else slot[i].SetActive(false);
        }
    }
}

