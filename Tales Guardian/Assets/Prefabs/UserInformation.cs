using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInformation : MonoBehaviour
{
    [SerializeField]
    private int HaveBookIndex;
    [SerializeField]
    private string UserName;

    public string MyUserName { get => UserName; set => UserName = value; }
    public int MyHaveBookIndx { get => HaveBookIndex; set => HaveBookIndex = value; }
}
