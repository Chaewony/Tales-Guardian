using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnCard : MonoBehaviour
{
    [SerializeField]
    private List<TurnCardInfo> allTurnCard = new List<TurnCardInfo>();
    private List<TurnCardInfo> TurnCardRandomList = new List<TurnCardInfo>();

    [SerializeField]
    private Image[] TurnCardImages;

    public int myTurnCardIndex;
    public int enemyTurnCardIndex;

    public BattleManager battleManager;

    public bool isSelected;

    // Start is called before the first frame update
    void Start()
    {
        AllocateCards();
        isSelected = false;
    }

    void AllocateCards() // 카드들을 슬롯에 할당
	{
        for (int i = 0; i < allTurnCard.Count;)
        {
            int rand = Random.Range(0, allTurnCard.Count);
            if (!TurnCardRandomList.Contains(allTurnCard[rand]) || TurnCardRandomList.Count == 0)
            {
                TurnCardRandomList.Add(allTurnCard[rand]);
                i++;
            }
        }
    }

    public void ShowTurnCards()
	{
        for (int i = 0; i < TurnCardRandomList.Count; i++)
        {
            TurnCardImages[i].sprite = TurnCardRandomList[i].mySprite;
        }
    }

    public void ChooseEnemyTurnCard()
	{
        int rand = Random.Range(0, TurnCardRandomList.Count);
        if (rand != myTurnCardIndex)
        {
            enemyTurnCardIndex = rand;
        }
        else ChooseEnemyTurnCard();
    }

    public void PaintEnemyTurnCard()
	{
        TurnCardImages[enemyTurnCardIndex].color = new Color(1, 0.5f, 0.5f);
    }

    public void SetTurn()
    {
        if(TurnCardRandomList[enemyTurnCardIndex].myCardNum< TurnCardRandomList[myTurnCardIndex].myCardNum)
		{
            battleManager.battleState = BattleState.PLAYER_ATTACK_TURN;
        }
        if (TurnCardRandomList[enemyTurnCardIndex].myCardNum > TurnCardRandomList[myTurnCardIndex].myCardNum)
        {
            battleManager.battleState = BattleState.PLAYER_MOVE;
        }

        this.gameObject.SetActive(false);
    }
}
