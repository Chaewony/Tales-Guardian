using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public List<FieldInfo> allField = new List<FieldInfo>();
    public List<CharacterInfo> allCharacter = new List<CharacterInfo>();
    public List<CharacterInfo> playerSquad = new List<CharacterInfo>();//플레이어 스쿼드 리스트

    // Start is called before the first frame update
    void Start()
    {
        SetPlayerSquad();
        IntitiateHp();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SetPlayerSquad()
	{
        int j = 0;
        for (int i = 0; i < allField.Count; i++)
            if (allField[i].myArrangedCharIndex != -1)
            {
                playerSquad[j] = allCharacter[allField[i].myArrangedCharIndex];
                j++;
            }
    }
    void IntitiateHp()//current hp 초기화
	{
        for(int i = 0; i < playerSquad.Count; i++)
		{
            playerSquad[i].myCurrentHp = playerSquad[i].myHp;
		}
	}
}
