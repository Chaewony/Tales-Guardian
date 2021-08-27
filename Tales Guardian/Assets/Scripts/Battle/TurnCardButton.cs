using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnCardButton : MonoBehaviour
{
    public TurnCard turnCard;
	public TurnCardIndex turnCardIndex;

	Image image;

	// Start is called before the first frame update
	private void Start()
	{
		image = GetComponent<Image>();
	}

	public void OnButtonClick()
	{
		if(!turnCard.isSelected)
		{
			switch (turnCardIndex)
			{
				case TurnCardIndex.TurnCardIndex0:
					turnCard.myTurnCardIndex = 0;
					break;
				case TurnCardIndex.TurnCardIndex1:
					turnCard.myTurnCardIndex = 1;
					break;
				case TurnCardIndex.TurnCardIndex2:
					turnCard.myTurnCardIndex = 2;
					break;
				case TurnCardIndex.TurnCardIndex3:
					turnCard.myTurnCardIndex = 3;
					break;
			}
		}
		
		if (!turnCard.isSelected)
		{
			turnCard.ChooseEnemyTurnCard();
			turnCard.ShowTurnCards();
			turnCard.PaintEnemyTurnCard();
			this.image.color = new Color(1, 1, 1, 0.5f);
			Invoke("CallSetTurn", 5f);

			turnCard.isSelected = true;
		}
	}

	void CallSetTurn()
	{
		turnCard.SetTurn();
	}
}