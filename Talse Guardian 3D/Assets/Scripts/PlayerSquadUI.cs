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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShowCharImageUI();
        ShowHpBar();
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
}
