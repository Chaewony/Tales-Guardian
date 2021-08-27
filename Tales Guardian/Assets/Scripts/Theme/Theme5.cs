using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class Theme5 : MonoBehaviour
{
    public GameObject Theme5UI;
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

        if (Theme5UI.activeSelf == false)
        {
            //SceneManager.LoadScene("Stage5");
            Debug.Log("5번 클릭됨");
            ClickSound.Play();
        }
    }
}