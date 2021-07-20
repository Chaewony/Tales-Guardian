using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerField : MonoBehaviour
{
	public BattleManager battleManager;
	public PlayerMove[] playerMove;
	private void OnMouseDown()
	{
		if (battleManager.canMove)
		{
			for (int i = 0; i < playerMove.Length; i++) {
				if(playerMove[i].clicked)
					playerMove[i].move(this.transform.position); //이동 나중에 보여주게 하려면 바로 함수 불러오는게 아니라 플레이어무브 스크립트의 변수에 저장해좋고 나중에 이동 함수 실행시켜주면 될 듯
				//Debug.Log(this.gameObject);
			}
		}
	}
}
