using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class StageSelectionButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private Image[] charSlot;
    public GameObject AllCharacter;
    public Transform Scale;
    public StageSelectionButtonType Stageselectionbuttontype;
    public GameObject PlayerMoveMananger;
    public Text StageText;
    public int SelectStageNumber;
    public GameObject SelectStageInfo;
    public int StageSize;
    [SerializeField]
    public GameObject[] stage;
    public GameObject DontGoMessage;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Scale.localScale = new Vector3(1, 1, 1) * 1.1f;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        Scale.localScale = new Vector3(1, 1, 1);
    }

    public void Start()
    {
        for (int i = 0; i < stage.Length; i++)
        {
            stage[i] = GameObject.Find("DDStage").transform.GetChild(i).gameObject;
        }
        SelectStageNumber = 1;
        for(int i = 0;i<StageSize;i++)
        {
            stage[i].GetComponent<StagePrefab>().StageisSelected = false;
        }
    }
    
    public void FillCharSlot(Image[] TargetImage,StagePrefab StageEnemyInfo)
    {
        for(int i = 0; i < StageEnemyInfo.StageEnemysIndex.Length;i++)
        {
            TargetImage[i].sprite = AllCharacter.GetComponent<AllCharacters>().allCharacter[StageEnemyInfo.StageEnemysIndex[i]].mySprite;
            TargetImage[i].color = new Color(charSlot[i].color.r, charSlot[i].color.g, charSlot[i].color.b, 1.0f);
        }
        for(int i = StageEnemyInfo.StageEnemysIndex.Length; i < 5; i++)
        {
            TargetImage[i].sprite = null;
        }
    }

    public void SetIsSelected(int SelectStageNumber)
    {
        for(int i= 0; i<5; i++)
        {
            stage[i].GetComponent<StagePrefab>().StageisSelected = false;
        }
        stage[SelectStageNumber].GetComponent<StagePrefab>().StageisSelected = true;
    }

    public void OnButtonClick()
    {
        switch (Stageselectionbuttontype)
        {
            case StageSelectionButtonType.GoLobby:
                Debug.Log("GoLobby");
                SceneManager.LoadScene("Lobby");
                break;
            case StageSelectionButtonType.GoTheme:
                Debug.Log("GoTheme");
                SceneManager.LoadScene("Theme");
                break;
            case StageSelectionButtonType.FirstStage:
                Debug.Log("Select 1-1 Stage");
                PlayerMoveMananger.GetComponent<Player>().SelectStage = PlayerMoveMananger.GetComponent<Player>().Stage[0];
                PlayerMoveMananger.GetComponent<Player>().SelectStageAdress = 0;
                SelectStageNumber = 1;
                if (stage[SelectStageNumber - 1].GetComponent<StagePrefab>().StageCanSelected)
                {
                    FillCharSlot(charSlot, stage[SelectStageNumber - 1].GetComponent<StagePrefab>());
                    SetIsSelected(SelectStageNumber - 1);
                    StageText.text = "1 - " + SelectStageNumber;
                    SelectStageInfo.SetActive(true);
                }
                if (stage[SelectStageNumber - 1].GetComponent<StagePrefab>().StageCanSelected == false) { SelectStageInfo.SetActive(false); DontGoMessage.SetActive(true); }
                break;
            case StageSelectionButtonType.SecondStage:
                Debug.Log("Select 1-2 Stage");
                PlayerMoveMananger.GetComponent<Player>().SelectStage = PlayerMoveMananger.GetComponent<Player>().Stage[2];
                PlayerMoveMananger.GetComponent<Player>().SelectStageAdress = 2;
                SelectStageNumber = 2;
                if (stage[SelectStageNumber - 1].GetComponent<StagePrefab>().StageCanSelected)
                {
                    FillCharSlot(charSlot, stage[SelectStageNumber - 1].GetComponent<StagePrefab>());
                    SetIsSelected(SelectStageNumber - 1);
                    StageText.text = "1 - " + SelectStageNumber;
                    SelectStageInfo.SetActive(true);
                }
                if (stage[SelectStageNumber - 1].GetComponent<StagePrefab>().StageCanSelected == false) { SelectStageInfo.SetActive(false); DontGoMessage.SetActive(true); }
                break;
            case StageSelectionButtonType.ThirdStage:
                Debug.Log("Select 1-3 Stage");
                PlayerMoveMananger.GetComponent<Player>().SelectStage = PlayerMoveMananger.GetComponent<Player>().Stage[5];
                PlayerMoveMananger.GetComponent<Player>().SelectStageAdress = 5;
                SelectStageNumber = 3;
                if (stage[SelectStageNumber - 1].GetComponent<StagePrefab>().StageCanSelected)
                {
                    FillCharSlot(charSlot, stage[SelectStageNumber - 1].GetComponent<StagePrefab>());
                    SetIsSelected(SelectStageNumber - 1);
                    StageText.text = "1 - " + SelectStageNumber;
                    SelectStageInfo.SetActive(true);
                }
                if (stage[SelectStageNumber - 1].GetComponent<StagePrefab>().StageCanSelected == false) { SelectStageInfo.SetActive(false); DontGoMessage.SetActive(true); }
                break;
            case StageSelectionButtonType.ForthStage:
                Debug.Log("Select 1-4 Stage");
                PlayerMoveMananger.GetComponent<Player>().SelectStage = PlayerMoveMananger.GetComponent<Player>().Stage[8];
                PlayerMoveMananger.GetComponent<Player>().SelectStageAdress = 8;
                SelectStageNumber = 4;
                if (stage[SelectStageNumber - 1].GetComponent<StagePrefab>().StageCanSelected)
                {
                    FillCharSlot(charSlot, stage[SelectStageNumber - 1].GetComponent<StagePrefab>());
                    SetIsSelected(SelectStageNumber - 1);
                    StageText.text = "1 - " + SelectStageNumber;
                    SelectStageInfo.SetActive(true);
                }
                if (stage[SelectStageNumber - 1].GetComponent<StagePrefab>().StageCanSelected == false) { SelectStageInfo.SetActive(false); DontGoMessage.SetActive(true); }
                break;
            case StageSelectionButtonType.FifthStage:
                Debug.Log("Select 1-5 Stage");
                PlayerMoveMananger.GetComponent<Player>().SelectStage = PlayerMoveMananger.GetComponent<Player>().Stage[10];
                PlayerMoveMananger.GetComponent<Player>().SelectStageAdress = 10;
                SelectStageNumber = 5;
                if (stage[SelectStageNumber - 1].GetComponent<StagePrefab>().StageCanSelected)
                {
                    FillCharSlot(charSlot, stage[SelectStageNumber - 1].GetComponent<StagePrefab>());
                    SetIsSelected(SelectStageNumber - 1);
                    StageText.text = "1 - " + SelectStageNumber;
                    SelectStageInfo.SetActive(true);
                }
                if (stage[SelectStageNumber - 1].GetComponent<StagePrefab>().StageCanSelected == false) { SelectStageInfo.SetActive(false); DontGoMessage.SetActive(true); }
                break;
            case StageSelectionButtonType.IsNotStage:
                Debug.Log("Select Not Stage");
                PlayerMoveMananger.GetComponent<Player>().SelectStageAdress = 15;
                break;
            case StageSelectionButtonType.GameStartGoButton:
                SceneManager.LoadScene("BattleArrange");
                break;
            case StageSelectionButtonType.CloseSelectStageInfo:
                SelectStageInfo.SetActive(false); 
                break;
            case StageSelectionButtonType.CloseDontGoMessage:
                DontGoMessage.SetActive(false);
                break;
        }
    }
}
