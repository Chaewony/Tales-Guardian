using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public GameObject[] DontGoPlace;
    public int DontGoPlaceSize;

    [SerializeField]
    public GameObject[] Stage;
    public int StageSize;

    public GameObject SelectStage;

    [SerializeField]
    public float[] StageDistance; // 플레이어랑 스테이지랑 거리
    [SerializeField]
    public float[] MouseStageDistance; // 마우스랑 스테이지랑 거리

    public GameObject player;
    public Vector3 MoveVector;
    public Vector3 TargetPoint;

    public int SelectStageAdress; // 어느 스테이지를 클릭했는지
    public int playerInStageAdress; // 플레이어가 어느 스테이지 위에 있는지

    public bool playerHaveMovingTarget; // 플레이어가 타겟으로 움직이고 있는가?
    public bool GoAhead; // 앞으로 갈꺼임
    public bool GoBack; // 뒤로 갈꺼임
    public int MoveType;
    public int targetStageAdress;

    void Start()
    {
        MoveVector = new Vector3(0.0f, 0.0f, 0.0f);
        player.transform.position = new Vector3(Stage[0].transform.position.x, Stage[0].transform.position.y + 40, Stage[0].transform.position.z);
        TargetPoint.x = Stage[0].transform.position.x;
        TargetPoint.y = Stage[0].transform.position.y;
        playerInStageAdress = 0;
        SelectStageAdress = 15;
        playerHaveMovingTarget = false;
        GoAhead = false;
        GoBack = false;
        MoveType = 0; // 0은 가만히, 1은 가만히 있을때 앞으로 이동 명령, 2는 가만히 있을때 뒤로 이동명령, 3은 움직이고 있을때 앞으로 이동명령, 4는 움직이고 있을때 뒤로 이동명령, 5는 자유 이동
    }

    void Update()
    {
        //플레이어가 어느 포인트 안에 있는지 측정
        for (int i = 0; i < StageSize; i++)
        {
            if (StageDistance[i] <= 48.0f) { playerInStageAdress = i; }
        }

        //스테이지와 플레이어 간의 간격 측정
        for (int i = 0; i < StageSize; i++)
        {
            StageDistance[i] = (Stage[i].transform.position - player.transform.position).magnitude;
        }

        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            //스테이지와 마우스 간의 간격 측정
            for (int i = 0; i < StageSize; i++)
            {
                MouseStageDistance[i] = (Stage[i].transform.position - Input.mousePosition).sqrMagnitude;
            }
            
            for (int i =0; i<StageSize;i++)
            {
                if(MouseStageDistance[i] <= 10000.0f)
                {
                    SelectStageAdress = i;
                }
            }
            if(SelectStageAdress ==0 || SelectStageAdress == 2 || SelectStageAdress == 5 || SelectStageAdress == 8 || SelectStageAdress == 10)
            {
                if(playerHaveMovingTarget == false)
                {
                    if (SelectStageAdress > playerInStageAdress) // 플레이어가 움직이지 않을때 플레이어가 있는 포인트 < 선택한 스테이지의 포인트
                    {
                        GoAhead = true;
                        GoBack = false;
                        playerHaveMovingTarget = true;
                        MoveType = 1;
                        targetStageAdress = playerInStageAdress + 1;
                    }

                    if (SelectStageAdress < playerInStageAdress)// 플레이어가 움직이지 않을때 플레이어가 있는 포인트 > 선택한 스테이지의 포인트
                    {
                        GoAhead = false;
                        GoBack = true;
                        playerHaveMovingTarget = true;
                        targetStageAdress = playerInStageAdress - 1;
                        MoveType = 2;
                    }

                    if(SelectStageAdress == playerInStageAdress)
                    {
                        GoAhead = false;
                        GoBack = false;
                        playerHaveMovingTarget = false;
                        MoveType = 0;
                    }
                }
                else if(playerHaveMovingTarget)
                {
                    if (SelectStageAdress > playerInStageAdress) // 플레이어가 움직이고 있을때 플레이어가 있는 포인트 < 선택한 스테이지의 포인트
                    {
                        GoAhead = true;
                        GoBack = false;
                        MoveType = 3;
                        targetStageAdress = playerInStageAdress + 1;
                    }
                    if (SelectStageAdress < playerInStageAdress)// 플레이어가 움직이고 있을때 플레이어가 있는 포인트 > 선택한 스테이지의 포인트
                    {
                        GoAhead = false;
                        GoBack = true;
                        MoveType = 4;
                        targetStageAdress = playerInStageAdress;
                    }
                    if (SelectStageAdress == playerInStageAdress)
                    {
                        GoAhead = false;
                        GoBack = false;
                        playerHaveMovingTarget = false;
                        MoveType = 0;
                    }
                } 
            }
        }
    }

    void LateUpdate()
    {
        if(SelectStageAdress == playerInStageAdress)
        {
            playerHaveMovingTarget = false;
            MoveType = 0;
        }

        switch (MoveType)
        {
            
            case 0:
                playerHaveMovingTarget = false;
                MoveVector = new Vector3(0.0f, 0.0f, 0.0f);
                GoAhead = false;
                GoBack = false;
                break;
            case 1:
                TargetPoint = Stage[targetStageAdress].transform.position;
                if (targetStageAdress == playerInStageAdress) { MoveType = 5; }
                break;
            case 2:
                TargetPoint = Stage[targetStageAdress].transform.position;
                if (targetStageAdress == playerInStageAdress) { MoveType = 5; }
                break;
            case 3:
                TargetPoint = Stage[targetStageAdress].transform.position;
                if (targetStageAdress == playerInStageAdress) { MoveType = 5; }
                break;
            case 4:
                TargetPoint = Stage[targetStageAdress].transform.position;
                if (targetStageAdress == playerInStageAdress) { MoveType = 5; }
                break;
            case 5:
                if (GoAhead) { TargetPoint = Stage[playerInStageAdress + 1].transform.position; }
                if (GoBack) { TargetPoint = Stage[playerInStageAdress - 1].transform.position; }
                break;
        }

        MoveVector.x = (TargetPoint.x - player.transform.position.x) / 150.0f;
        MoveVector.y = (TargetPoint.y + 40 - player.transform.position.y) / 150.0f;
        player.transform.position += MoveVector;
    }
}
