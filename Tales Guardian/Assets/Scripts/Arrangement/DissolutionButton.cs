using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DissolutionButton : MonoBehaviour
{
    public ArrangementButtonType arrangeButtonType;
    [SerializeField]
    private int FieldNumber;
    [SerializeField]
    private GameObject ThisFieldDissolutionButton;
    [SerializeField]
    private GameObject AllCharacterManager;
    [SerializeField]
    private GameObject[] Characters;
    [SerializeField]
    private GameObject[] Field;

    public void Start()
    {
        ThisFieldDissolutionButton = this.gameObject;
        AllCharacterManager = GameObject.Find("AllCharacterManager");
        for (int i = 0; i < Characters.Length; i++)
        {
            Characters[i] = GameObject.Find("DDCharacters").transform.GetChild(i).gameObject;
        }
        for (int i = 0; i < Field.Length; i++)
        {
            Field[i] = GameObject.Find("DDField").transform.GetChild(i).gameObject;
        }
    }

    public void OnButtonClick()
    {
        switch (arrangeButtonType)
        {
            case ArrangementButtonType.Dissolution:
                Dissolution(FieldNumber);
                ThisFieldDissolutionButton.SetActive(false);
                AllCharacterManager.GetComponent<AllCharacterManager>().SeeNowFilterType();
                AllCharacterManager.GetComponent<AllCharacterManager>().ClearField();
                AllCharacterManager.GetComponent<AllCharacterManager>().DrawField();
                AllCharacterManager.GetComponent<AllCharacterManager>().FillField();
                break;
        }
    }

    public void Dissolution(int FieldNumber)
    {
        Debug.Log("c" + Characters[Field[FieldNumber].GetComponent<FieldPrefab>().myArrangedCharIndex].GetComponent<CharactersPrefab>().myLocation);
        Debug.Log("F" + Field[FieldNumber].GetComponent<FieldPrefab>().myArrangedCharIndex);
        Characters[Field[FieldNumber].GetComponent<FieldPrefab>().myArrangedCharIndex].GetComponent<CharactersPrefab>().myLocation = -1;
        Field[FieldNumber].GetComponent<FieldPrefab>().myArrangedCharIndex = -1;
        AllCharacterManager.GetComponent<AllCharacterManager>().ArrangementCount--;
    }

}
