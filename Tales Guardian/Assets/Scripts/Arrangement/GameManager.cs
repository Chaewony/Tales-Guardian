using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] CharacterPrefabs;
    public List<CharacterInfo> allCharacter = new List<CharacterInfo>();
    public bool canClickGrid; //그리드가 클릭될 수 있는 상태인지 아닌지 판별
    public GameObject[] slot;
    public GameObject[] FieldPrefabs;
    [SerializeField]
    private List<FieldInfo> allFields = new List<FieldInfo>();

    public int arrangementCount;

    private void Start()
	{
        canClickGrid = false;
        SetAllCharactersToSelectedFalse();

        for(int i = 0; i<CharacterPrefabs.Length;i++)
        {
            CharacterPrefabs[i] = GameObject.Find("DDCharacters").transform.GetChild(i).gameObject;
        }
       
        for(int i =0; i<FieldPrefabs.Length;i++)
        {
            FieldPrefabs[i] = GameObject.Find("DDField").transform.GetChild(i).gameObject;
        }
    }
    // Update is called once per frame CharacterPrefabs[i].GetComponent<CharactersPrefab>()
    void Update()
    {
        //그리드가 클릭될 수 있는 상태인지 아닌지 판별, 가지고 있는 카드 중 셀렉된 캐릭터가 있으면true, 아니면 false
        for (int i = 0; i < allCharacter.Count; i++)
        {
            if (CharacterPrefabs[i].GetComponent<CharactersPrefab>().myIsOwning && !CharacterPrefabs[i].GetComponent<CharactersPrefab>().myIsSelected)
            {
                canClickGrid = false;
            }
            else if (CharacterPrefabs[i].GetComponent<CharactersPrefab>().myIsOwning && CharacterPrefabs[i].GetComponent<CharactersPrefab>().myIsSelected && arrangementCount < 4)
			{
                canClickGrid = true;
                break;
            }
        }

        //배치되면 배치된 카드 슬롯 비활성화
        for (int i = 0; i < allFields.Count; i++)
        {
            if (FieldPrefabs[i].GetComponent<FieldPrefab>().myArrangedCharIndex != -1)
            {
                slot[FieldPrefabs[i].GetComponent<FieldPrefab>().myArrangedCharIndex].SetActive(false);
            }
        }
    }
    /*카드 슬롯 중 하나가 클릭 되면 실행되는 함수. 각 캐릭터들의 isSelected 변수를 관리해줌
     isSelected 변수는 리스트 중 하나의 요소(캐릭터)만 true값을 가질 수 있음 */
    public void SetAllCharactersToSelectedFalse()
	{
        for (int i = 0; i < allCharacter.Count; i++)
        {
            CharacterPrefabs[i].GetComponent<CharactersPrefab>().myIsSelected = false;
        }
    }

    /*그리드 중 4칸이 모두 클릭된 상태(isClicked=true)일 경우 더이상 can Click을 false로 바꿔주기
     그리드 리스트 만들 것*/
}
