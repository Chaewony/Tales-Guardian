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

    public Button[] skill1Button;
    public Button[] skill2Button;

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
            if (battleManager.playerSquad[i].myCurrentHp <= 0)
            {
                skill1Button[i].interactable = false;
                skill1[i].text = "";
            }
            else skill1[i].text = battleManager.playerSquad[i].myFirstSkillName;
        }
        //스킬2
        for (int i = 0; i < battleManager.playerSquad.Count; i++)
        {
            if (battleManager.playerSquad[i].myCurrentHp <= 0)
            {
                skill2Button[i].interactable = false;
                skill2[i].text = "";
            }
            else skill2[i].text = battleManager.playerSquad[i].mySecondSkillName;
        }

        /*//스킬1
        for (int i = 0; i < battleManager.playerSquad.Count; i++)
        {
            if (battleManager.playerSquad[i].myCurrentHp <= 0)
                skill1Button[i].interactable = false;
        }
        //스킬2
        for (int i = 0; i < battleManager.playerSquad.Count; i++)
        {
            if (battleManager.playerSquad[i].myCurrentHp <= 0)
                skill2Button[i].interactable = false;
        }*/
    }
}
