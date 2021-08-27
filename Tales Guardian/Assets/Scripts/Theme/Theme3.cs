using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class Theme3 : MonoBehaviour
{
    public GameObject Theme3UI;
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

        if (Theme3UI.activeSelf == false)
        {
            Debug.Log("3번 클릭됨");
            ClickSound.Play();
            //SceneManager.LoadScene("Stage3"); 
        }
    }
}