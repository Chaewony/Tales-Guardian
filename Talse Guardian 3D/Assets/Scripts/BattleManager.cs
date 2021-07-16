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

    // Start is called before the first frame update
    void Start()
    {
        SetPlayerSquad();
        IntitiateHp();
        SetPlayerSquadCharacters();
    }

    // Update is called once per frame
    void Update()
    {
        
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
