using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroFight : MonoBehaviour
{
    AnimatorStateInfo currentAttack;
    Animator animationController;
    HeroMove moveScript;

    float counter = 6;
    bool delay;
    bool blocking;

    void Start()
    {
        animationController = GetComponent<Animator>();
        moveScript = GetComponent<HeroMove>();
    }

    void Update()
    {
        if(Input.GetButtonDown("ctrl"))
        {
            blocking = true;
            animationController.SetTrigger("Block");
            animationController.SetBool("IdleBlock", false);
        }
        else if(Input.GetButtonUp("ctrl"))
        {
            blocking = false;
            animationController.SetBool("IdleBlock", true);
        }

        if(Input.GetButtonDown("Fire1") && !moveScript.fighting && moveScript.grounded && !delay)
        {
            StartCoroutine(AttackDelay());
            animationController.SetTrigger("Attack"+counter % 5);
            counter++;
        }
        currentAttack = animationController.GetCurrentAnimatorStateInfo(0);

        Debug.Log(currentAttack);
        if(currentAttack.IsName("Attack1") || currentAttack.IsName("Attack2") || currentAttack.IsName("Attack3") || blocking)
            moveScript.fighting = true;
        else if(!blocking)
            moveScript.fighting = false;

        //Reset modolus loop
        if(counter > 8)
            counter = 6;
    }

    IEnumerator AttackDelay()
    {
        delay = true;
        yield return new WaitForSeconds(0.25f);
        delay = false;
    }
}
