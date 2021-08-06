using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
	public BattleManager battleManager;

	SpriteRenderer characterColor;
	Color defaultColor;

	public bool clicked;

	public Transform[] otherCharacters;

	void Start()
	{
		characterColor = GetComponent<SpriteRenderer>();
		defaultColor = characterColor.color;
		clicked = false;
	}

	private void OnMouseDown() //캐릭터가 클릭되면
	{
		if (battleManager.battleState == BattleState.PLAYER_MOVE&& battleManager.canClick) //배틀스테이트가 Player_Move일때만 실행 되도록
		{
			clicked = true; //클릭됐는지 안됐는지 판별
			battleManager.canMove = true; //움직일 수 있는 상태인지 아닌지 판별
			battleManager.canAttack = false; //공격턴에 움직이면 안되니까
			characterColor.color = new Color(0.25f, 0.5f, 1f); //캐릭터가 클릭됐을 때 파랑색으로 색 바꾸기
			battleManager.canClick = false;
		}
	}

	public void move(Vector3 fieldPosition)
	{
		if (clicked && battleManager.battleState == BattleState.PLAYER_MOVE &&
			ComparePosition(fieldPosition) && //다른캐릭터가 없으면 이동 가능
			(Vector3.Distance(fieldPosition, this.transform.position) < 351) && //대각선 이동 방지
			(Mathf.Abs(fieldPosition.x - this.transform.position.x) < 351 && //좌우 두 칸 이동 방지
			(Mathf.Abs(fieldPosition.z - this.transform.position.z) < 171))) //상하 두 칸 이동 방지
		{
			this.transform.position = new Vector3(fieldPosition.x, this.transform.position.y, fieldPosition.z); //캐릭터 이동
			
			if (battleManager.remainMoveTime > 1) battleManager.remainMoveTime--;
			else
			{
				battleManager.remainMoveTime = 0;
				characterColor.color = defaultColor; //원래 색깔로 되돌리기
				clicked = false;
				battleManager.canMove = false;
				battleManager.canClick = true;
				battleManager.battleState = BattleState.PLAYER_MOVE_CHOOSE_END;
			}
		}
	}

	public bool ComparePosition(Vector3 fieldPosition) //다른캐릭터가 움직이려는 필드에 있는지 확인
	{
		for(int i=0;i< otherCharacters.Length;i++)
		{
			if (otherCharacters[i].position.x == fieldPosition.x && otherCharacters[i].position.z == fieldPosition.z)
				return false; //있으면 false
		}

		return true; //없으면 true
	}
}
