using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter2D_2_Movement : MonoBehaviour
{
    //Movement Variables
    Rigidbody2D rb;
    public float speed;
    public float jumpForce;
    private float moveX;
    private float moveY;

    public float distToGround = 1.0f;
    public LayerMask GroundLayer;

    //Combat Variables
    public int fighterHealth = 10;
    public LayerMask enemyFighter;
    public Animator playerAnim;
    public Transform punchPos;
    public float punchRangeX;
    public float punchRangeY;
    public int punchDamage;
    private float timeBetweenPunch;
    public float startTimeBetweenPunch;
    bool isHit = false;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        Punch();
    }

    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal2");
        float moveBy = x * speed;
        rb.velocity = new Vector2(moveBy, rb.velocity.y);

        //PLAYER DIRECTION
        moveX = Input.GetAxis("Horizontal2");
        if (moveX < 0.0f)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (moveX > 0.0f)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }

        //Animations
        if (moveBy != 0)
        {
            GetComponent<Animator>().SetBool("IsRunning", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("IsRunning", false);
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            GetComponent<Animator>().SetBool("IsJumping", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("IsJumping", false);
        }
        if (rb.velocity.y < 0)
        {
            GetComponent<Animator>().SetBool("IsFalling", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("IsFalling", false);
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            GetComponent<Animator>().SetBool("IsPunching", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("IsPunching", false);
        }
        if (isHit)
        {
            GetComponent<Animator>().SetBool("IsHit", true);
            isHit = false;
        }
        else
        {
            GetComponent<Animator>().SetBool("IsHit", false);
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    public bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, distToGround, GroundLayer);
        if (hit.collider != null)
        {
            return true;
        }
        return false;
    }

    void Punch()
    {
        if (timeBetweenPunch <= 0)
        {
            if (Input.GetKey(KeyCode.O))
            {
                Collider2D[] enemiesToDamage = Physics2D.OverlapBoxAll(punchPos.position, new Vector2(punchRangeX, punchRangeY), 0, enemyFighter);
                Debug.Log("These are the enemies hit: " + enemiesToDamage);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    
                    enemiesToDamage[i].GetComponent<Fighter2D_Movement>().TakeDamage(punchDamage);
                }
            }
            timeBetweenPunch = startTimeBetweenPunch;
        }
        else
        {
            timeBetweenPunch -= Time.deltaTime;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(punchPos.position, new Vector3(punchRangeX, punchRangeY, 1));
    }

    public void TakeDamage(int damage)
    {
        isHit = true;
        fighterHealth = fighterHealth - damage;
    }
}
