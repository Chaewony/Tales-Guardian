using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Draw : MonoBehaviour
{
    // Start is called before the first frame update
    public Text Havebookmarker;
    [SerializeField]
    private GameObject User;

    public void Start()
    {
        DrawUserHaveBookMarker();
    }
    public int FunctionDraw()
    {
        int DrawResult = 0;
        int TmpResult;

        TmpResult = Random.Range(0, 1000);
        if (TmpResult >= 0 && TmpResult < 110) DrawResult = 0;
        if (TmpResult >= 120 && TmpResult < 220) DrawResult = 1;
        if (TmpResult >= 220 && TmpResult < 330) DrawResult = 2;
        if (TmpResult >= 330 && TmpResult < 440) DrawResult = 3;
        if (TmpResult >= 440 && TmpResult < 550) DrawResult = 4;
        if (TmpResult >= 550 && TmpResult < 600) DrawResult = 5;
        if (TmpResult >= 600 && TmpResult < 650) DrawResult = 6;
        if (TmpResult >= 650 && TmpResult < 700) DrawResult = 7;
        if (TmpResult >= 700 && TmpResult < 750) DrawResult = 8;
        if (TmpResult >= 750 && TmpResult < 800) DrawResult = 9;
        if (TmpResult >= 800 && TmpResult < 850) DrawResult = 10;
        if (TmpResult >= 850 && TmpResult < 894) DrawResult = 11;
        if (TmpResult >= 894 && TmpResult < 938) DrawResult = 12;
        if (TmpResult >= 938 && TmpResult < 982) DrawResult = 13;
        if (TmpResult >= 982 && TmpResult < 991) DrawResult = 14;
        if (TmpResult >= 991 && TmpResult < 1000) DrawResult = 15;

        return DrawResult;
    }

    public void DrawUserHaveBookMarker()
    {
        Havebookmarker.text = "보유 중인 책갈피 수 " + User.GetComponent<UserInformation>().MyHaveBookIndx;
    }
}
