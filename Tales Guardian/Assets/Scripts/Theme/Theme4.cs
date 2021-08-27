using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class Theme4 : MonoBehaviour
{
    public GameObject Theme4UI;
    AudioSource ClickSound;

    private void Start()
    {
        ClickSound = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (Theme4UI.activeSelf == false)
        {
            //SceneManager.LoadScene("Stage4");
            Debug.Log("4번 클릭됨");
            ClickSound.Play();
        }
    }
}