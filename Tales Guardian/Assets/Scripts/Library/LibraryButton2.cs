using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LibraryButton2 : MonoBehaviour
{
    public LibraryButtonType librarybuttonType;

    public GameObject OnceDrawPanel;
    public GameObject TenTimesDrawPanel;
    // OnceDraw 1회뽑기
    //TenTimesDraw 10회뽑기
    //SeePercentage 확률확인
    //Close 창 닫기

    public void OnButtonClick()
    {
        switch (librarybuttonType)
        {
            case LibraryButtonType.CloseTenTimesDraw:
                TenTimesDrawPanel.SetActive(false);
                break;
            case LibraryButtonType.CloseOnceDraw:
                OnceDrawPanel.SetActive(false);
                break;
            case LibraryButtonType.Close:
                break;
        }
    }
}
