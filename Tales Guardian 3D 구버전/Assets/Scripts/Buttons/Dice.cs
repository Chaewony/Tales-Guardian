using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
	public BattleManager battleManager;

	public void OnButtonClick()
	{
		battleManager.remainMoveTime = battleManager.dice[Random.Range(0, 6)];
		battleManager.isThrown = true;
		this.gameObject.SetActive(false);
	}
}
