﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillEffect : MonoBehaviour
{
    public Animator anim;
    public Animator BKpang;
    public Animator justPang;
    public Animator rainbowPang;
    public Animator scratch;
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
    public IEnumerator StartAnimation1()
    {
        BKpang.SetBool("Attack", true);

        yield return new WaitForSeconds(effectTime);
        BKpang.SetBool("Attack", false);
    }
    public IEnumerator StartAnimation2()
    {
        justPang.SetBool("Attack", true);

        yield return new WaitForSeconds(effectTime);
        justPang.SetBool("Attack", false);
    }
    public IEnumerator StartAnimation3()
    {
        rainbowPang.SetBool("Attack", true);

        yield return new WaitForSeconds(effectTime);
        rainbowPang.SetBool("Attack", false);
    }
    public IEnumerator StartAnimation4()
    {
        scratch.SetBool("Attack", true);

        yield return new WaitForSeconds(effectTime);
        scratch.SetBool("Attack", false);
    }
}
