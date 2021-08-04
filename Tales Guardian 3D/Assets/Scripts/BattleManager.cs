using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public List<FieldInfo> allField = new List<FieldInfo>();
    public List<CharacterInfo> allCharacter = new List<CharacterInfo>();
    public List<CharacterInfo> playerSquad = new List<CharacterInfo>();//플레이어 스쿼드 리스트

    public Transform[] playerFields;

    public SpriteRenderer[] playerSquadCharacters;

    public bool canAttack; //어택 턴을 나타내는 것이 아니라, 스킬 클릭됐다는걸 체크
    public bool canMove; //이동 턴을 나타내는 것이 아니라, 이동할 캐릭터가 클릭됐다는걸 체크
    public bool canClick; //이동 턴을 나타내는 것이 아니라, 이동할 캐릭터를 클릭할 수 있다는걸 체크

    public BattleState battleState;

    public int[] dice;

    // Start is called before the first frame update
    void Start()
    {
        SetPlayerSquad();
        IntitiateHp();
        SetPlayerSquadCharacters();

        canAttack = false;
        canMove = false;
        canClick = true;

        battleState = BattleState.SELECT_TURN;
    }

	private void Update()
	{
		if(battleState== BattleState.SELECT_TURN)
		{
            //공수 선택시 띄워줄 UI 띄우는 함수 불러오기
            //그리고 버튼 결과에 따라 그 함수에서 스테이트 바꿔줄 것
		}

        if(battleState==BattleState.PLAYER_MOVE)
		{
            //플레이어의 이동 턴이 오면 실행(즉 에너미의 공격 선택을 호출)
            //이동 "선택"
            Debug.Log("플레이어 이동턴");
        }

        if(battleState==BattleState.PLAYER_ATTACK)
		{
            //플레이어의 공격 턴이 오면 실행
            //공격 "선택"
            Debug.Log("플레이어 공격턴");
		}

        if(battleState==BattleState.PLAYER_ATTACK_CHOOSE_END)
		{
            //에너미의 이동을 실행
            //초기화시켜줄것 시키기
            canAttack = false;
            Debug.Log("어택 선택 턴 종료");
            Debug.Log("에너미가 이동했습니다.");
            Debug.Log("플레이어의 공격이 실행됩니다");
            //플레이어 공격 실행 함수 불러와주기
            //에너미 필드 색상과 리스트 초기화
            battleState = BattleState.PLAYER_MOVE;

        }

        if (battleState == BattleState.PLAYER_MOVE_CHOOSE_END)
        {
            //플레이어의 이동은 바로 화면에 출력되니 신경쓰지 말고 에너미 공격을 하면 됨
            Debug.Log("이동 선택 턴 종료");
        }

        if (battleState==BattleState.BATTLE_END)
		{
            //두 squad중 하나의 모든 오브젝트의 hp가 0이 될 경우
		}
	}

	void SetPlayerSquad()
	{
        //Set Info
        int j = 0;
        for (int i = 0; i < allField.Count; i++)
            if (allField[i].myArrangedCharIndex != -1)
            {
                playerSquad[j] = allCharacter[allField[i].myArrangedCharIndex];
                j++;
            }

        //Set Skill Slot
    }
    void IntitiateHp()//current hp 초기화
	{
        for(int i = 0; i < playerSquad.Count; i++)
		{
            playerSquad[i].myCurrentHp = playerSquad[i].myHp;
		}
	}
    void SetPlayerSquadCharacters()
	{
        //이미지 렌더링
        for(int i = 0; i < playerSquad.Count; i++)
		{
            playerSquadCharacters[i].sprite = playerSquad[i].mybattleSprite;
        }
        //위치정비
        int j = 0;
        for (int i = 0; i < allField.Count; i++)
            if (allField[i].myArrangedCharIndex != -1)
            {
                playerSquadCharacters[j].transform.position = new Vector3(playerFields[i].position.x, playerSquadCharacters[j].transform.position.y, playerFields[i].position.z);
                //playerSquadCharacters[j].transform.position = playerFields[i].position;
                j++;
            }

    }
}
