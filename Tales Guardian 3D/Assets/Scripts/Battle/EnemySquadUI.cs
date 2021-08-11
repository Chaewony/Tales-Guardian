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

    // Update is called once per frame
    void Update()
    {
        ShowCharImageUI();
        ShowHpBar();
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
}
