using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillEffect : MonoBehaviour
{
    public Animator anim;
    public float effectTime;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator StartAnimation0()
    {
        anim.SetBool("Attack",true);

        yield return new WaitForSeconds(effectTime);
        anim.SetBool("Attack", false);
    }

}
