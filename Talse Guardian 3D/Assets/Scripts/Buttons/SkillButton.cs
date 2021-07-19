using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillButton : MonoBehaviour
{
	public BattleManager battleManager;
	public void OnButtonClick()
	{
		Debug.Log("클릭");
		battleManager.canAttack = true;
	}
}
