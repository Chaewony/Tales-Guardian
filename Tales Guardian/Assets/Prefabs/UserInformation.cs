using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInformation : MonoBehaviour
{
    [SerializeField]
    private int HaveBookIndex;
    [SerializeField]
    private string UserName;

    public int MyHaveBookIndx { get => HaveBookIndex; set => HaveBookIndex = value; }
}
