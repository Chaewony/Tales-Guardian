using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyArrangement : MonoBehaviour
{
    // 에너미 인포들
    public List<EnemyInfo> allEnemy = new List<EnemyInfo>(); //스크립터블 오브젝트
    // 에너미 필드
    public Image[] EnemyFields;
    // 스테이지 인포
    public List<StageInfo> allStage = new List<StageInfo>(); //스크립터블 오브젝트

    int stageIndex;

    // Start is called before the first frame update
    void Start()
    {
        CheckStage();
        SetImage();
    }

    void CheckStage()
    {
        for(int i = 0; i < allStage.Count; i++)
        {
            if (allStage[i].isSelected)
            { stageIndex = i; }
        }
    }
    void SetImage() //에너미 필드의 이미지를 바꿔줌
    {
        for(int i=0;i< allStage[stageIndex].EnemyIndex.Length;i++)
        {
            EnemyFields[allStage[stageIndex].EnemyArrangedIndex[i]].color = new Color(1, 1, 1);
            EnemyFields[allStage[stageIndex].EnemyArrangedIndex[i]].sprite = allEnemy[allStage[stageIndex].EnemyIndex[i]].mySprite;
        }
    }

}
