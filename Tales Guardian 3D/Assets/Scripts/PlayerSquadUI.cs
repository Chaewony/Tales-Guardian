using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSquadUI : MonoBehaviour
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
        for (int i = 0; i < battleManager.playerSquad.Count; i++)
            charImageUI[i].sprite = battleManager.playerSquad[i].mySprite;
    }
    void ShowHpBar()
	{
        for (int i = 0; i < battleManager.playerSquad.Count; i++)
        {
            hpValue[i].text = battleManager.playerSquad[i].myCurrentHp + "/" + battleManager.playerSquad[i].myHp;
            hpBar[i].fillAmount = battleManager.playerSquad[i].myCurrentHp / battleManager.playerSquad[i].myHp;
            if (battleManager.playerSquad[i].myCurrentHp < 0)
            {
                battleManager.playerSquad[i].myCurrentHp = 0;
            }
        }
    }
    void ShowSkill()
	{
        //스킬1
        for (int i = 0; i < battleManager.playerSquad.Count; i++)
        {
            skill1[i].text = battleManager.playerSquad[i].myFirstSkillName;
        }
        //스킬2
        for (int i = 0; i < battleManager.playerSquad.Count; i++)
        {
            skill2[i].text = battleManager.playerSquad[i].mySecondSkillName;
        }
    }
}
