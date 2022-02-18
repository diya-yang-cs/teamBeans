using UnityEngine;
using System.Collections;
public class AnimationWithScripting : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite[] walk;
    public Sprite[] idle;
    public Sprite[] atk1;
    void Start()
    {
        StartCoroutine(Idle());
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            StopAllCoroutines();
            StartCoroutine(Idle());
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            StopAllCoroutines();
            StartCoroutine(ATK1());
        }
        if (Input.GetKeyDown(KeyCode.D))
      {
            StopAllCoroutines();
            StartCoroutine(Walk());
        }
    }
    IEnumerator Idle()
    {
        int i;
        i = 0;
        while (i < idle.Length)
        {
            spriteRenderer.sprite = idle[i];
            i++;
            yield return new WaitForSeconds(0.07f);
            yield return 0;
                
        }
        StartCoroutine(Idle());
    }
    IEnumerator Walk()
    {
        int i;
        i = 0;
        while (i < walk.Length)
        {
            spriteRenderer.sprite = walk[i];
            i++;
            yield return new WaitForSeconds(0.07f);
            yield return 0;
        }
        StartCoroutine(Walk());
    }

    IEnumerator ATK1()
    {
        int i;
        i = 0;
        while (i < atk1.Length)
        {
            spriteRenderer.sprite = atk1[i];
            i++;
            yield return new WaitForSeconds(0.07f);
            yield return 0;

        }
        StartCoroutine(ATK1());
    }
}