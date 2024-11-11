using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    //References
    Animator am;
    Playermovement pm;
    SpriteRenderer sr;


    void Start()
    {
        am = GetComponent<Animator>();
        pm = GetComponent<Playermovement>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pm.moveDir.x != 0 || pm.moveDir.y != 0)
        {
            am.SetBool("Move", true);
            SpriteDiretionChecker();
        }
        else
        {
            am.SetBool("Move", false);
        }
    }

    void SpriteDiretionChecker()
    {
        if(pm.lastHorizontalVector < 0)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
    }
}
