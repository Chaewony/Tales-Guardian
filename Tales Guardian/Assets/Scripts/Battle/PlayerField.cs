using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerField : MonoBehaviour
{
	public BattleManager battleManager;
	public PlayerMove[] playerMove;

	SpriteRenderer fieldColor;
	Color defaultColor;

	public List<int> mySecondTarget = new List<int>();
	public List<PlayerField> selectedSecondTarget = new List<PlayerField>();

	//상하좌우 반대로(에너미가 보는 방향)
	public PlayerField leftUpField;     // 1
	public PlayerField upField;         // 2
	public PlayerField rightUpField;    // 3
	public PlayerField leftField;       // 4
	public PlayerField rightField;      // 5
	public PlayerField leftDownField;   // 6
	public PlayerField downField;       // 7
	public PlayerField rightDownField;  // 8

	public EnemyAttack enemyAttack;

	void Start()
	{
		fieldColor = GetComponent<SpriteRenderer>();
		defaultColor = fieldColor.color;
	}

	private void OnMouseDown() //플레이어필드가 클릭됐을 때
	{
		if (battleManager.canMove) //움직일 수 있는 상태면
		{
			for (int i = 0; i < playerMove.Length; i++) {
				if(playerMove[i].clicked)
					playerMove[i].move(this.transform.position); //이동 나중에 보여주게 하려면 바로 함수 불러오는게 아니라 플레이어무브 스크립트의 변수에 저장해좋고 나중에 이동 함수 실행시켜주면 될 듯
					//클릭된 필드의 좌표 정보를 클릭된 캐릭터의 move함수로 넘겨준다
				//Debug.Log(this.gameObject);
			}
		}
	}

	public void SetSecondTarget(int[] secondTarget)
	{
		mySecondTarget = new List<int>();
		for (int i = 0; i < secondTarget.Length; i++)
		{
			mySecondTarget.Add(secondTarget[i]);
		}
		//Debug.Log(secondTarget.Length);
		ColorTargets();
	}

	private void ColorTargets()
	{
		fieldColor.color = new Color(1, 0.5f, 0.5f);

		for (int i = 0; i < mySecondTarget.Count; i++)
		{
			switch (mySecondTarget[i])
			{
				case 1:
					if (leftUpField != null)
					{
						leftUpField.Color();
						selectedSecondTarget.Add(leftUpField);
					}
					break;

				case 2:
					if (upField != null)
					{
						upField.Color();
						selectedSecondTarget.Add(upField);
					}
					break;

				case 3:
					if (rightUpField != null)
					{
						rightUpField.Color();
						selectedSecondTarget.Add(rightUpField);
					}
					break;

				case 4:
					if (leftField != null)
					{
						leftField.Color();
						selectedSecondTarget.Add(leftField);
					}
					break;

				case 5:
					if (rightField != null)
					{
						rightField.Color();
						selectedSecondTarget.Add(rightField);
					}
					break;

				case 6:
					if (leftDownField != null)
					{
						leftDownField.Color();
						selectedSecondTarget.Add(leftDownField);
					}
					break;

				case 7:
					if (downField != null)
					{
						downField.Color();
						selectedSecondTarget.Add(downField);
					}
					break;

				case 8:
					if (rightDownField != null)
					{
						rightDownField.Color();
						selectedSecondTarget.Add(rightDownField);
					}
					break;
			}
		}
	}

	private void Color()
	{
		fieldColor.color = new Color(1, 0.75f, 0.5f);
	}
	public void PlayerFieldInitiate()
	{
		for (int i = 0; i < enemyAttack.playerFields.Length; i++)
		{
			enemyAttack.playerFields[i].fieldColor.color = enemyAttack.playerFields[i].defaultColor;
		}
		selectedSecondTarget = new List<PlayerField>();
		battleManager.battleState = BattleState.PLAYER_ATTACK_TURN;
	}
}
