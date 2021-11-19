using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
	public BattleManager battleManager;
	public bool clickedDice;

	private void Start()
	{
		clickedDice = false;
	}
	public void OnButtonClick()
	{
		battleManager.remainMoveTime = battleManager.dice[Random.Range(0, 6)];
		battleManager.isThrown = true;
		clickedDice = true;
		this.gameObject.SetActive(false);
	}
}
