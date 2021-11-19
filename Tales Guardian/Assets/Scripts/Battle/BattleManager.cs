using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class BattleManager : MonoBehaviour
{
    //public List<FieldInfo> allField = new List<FieldInfo>();

    public List<GameObject> FieldDDObject; //수정 된거
    public List<FieldPrefab> fieldPrefabs; //수정 된거



    public List<GameObject> CharacterDDObject; //수정 된거
    public List<CharactersPrefab> charactersPrefabs; //수정 된거
    public List<CharactersPrefab> playerSquad = new List<CharactersPrefab>();//수정 된거

    public List<GameObject> EnemyDDObject; //수정 된거
    public List<EnemysPrefab> enemysPrefabs; //수정 된거
    public List<EnemysPrefab> enemySquad = new List<EnemysPrefab>();//수정 된거



    //public List<StageInfo> allStage = new List<StageInfo>();
    public List<GameObject> StageDDObject; //수정 된거
    public List<StagePrefab> stagePrefabs; //수정 된거
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
    public Dice diceScript;
    public bool isThrown;
    public Text remainMoveTimeText;

    public EnemyAttack enemyAttack;

    public GameObject Result;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < CharacterDDObject.Count; i++)
        {
            CharacterDDObject[i] = GameObject.Find("DDCharacters").transform.GetChild(i).gameObject;
            charactersPrefabs[i] = CharacterDDObject[i].GetComponent<CharactersPrefab>();
        }

        for (int i = 0; i < EnemyDDObject.Count; i++)
        {
            EnemyDDObject[i] = GameObject.Find("DDEnemy").transform.GetChild(i).gameObject;
            enemysPrefabs[i] = EnemyDDObject[i].GetComponent<EnemysPrefab>();
        }

        for (int i = 0; i < FieldDDObject.Count; i++)
        {
            FieldDDObject[i] = GameObject.Find("DDField").transform.GetChild(i).gameObject;
            fieldPrefabs[i] = FieldDDObject[i].GetComponent<FieldPrefab>();
        }

        for (int i = 0; i < StageDDObject.Count; i++)
        {
            StageDDObject[i] = GameObject.Find("DDStage").transform.GetChild(i).gameObject;
            stagePrefabs[i] = StageDDObject[i].GetComponent<StagePrefab>();
        }

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
        if (battleState == BattleState.SELECT_TURN)
        {
            //공수 선택시 띄워줄 UI 띄우는 함수 불러오기
            //그리고 버튼 결과에 따라 그 함수에서 스테이트 바꿔줄 것
        }

        if (battleState == BattleState.PLAYER_MOVE)
        {
            //플레이어의 이동 턴이 오면 실행(즉 에너미의 공격 선택을 호출)
            //이동 "선택"
            //canAttack = false;

            



            if (!isThrown) DiceButton.SetActive(true);
            remainMoveTimeText.text = "주사위 굴리기";
            if (diceScript.clickedDice)
                remainMoveTimeText.text = "남은 이동 횟수: " + remainMoveTime;
            Debug.Log("플레이어 이동선택 및 이동");
        }

        if (battleState == BattleState.PLAYER_ATTACK_TURN)
        {
            //플레이어의 공격 턴이 오면 실행
            //공격 "선택" + 에너미 이동 + 공격 "실행"
            //하나의 스크립트가 아니라 필드 각각의 스크립트가 있어 한 함수만 불러와주기 까다로움
            //EnemyField 스크립트 참고
            checkEnd();

            remainMoveTimeText.text = "공격 턴입니다";
            Debug.Log("플레이어 공격턴, 플레이어 공격선택 + 에너미 이동 + 플레이어 공격실행 ");
        }

        if (battleState == BattleState.PLAYER_MOVE_CHOOSE_END)
        {
            //플레이어의 이동은 바로 화면에 출력되니 신경쓰지 말고 에너미 공격을 하면 됨
            isThrown = false; //주사위
            diceScript.clickedDice = false;
            remainMoveTimeText.text = " ";
            enemyAttack.EnemyAttackChoose();
        }

        if (battleState == BattleState.BATTLE_END)
        {
            //두 squad중 하나의 모든 오브젝트의 hp가 0이 될 경우
            Debug.Log("끝");
            Invoke("loadResult", 3f);
        }


    }
    void CheckStage()
    {
        for (int i = 0; i < stagePrefabs.Count; i++)
        {
            if (stagePrefabs[i].StageisSelected)
            { stageIndex = i; }
        }
    }

    void SetPlayerSquad()
    {
        //Set Info
        int j = 0;
        for (int i = 0; i < fieldPrefabs.Count; i++)
            if (fieldPrefabs[i].myArrangedCharIndex != -1) //배치가 된 필드일 경우
            {
                playerSquad[j] = charactersPrefabs[fieldPrefabs[i].myArrangedCharIndex];
                j++;
            }
    }

    void SetEnemySquad()
    {
        //Set Info
        int j = 0;
        for (int i = 0; i < stagePrefabs[stageIndex].StageEnemysIndex.Length; i++)
        {
            enemySquad[j] = enemysPrefabs[stagePrefabs[stageIndex].StageEnemysIndex[i]];
            j++;
        }
    }

    void IntitiateHp()//current hp 초기화
    {
        for (int i = 0; i < playerSquad.Count; i++)
        {
            playerSquad[i].myCurrentHp = playerSquad[i].myHp;
        }
        for (int i = 0; i < stagePrefabs[stageIndex].StageEnemysIndex.Length; i++)
        {
            enemySquad[i].myCurrentHp = enemySquad[i].myFullHp;
        }
    }
    void SetPlayerSquadCharacters()
    {
        //이미지 렌더링
        for (int i = 0; i < playerSquad.Count; i++)
        {
            playerSquadCharacters[i].sprite = playerSquad[i].mybattleSprite;
        }
        //위치정비
        int j = 0;
        for (int i = 0; i < fieldPrefabs.Count; i++)
            if (fieldPrefabs[i].myArrangedCharIndex != -1)
            {
                playerSquadCharacters[j].transform.position = new Vector3(playerFields[i].position.x, playerSquadCharacters[j].transform.position.y, playerFields[i].position.z);
                //playerSquadCharacters[j].transform.position = playerFields[i].position;
                j++;
            }

    }
    void SetEnemySquadCharacters()
    {
        //이미지 렌더링
        for (int i = 0; i < stagePrefabs[stageIndex].StageEnemysIndex.Length; i++)
        {
            enemySquadCharacters[i].sprite = enemySquad[i].mybattleSprite;
        }
        //위치정비
        int j = 0;
        for (int i = 0; i < stagePrefabs[stageIndex].StageEnemysIndex.Length; i++)
        {
            enemySquadCharacters[i].transform.position = new Vector3(enemyFields[stagePrefabs[stageIndex].StageEnemysArrangedIndex[i]].position.x, enemySquadCharacters[j].transform.position.y, enemyFields[stagePrefabs[stageIndex].StageEnemysArrangedIndex[i]].position.z);
        }
    }

    public void die(int num)
    {
        StartCoroutine(fade(num));

    }

    public IEnumerator fade(int num)
    {
        yield return new WaitForSeconds(1f);
        Color color = enemySquadCharacters[num].color;                            //color 에 판넬 이미지 참조

        while (enemySquadCharacters[num].color.a > 0f)
        {
            color.a -= Time.deltaTime / 0.5f;
            enemySquadCharacters[num].color = color;

            if (color.a <= 0f) color.a = 0f;

            yield return null;
        }
    }

    private void checkEnd()
	{
        int j = 0;
        //사망처리
        for (int i = 0; i < stagePrefabs[stageIndex].StageEnemysIndex.Length; i++)
        {
            
            if (enemySquad[i].myCurrentHp <= 0)
            {
                j++;
            }

            if (j >= stagePrefabs[stageIndex].StageEnemysIndex.Length)
            {
                battleState = BattleState.BATTLE_END;
                return;
            }

        }
    }

    private void loadResult()
	{
        //SceneManager.LoadScene("ResultScene");
        Result.SetActive(true);
    }
}

