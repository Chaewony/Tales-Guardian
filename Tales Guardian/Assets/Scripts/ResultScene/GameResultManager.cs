using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameResultManager : MonoBehaviour
{
    public bool BattleResult;
    public GameObject BattleSceneResult;
    public Text ResultText;

    public Image RepresentativeChar;
    public GameObject[] AllCharacter;
    public GameObject[] Stage;
    public Text StageText;
    public GameObject[] Star;
    public Image[] CardImage;
    public Text UseTurn;
    public int intiserUseTurn;

    // Start is called before the first frame update
    public void Start()
    {
        BattleSceneResult = GameObject.Find("GameResult").gameObject;
        for (int i = 0; i < Stage.Length; i++)
        {
            Stage[i] = GameObject.Find("DDStage").transform.GetChild(i).gameObject;
        }

        for (int i = 0; i < AllCharacter.Length; i++)
        {
            AllCharacter[i] = GameObject.Find("DDCharacters").transform.GetChild(i).gameObject;
        }
        for(int i = 0; i<Star.Length;i++)
        {
            Star[i].GetComponent<Image>().color = new Color(0.6f, 0.6f, 0.6f, 1f);
        }

        BattleResult = BattleSceneResult.GetComponent<GameResult>().IsWin;
        UseTurn.text = BattleSceneResult.GetComponent<GameResult>().UseTurn.ToString();
        intiserUseTurn = BattleSceneResult.GetComponent<GameResult>().UseTurn;
        SetResult();
    }

    private void SetResult()
    {
        if(BattleResult)
        {
            ResultText.text = "정화 성공";
        }
        else
        {
            ResultText.text = "정화 실패";
        }

        for(int i = 0;i<Stage.Length;i++)
        {
            if(Stage[i].GetComponent<StagePrefab>().StageisSelected == true)
            {
                StageText.text = "Stage" + Stage[i].GetComponent<StagePrefab>().StageTheme + "-" + i;
            }
        }
        for(int i = 0; i<AllCharacter.Length;i++)
        {
            if(AllCharacter[i].GetComponent<CharactersPrefab>().IsRepreChar == true)
            {
                RepresentativeChar.sprite = AllCharacter[i].GetComponent<CharactersPrefab>().mySprite;
            }
        }
        for(int i = 0;i< Stage[i].GetComponent<StagePrefab>().StageClearStandard.Length; i++)
        {
            if(Stage[i].GetComponent<StagePrefab>().StageClearStandard[i] > intiserUseTurn)
            {
                Star[i].GetComponent<Image>().color = new Color(1f, 1f, 0f, 1f);
            }
        }
    }

    private void OnDisable()
    {
        Destroy(GameObject.Find("GameResult").gameObject); 
    }
}
