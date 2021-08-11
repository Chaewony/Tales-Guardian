using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySquadUI : MonoBehaviour
{
    [SerializeField]
    private BattleManager battleManager;
    [SerializeField]
    private Image[] charImageUI;

    public Text[] hpValue;
    public Image[] hpBar;

    [SerializeField]
    private Text[] skill1;
    [SerializeField]
    private Text[] skill2;

    // Update is called once per frame
    void Update()
    {
        ShowCharImageUI();
        ShowHpBar();
        ShowSkill();
    }

    void ShowCharImageUI()
    {
        for (int i = 0; i < battleManager.allStage[battleManager.stageIndex].EnemyIndex.Length; i++)
            charImageUI[i].sprite = battleManager.enemySquad[i].mySprite;
    }
    void ShowHpBar()
    {
        for (int i = 0; i < battleManager.allStage[battleManager.stageIndex].EnemyIndex.Length; i++)
        {
            hpValue[i].text = battleManager.enemySquad[i].myCurrentHp + "/" + battleManager.enemySquad[i].myHp;
            hpBar[i].fillAmount = battleManager.enemySquad[i].myCurrentHp / battleManager.enemySquad[i].myHp;
            if (battleManager.enemySquad[i].myCurrentHp < 0)
            {
                battleManager.enemySquad[i].myCurrentHp = 0;
            }
        }
    }
    void ShowSkill()
    {
        //스킬1
        for (int i = 0; i < battleManager.allStage[battleManager.stageIndex].EnemyIndex.Length; i++)
        {
            skill1[i].text = battleManager.enemySquad[i].myFirstSkillName;
        }
        //스킬2
        for (int i = 0; i < battleManager.allStage[battleManager.stageIndex].EnemyIndex.Length; i++)
        {
            skill2[i].text = battleManager.enemySquad[i].mySecondSkillName;
        }
    }
}
