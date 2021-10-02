using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameResultManager : MonoBehaviour
{
    public bool BattleResult;
    public GameObject BattleSceneResult;
    public Text ResultText;

    // Start is called before the first frame update
    public void Start()
    {
        BattleSceneResult = GameObject.Find("GameResult").gameObject;
        BattleResult = BattleSceneResult.GetComponent<GameResult>().IsWin;
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
    }

    private void OnDisable()
    {
        Destroy(GameObject.Find("GameResult").gameObject); 
    }
}
