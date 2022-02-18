using UnityEngine;
using System.Collections;
public class ScriptToAnimate : MonoBehaviour
{
    public Animator animator;
    void Start(){
        animator.SetTrigger("Idle");
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            animator.SetTrigger("Idle");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            animator.SetTrigger("Atk1");
        }
        if (Input.GetKey("d"))
        {
            animator.Play("Walk");
        }
    }
}