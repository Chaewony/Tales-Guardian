using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
	public BattleManager battleManager;
	public EnemyField[] enemyFields;
    public void Move()
	{
		//int rand= Random.Range(0, battleManager.enemySquadCharacters.Length);
		int rand = Random.Range(0, battleManager.enemySquad.Count);
		int myFieldRand= GetFieldRandom();

		//이동
		battleManager.enemySquadCharacters[rand].transform.position = 
			new Vector3(enemyFields[myFieldRand].transform.position.x,
			battleManager.enemySquadCharacters[rand].transform.position.y,
			enemyFields[myFieldRand].transform.position.z);

	}
	int GetFieldRandom()
	{
		int fieldRand = Random.Range(0, enemyFields.Length);
		if (!CheckEmptyField(fieldRand)) GetFieldRandom();
		return fieldRand;
	}

	bool CheckEmptyField(int fieldRand)
	{
		for (int i = 0; i < battleManager.enemySquad.Count; i++)
		{
			if (battleManager.enemySquadCharacters[i].transform.position.x == enemyFields[fieldRand].transform.position.x &&
				battleManager.enemySquadCharacters[i].transform.position.z == enemyFields[fieldRand].transform.position.z)
			{
				return false;
			}
		}
		return true;
	}

	
}
