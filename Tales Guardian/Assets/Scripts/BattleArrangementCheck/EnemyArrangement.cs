using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyArrangement : MonoBehaviour
{
    // 에너미 인포들
    public List<GameObject> allEnemy = new List<GameObject>(); //스크립터블 오브젝트
    // 에너미 필드
    public Image[] EnemyFields;
    // 스테이지 인포
    public List<GameObject> allStage = new List<GameObject>(); //스크립터블 오브젝트

    int stageIndex;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < allEnemy.Count; i++)
        {
            allEnemy[i] = GameObject.Find("DDEnemy").transform.GetChild(i).gameObject;
        }
        for (int i = 0; i < allStage.Count; i++)
        {
            allStage[i] = GameObject.Find("DDStage").transform.GetChild(i).gameObject;
        }
        for (int i = 0;i<EnemyFields.Length;i++)
        {
            EnemyFields[i].color = new Color(0.55f, 0.55f, 0.55f, 0.13f);
        }
        CheckStage();
        SetImage();
    }

    void CheckStage()
    {
        for(int i = 0; i < allStage.Count; i++)
        {
            if (allStage[i].GetComponent<StagePrefab>().StageisSelected)
            { stageIndex = i; }
        }
    }

    void SetImage() //에너미 필드의 이미지를 바꿔줌
    {
        for(int i=0;i< allStage[stageIndex].GetComponent<StagePrefab>().StageEnemysArrangedIndex.Length;i++)
        {
            EnemyFields[allStage[stageIndex].GetComponent<StagePrefab>().StageEnemysArrangedIndex[i]].color = new Color(255f, 255f, 255f, 1f);
            EnemyFields[allStage[stageIndex].GetComponent<StagePrefab>().StageEnemysArrangedIndex[i]].sprite = allEnemy[allStage[stageIndex].GetComponent<StagePrefab>().StageEnemysIndex[i]].GetComponent<EnemysPrefab>().mySprite;
        }
    }

}
