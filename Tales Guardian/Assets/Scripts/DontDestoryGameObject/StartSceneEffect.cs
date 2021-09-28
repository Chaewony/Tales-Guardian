using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartSceneEffect : MonoBehaviour
{
    // Start is called before the first frame update
    public int type;
    public Image chessless;
    public float transparency;
    void Start()
    {
        transparency = 0;
        StartCoroutine(Fade());
    }

    IEnumerator Fade()
    {
            yield return new WaitForSecondsRealtime(2.5f);
        while (transparency != 255 )
        {
            transparency += 10;
            chessless.color = new Color(255f, 255f, 255f, transparency/ 255f);
            yield return new WaitForSecondsRealtime(.05f);
        }

    }
}
