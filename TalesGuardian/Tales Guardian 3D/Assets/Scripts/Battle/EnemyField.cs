using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyField : MonoBehaviour
{
	SpriteRenderer fieldColor;

	public EnemyField leftUpField;     // 1
	public EnemyField upField;         // 2
	public EnemyField rightUpField;    // 3
	public EnemyField leftField;       // 4
	public EnemyField rightField;      // 5
	public EnemyField leftDownField;   // 6
	public EnemyField downField;       // 7
	public EnemyField rightDownField;  // 8

	Color defaultColor;

	public BattleManager battleManager;

	List<int> mySecondTarget = new List<int>();

	public List<EnemyField> selectedSecondTarget = new List<EnemyField>();
	bool isClicked;

	public EnemyMove enemyMove;

	// Start is called before the first frame update
	void Start()
    {
		fieldColor = GetComponent<SpriteRenderer>();

		defaultColor = fieldColor.color;

		isClicked = false;
	}

	private void Update()
	{
		if(selectedSecondTarget!=null && isClicked)
		{
			fieldColor.color = new Color(1, 0.5f, 0.5f);
			for (int i = 0; i < selectedSecondTarget.Count; i++)
			{
				selectedSecondTarget[i].fieldColor.color = new Color(1, 0.75f, 0.5f);
			}
		}
	}

	public void SetSecondTarget(int[] secondTarget)
	{
		mySecondTarget = new List<int>();
		//int[] mySecondTarget = new int[secondTarget.Length];
		for(int i = 0; i < secondTarget.Length; i++)
		{
			//mySecondTarget[i] = secondTarget[i];
			mySecondTarget.Add(secondTarget[i]);
			//mySecondTarget[i] = secondTarget[i];
		}
	}

	private void SecondTargetEnter()
	{
		fieldColor.color = new Color(1, 0.75f, 0.5f);
	}
	private void SecondTargetExit()
	{
		fieldColor.color = defaultColor;
	}

	private void OnMouseEnter()
	{
		if (battleManager.canAttack && mySecondTarget != null)
		{
			fieldColor.color = new Color(1, 0.5f, 0.5f);

			for (int i = 0; i < mySecondTarget.Count; i++)
			{
				switch (mySecondTarget[i])
				{
					case 1:
						if (leftUpField != null)
							leftUpField.SecondTargetEnter();
						break;

					case 2:
						if (upField != null)
							upField.SecondTargetEnter();
						break;

					case 3:
						if (rightUpField != null)
							rightUpField.SecondTargetEnter();
						break;

					case 4:
						if (leftField != null)
							leftField.SecondTargetEnter();
						break;

					case 5:
						if (rightField != null)
							rightField.SecondTargetEnter();
						break;

					case 6:
						if (leftDownField != null)
							leftDownField.SecondTargetEnter();
						break;

					case 7:
						if (downField != null)
							downField.SecondTargetEnter();
						break;

					case 8:
						if (rightDownField != null)
							rightDownField.SecondTargetEnter();
						break;
				}
			}
		}
	}
	private void OnMouseExit()
	{
		fieldColor.color = defaultColor;

		if (battleManager.canAttack && mySecondTarget != null)
		{
			for (int i = 0; i < mySecondTarget.Count; i++)
			{
				switch (mySecondTarget[i])
				{
					case 1:
						if (leftUpField != null)
							leftUpField.SecondTargetExit();
						break;

					case 2:
						if (upField != null)
							upField.SecondTargetExit();
						break;

					case 3:
						if (rightUpField != null)
							rightUpField.SecondTargetExit();
						break;

					case 4:
						if (leftField != null)
							leftField.SecondTargetExit();
						break;

					case 5:
						if (rightField != null)
							rightField.SecondTargetExit();
						break;

					case 6:
						if (leftDownField != null)
							leftDownField.SecondTargetExit();
						break;

					case 7:
						if (downField != null)
							downField.SecondTargetExit();
						break;

					case 8:
						if (rightDownField != null)
							rightDownField.SecondTargetExit();
						break;
				}
			}
		}
	}

	private void OnMouseDown()
	{
		if (battleManager.canAttack)
		{
			isClicked = true; //버튼 하나하나마다 설정되어있어서 다른 버튼 누르면 못걸러짐

			for (int i = 0; i < mySecondTarget.Count; i++)
			{
				switch (mySecondTarget[i])
				{
					case 1:
						if (leftUpField != null)
							selectedSecondTarget.Add(leftUpField);
						break;

					case 2:
						if (upField != null)
							selectedSecondTarget.Add(upField);
						break;

					case 3:
						if (rightUpField != null)
							selectedSecondTarget.Add(rightUpField);
						break;

					case 4:
						if (leftField != null)
							selectedSecondTarget.Add(leftField);
						break;

					case 5:
						if (rightField != null)
							selectedSecondTarget.Add(rightField);
						break;

					case 6:
						if (leftDownField != null)
							selectedSecondTarget.Add(leftDownField);
						break;

					case 7:
						if (downField != null)
							selectedSecondTarget.Add(downField);
						break;

					case 8:
						if (rightDownField != null)
							selectedSecondTarget.Add(rightDownField);
						break;
				}
			}
			//선택 이후
			battleManager.canAttack = false;
			Invoke("Delay", 1f);
			Invoke("Attack", 2f);
			Invoke("Initiate", 3f);
			//enemyMove.Move();
			//Attack();
			//Initiate();
			//battleManager.battleState = BattleState.PLAYER_MOVE;
		}
	}

	private void Attack()
	{
		//첫번째 타겟에 공격
		for (int i = 0; i < battleManager.enemySquad.Count; i++)
		{
			if (battleManager.enemySquadCharacters[i].transform.position.x == this.transform.position.x &&
				battleManager.enemySquadCharacters[i].transform.position.z == this.transform.position.z)
			{
				battleManager.enemySquad[i].myCurrentHp -= 10;//수치 바꿀 것
			}
		}
		//두번째 타겟에 공격, i랑 j랑 잘 볼 것
		for(int i=0;i< selectedSecondTarget.Count; i++)
		{
			for (int j = 0; j < battleManager.enemySquad.Count; j++)
			{
				if (battleManager.enemySquadCharacters[j].transform.position.x == selectedSecondTarget[i].transform.position.x&& battleManager.enemySquadCharacters[j].transform.position.z == selectedSecondTarget[i].transform.position.z)
				{
					battleManager.enemySquad[j].myCurrentHp -= 5;//수치 바꿀 것
				}
			}
		}
	}

	private void Initiate()
	{
		//selectedSecondTarget = null;
		selectedSecondTarget = new List<EnemyField>(); //리스트 초기화
		for(int i=0;i<enemyMove.enemyFields.Length;i++)
		{
			enemyMove.enemyFields[i].fieldColor.color = enemyMove.enemyFields[i].defaultColor;
		}
		isClicked = false;
		battleManager.battleState = BattleState.PLAYER_MOVE;
	}

	private void Delay()
	{
		enemyMove.Move();
	}
}
