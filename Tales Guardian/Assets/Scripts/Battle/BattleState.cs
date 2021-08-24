using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleState
{
	SELECT_TURN, //공수 결정 카드 뽑기... 인데 적절한 말을 못찾음
	
	PLAYER_ATTACK_TURN, //플레이어 공격선택
	ENEMY_MOVE, //에너미 이동
	PLAYER_ATTACK, //플레이어 공격실행

	PLAYER_MOVE_CHOOSE_END, //턴이 끝나면
	PLAYER_MOVE, //플레이어 이동턴(에너미 공격 턴)
	BATTLE_END //게임 종료
}
