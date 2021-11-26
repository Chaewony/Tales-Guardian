using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
	public BattleManager battleManager;
	public PlayerField[] playerFields;

	int myFieldRand;
	bool isChoosingEnd;

	public void EnemyAttackChoose()
	{
		if (!isChoosingEnd)
		{
			isChoosingEnd = true;
			myFieldRand = GetAttckFieldIndex();
			int charRand = Random.Range(0, battleManager.stagePrefabs[battleManager.stageIndex].StageEnemysIndex.Length); //캐릭터 랜덤
			int type = Random.Range(0, 2); //스킬 랜덤
			if (type == 0) playerFields[myFieldRand].SetSecondTarget(battleManager.enemySquad[charRand].myFirstSkillSecondTargetRange);
			else if (type == 1) playerFields[myFieldRand].SetSecondTarget(battleManager.enemySquad[charRand].mySecondSkillSecondTargetRange);
			//playerFieldsColor[myFieldRand].color = new Color(1, 0.5f, 0.5f);
			Invoke("Attack", 1f);
		}
		//Invoke("Attack", 1f);
	}

	public void Attack()
	{
		//공격
		for (int i = 0; i < battleManager.playerSquad.Count; i++)
		{
			if (battleManager.playerSquadCharacters[i].transform.position.x == playerFields[myFieldRand].transform.position.x &&
				battleManager.playerSquadCharacters[i].transform.position.z == playerFields[myFieldRand].transform.position.z)
			{
				battleManager.playerSquad[i].myCurrentHp -= 100;
			}
		}
		//세컨드 타겟 hp 안깎이고 어딘가에서 널 레퍼런스 오류 뜸
		for (int i = 0; i < playerFields[myFieldRand].selectedSecondTarget.Count; i++) //플레이어 스쿼드 수만큼 돌아야하는거 아닌가?
		{
			for (int j = 0; j < battleManager.playerSquad.Count; j++)
			{
				if (battleManager.playerSquadCharacters[j].transform.position.x == playerFields[myFieldRand].selectedSecondTarget[i].transform.position.x &&
				battleManager.playerSquadCharacters[j].transform.position.z == playerFields[myFieldRand].selectedSecondTarget[i].transform.position.z)
				{
					battleManager.playerSquad[j].myCurrentHp -= 50;
				}
			}
		}

		playerHpCheck();
		isChoosingEnd = false;
		playerFields[myFieldRand].PlayerFieldInitiate();
		//battleManager.battleState = BattleState.PLAYER_ATTACK;
	}
	int GetAttckFieldIndex() //공격할 필드의 인덱스 값을 랜덤으로 정함
	{
		int fieldRand = Random.Range(0, playerFields.Length);
		return fieldRand;
	}

	private void playerHpCheck()
	{
		for (int i = 0; i < battleManager.playerSquad.Count; i++)
		{
			if (battleManager.playerSquad[i].myCurrentHp <= 0)
			{
				battleManager.playerDie(i);
			}
		}
	}
}
