using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    Animator animator = null;
    WaitForSeconds delay = null;

    private void Awake()
    {
        delay = new WaitForSeconds(3f);
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        StartCoroutine(PlayerAnimCtrl());
    }

    IEnumerator PlayerAnimCtrl()
    {
        if (Input.GetKeyDown(KeyCode.U)) 
        {
            animator.applyRootMotion = true;
            animator.SetTrigger("IsAxeSwing");
            yield return delay;
            animator.applyRootMotion = false;

        }
        else if (Input.GetKeyDown(KeyCode.I))
        {
            animator.applyRootMotion = true;
            animator.SetTrigger("IsPickAxeSwing");
            yield return delay;
            animator.applyRootMotion = false;
        }
        else if ( Input.GetKeyDown(KeyCode.O))
        {
            animator.applyRootMotion = true;
            animator.SetTrigger("IsSeed");
            yield return delay;
            animator.applyRootMotion = false;
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            animator.applyRootMotion = true;
            animator.SetTrigger("IsTree");
            yield return delay;
            animator.applyRootMotion = false;
        }
        else
        {
            yield return null;
        }
    }
}