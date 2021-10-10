using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameResult : MonoBehaviour
{
    public bool IsWin;
    public int UseTurn;

    public void Start()
    {
        IsWin = true;
        UseTurn = 0;
    }

}
