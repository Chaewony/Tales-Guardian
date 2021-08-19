using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    public List<FieldInfo> allField = new List<FieldInfo>();

    public List<CharacterInfo> allCharacter = new List<CharacterInfo>();
    public List<EnemyInfo> allEnemy = new List<EnemyInfo>();
    
    public List<CharacterInfo> playerSquad = new List<CharacterInfo>();//플레이어 스쿼드 리스트
    public List<EnemyInfo> enemySquad = new List<EnemyInfo>();//에너미 스쿼드 리스트

    public List<StageInfo> allStage = new List<StageInfo>();
    public int stageIndex;

    public Transform[] playerFields;
    public Transform[] enemyFields;

    public SpriteRenderer[] playerSquadCharacters;
    public SpriteRenderer[] enemySquadCharacters;

    public bool canAttack; //어택 턴을 나타내는 것이 아니라, 스킬 클릭됐다는걸 체크
    public bool canMove; //이동 턴을 나타내는 것이 아니라, 이동할 캐릭터가 클릭됐다는걸 체크
    public bool canClick; //이동 턴을 나타내는 것이 아니라, 이동할 캐릭터를 클릭할 수 있다는걸 체크

    public BattleState battleState;

    public int[] dice;
    public int remainMoveTime;
    public GameObject DiceButton;
    public bool isThrown;
    public Text remainMoveTimeText;

    // Start is called before the first frame update
    void Start()
    {
        CheckStage();
        SetPlayerSquad();
        SetEnemySquad();
        IntitiateHp();
        SetPlayerSquadCharacters();
        SetEnemySquadCharacters();

        canAttack = false;
        canMove = false;
        canClick = true;

        isThrown = false;

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
            //canAttack = false;
            if (!isThrown) DiceButton.SetActive(true);
            remainMoveTimeText.text = "남은 이동 횟수: " + remainMoveTime;
            Debug.Log("플레이어 이동선택 및 이동");
        }

        if(battleState==BattleState.PLAYER_ATTACK_TURN)
		{
            //플레이어의 공격 턴이 오면 실행
            //공격 "선택" + 에너미 이동 + 공격 "실행"
            //하나의 스크립트가 아니라 필드 각각의 스크립트가 있어 한 함수만 불러와주기 까다로움
            //EnemyField 스크립트 참고
            Debug.Log("플레이어 공격턴, 플레이어 공격선택 + 에너미 이동 + 플레이어 공격실행 ");
		}

        if (battleState == BattleState.PLAYER_MOVE_CHOOSE_END)
        {
            //플레이어의 이동은 바로 화면에 출력되니 신경쓰지 말고 에너미 공격을 하면 됨
            isThrown = false; //주사위
            remainMoveTimeText.text = " ";
            Debug.Log("이동 선택 턴 종료");
        }

        if (battleState==BattleState.BATTLE_END)
		{
            //두 squad중 하나의 모든 오브젝트의 hp가 0이 될 경우
		}
	}
    void CheckStage()
    {
        for (int i = 0; i < allStage.Count; i++)
        {
            if (allStage[i].isSelected)
            { stageIndex = i; }
        }
    }

    void SetPlayerSquad()
	{
        //Set Info
        int j = 0; 
        for (int i = 0; i < allField.Count; i++)
            if (allField[i].myArrangedCharIndex != -1) //배치가 된 필드일 경우
            {
                playerSquad[j] = allCharacter[allField[i].myArrangedCharIndex]; 
                j++;
            }
    }

    void SetEnemySquad()
	{
        //Set Info
        int j = 0;
        for (int i = 0; i < allStage[stageIndex].EnemyIndex.Length; i++)
        {
            enemySquad[j] = allEnemy[allStage[stageIndex].EnemyIndex[i]];
            j++;
        }
    }

    void IntitiateHp()//current hp 초기화
	{
        for(int i = 0; i < playerSquad.Count; i++)
		{
            playerSquad[i].myCurrentHp = playerSquad[i].myHp;
		}
        for (int i = 0; i < allStage[stageIndex].EnemyIndex.Length; i++)
        {
            enemySquad[i].myCurrentHp = enemySquad[i].myHp;
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
    void SetEnemySquadCharacters()
    {
        //이미지 렌더링
        for (int i = 0; i < allStage[stageIndex].EnemyIndex.Length; i++)
        {
            enemySquadCharacters[i].sprite = enemySquad[i].mybattleSprite;
        }
        //위치정비
        int j = 0;
        for (int i = 0; i < allStage[stageIndex].EnemyIndex.Length; i++)
		{
            enemySquadCharacters[i].transform.position = new Vector3(enemyFields[allStage[stageIndex].EnemyArrangedIndex[i]].position.x, enemySquadCharacters[j].transform.position.y, enemyFields[allStage[stageIndex].EnemyArrangedIndex[i]].position.z);
        }
    }
}
