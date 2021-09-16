using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ArrangeButtonCase2 : MonoBehaviour
{
    public ArrangementButtonType arrangeButtonType;
    public GameObject AllcharacterManager;
    public int SelectCharacterNumber;
    public GameObject ThisField;

    public void OnButtonClick()
    {
        switch (arrangeButtonType)
        {
            case ArrangementButtonType.CloseArragement:
                SceneManager.LoadScene("Lobby");// 배치 확인에서 거길로 넘어가는것도 확인해야됨
                break;
            case ArrangementButtonType.Field0:
                FieldFunction(0);
                break;             
            case ArrangementButtonType.Field1:
                FieldFunction(1);
                break;
            case ArrangementButtonType.Field2:
                FieldFunction(2);
                break;
            case ArrangementButtonType.Field3:
                FieldFunction(3);
                break;
            case ArrangementButtonType.Field4:
                FieldFunction(4);
                break;
            case ArrangementButtonType.Field5:
                FieldFunction(5);
                break;
            case ArrangementButtonType.Field6:
                FieldFunction(6);
                break;
            case ArrangementButtonType.Field7:
                FieldFunction(7);
                break;
            case ArrangementButtonType.Field8:
                FieldFunction(8);
                break;
        }
    }
    public void FieldFunction(int FieldNumber)
    {
        if(AllcharacterManager.GetComponent<AllCharacterManager>().SelectCharacterNumber != -1)
        {
            if(CheckSelectedCharIsInField(AllcharacterManager.GetComponent<AllCharacterManager>().SelectCharacterNumber, AllcharacterManager.GetComponent<AllCharacterManager>().CharacterPrefabs) == true)
            {//결과 2.
                Debug.Log("결과2");
                this.SelectCharacterNumber = AllcharacterManager.GetComponent<AllCharacterManager>().SelectCharacterNumber;
                AllcharacterManager.GetComponent<AllCharacterManager>().CharacterPrefabs[SelectCharacterNumber].GetComponent<CharactersPrefab>().myLocation = FieldNumber;
                AllcharacterManager.GetComponent<AllCharacterManager>().CharacterPrefabs[FieldNumber].GetComponent<CharactersPrefab>().myLocation = -1;
                AllcharacterManager.GetComponent<AllCharacterManager>().ClearField();
                AllcharacterManager.GetComponent<AllCharacterManager>().DrawField();
                AllcharacterManager.GetComponent<AllCharacterManager>().FillField();
                AllcharacterManager.GetComponent<AllCharacterManager>().ResetSelected();
                AllcharacterManager.GetComponent<AllCharacterManager>().CardSlot.ResetCardSlot();
            }
            else if(CheckSelectedCharIsInField(AllcharacterManager.GetComponent<AllCharacterManager>().SelectCharacterNumber, AllcharacterManager.GetComponent<AllCharacterManager>().CharacterPrefabs) == false)
            {
                if(AllcharacterManager.GetComponent<AllCharacterManager>().ArrangementCount != 4)
                {//결과 3.
                    if (SelectedFieldIsFill(FieldNumber, AllcharacterManager.GetComponent<AllCharacterManager>().CharacterPrefabs) == true)//애들 있는데 배치)
                    {//결과 3.1 
                        Debug.Log("결과3.1");
                        this.SelectCharacterNumber = AllcharacterManager.GetComponent<AllCharacterManager>().SelectCharacterNumber;
                        AllcharacterManager.GetComponent<AllCharacterManager>().CharacterPrefabs[FindWillSameFieldCharNumber(FieldNumber, AllcharacterManager.GetComponent<AllCharacterManager>().CharacterPrefabs)].GetComponent<CharactersPrefab>().myLocation = -1;
                        AllcharacterManager.GetComponent<AllCharacterManager>().CharacterPrefabs[SelectCharacterNumber].GetComponent<CharactersPrefab>().myLocation = FieldNumber;
                        AllcharacterManager.GetComponent<AllCharacterManager>().ClearField();
                        AllcharacterManager.GetComponent<AllCharacterManager>().DrawField();
                        AllcharacterManager.GetComponent<AllCharacterManager>().FillField();
                        AllcharacterManager.GetComponent<AllCharacterManager>().SeeNowFilterType();
                        AllcharacterManager.GetComponent<AllCharacterManager>().ResetSelected();
                        AllcharacterManager.GetComponent<AllCharacterManager>().CardSlot.ResetCardSlot();
                    }
                    else if (SelectedFieldIsFill(FieldNumber, AllcharacterManager.GetComponent<AllCharacterManager>().CharacterPrefabs) == false)// 애들 없는데 배치)
                    {//결과 3.2 
                        Debug.Log("결과3.2");
                        this.SelectCharacterNumber = AllcharacterManager.GetComponent<AllCharacterManager>().SelectCharacterNumber;
                        AllcharacterManager.GetComponent<AllCharacterManager>().CharacterPrefabs[SelectCharacterNumber].GetComponent<CharactersPrefab>().myLocation = FieldNumber;
                        AllcharacterManager.GetComponent<AllCharacterManager>().ClearField();
                        AllcharacterManager.GetComponent<AllCharacterManager>().DrawField();
                        AllcharacterManager.GetComponent<AllCharacterManager>().ArrangementCount++;
                        AllcharacterManager.GetComponent<AllCharacterManager>().FillField();
                        AllcharacterManager.GetComponent<AllCharacterManager>().ResetSelected();
                        AllcharacterManager.GetComponent<AllCharacterManager>().CardSlot.ResetCardSlot();
                    }
                }
                else if (AllcharacterManager.GetComponent<AllCharacterManager>().ArrangementCount == 4)
                { 
                    if(SelectedFieldIsFill(FieldNumber, AllcharacterManager.GetComponent<AllCharacterManager>().CharacterPrefabs) == true)//애들 있는데 배치)
                    {//결과 4. 
                        Debug.Log("결과4");
                        this.SelectCharacterNumber = AllcharacterManager.GetComponent<AllCharacterManager>().SelectCharacterNumber;
                        AllcharacterManager.GetComponent<AllCharacterManager>().CharacterPrefabs[FindWillSameFieldCharNumber(FieldNumber, AllcharacterManager.GetComponent<AllCharacterManager>().CharacterPrefabs)].GetComponent<CharactersPrefab>().myLocation = -1;
                        AllcharacterManager.GetComponent<AllCharacterManager>().CharacterPrefabs[SelectCharacterNumber].GetComponent<CharactersPrefab>().myLocation = FieldNumber;
                        AllcharacterManager.GetComponent<AllCharacterManager>().ClearField();
                        AllcharacterManager.GetComponent<AllCharacterManager>().DrawField();
                        AllcharacterManager.GetComponent<AllCharacterManager>().FillField();
                        AllcharacterManager.GetComponent<AllCharacterManager>().SeeNowFilterType();
                        AllcharacterManager.GetComponent<AllCharacterManager>().ResetSelected();
                        AllcharacterManager.GetComponent<AllCharacterManager>().CardSlot.ResetCardSlot();
                    }
                    else if(SelectedFieldIsFill(FieldNumber, AllcharacterManager.GetComponent<AllCharacterManager>().CharacterPrefabs) == false)// 애들 없는데 배치)
                    {//결과 5. 
                        Debug.Log("결과5");
                    }
                }
            }
        }
        else if(AllcharacterManager.GetComponent<AllCharacterManager>().SelectCharacterNumber == -1)
        {
            //결과 1.
            for(int i =0; i< AllcharacterManager.GetComponent<AllCharacterManager>().DissolutionButton.Length; i++)
            {
                AllcharacterManager.GetComponent<AllCharacterManager>().DissolutionButton[i].SetActive(false);
            }
            AllcharacterManager.GetComponent<AllCharacterManager>().DissolutionButton[FieldNumber].SetActive(true);  
            Debug.Log("결과1");
        }
    }
    public bool CheckSelectedCharIsInField(int SelectCharacterNumber, GameObject[] b)
    {
        if (b[SelectCharacterNumber].GetComponent<CharactersPrefab>().myLocation != -1) { Debug.Log(SelectCharacterNumber); return true; }
        else { Debug.Log(SelectCharacterNumber); return false; }
    }
    public bool SelectedFieldIsFill(int FieldNumber, GameObject[] b)
    {
        for(int i = 0; i<b.Length;i++)
        {
            if(b[i].GetComponent<CharactersPrefab>().myLocation == FieldNumber)
            {
                return true;
            }
        }
        return false;
    }
    public int FindWillSameFieldCharNumber(int FieldNumber, GameObject[] b)
    {
        int SameCharNumber = 17;
        for (int i = 0; i < b.Length; i++)
        {
            if (b[i].GetComponent<CharactersPrefab>().myLocation == FieldNumber)
            {
                SameCharNumber = i;
            }
        }
        return SameCharNumber;
    }
}
