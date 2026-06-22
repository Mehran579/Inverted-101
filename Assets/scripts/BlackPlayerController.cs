using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class BlackPlayerController : MonoBehaviour
{
    public restarter restart;
    public ParticleSystem death;
    public blackbug blackbug;
    public float raycastradius;
    public float castdistance;
    public LayerMask groundlayer;
    public GameObject WhitePlayer;
    public inputs input;
    public float speed;
    public float jump;
    public Animator animator;
    public audiomanager audiomanager;
    private void Start()
    {
        restart = GameObject.FindWithTag("restarter").GetComponent<restarter>();
        audiomanager = GameObject.FindWithTag("audio").GetComponent<audiomanager>();
    }
    void Update()
    {
        if (gameObject.GetComponent<Collider2D>().enabled == false)
        {
            transform.position = new Vector2(WhitePlayer.transform.position.x, -WhitePlayer.transform.position.y);
        }
        if(gameObject.GetComponent<Collider2D>().enabled == true && input.movement.x != 0 && isGrounded())
        {
            animator.SetBool("iswalking", true);
        }
        else
        {
            animator.SetBool("iswalking", false);
        }
        
        
    }
    public void FixedUpdate()
    {
        gameObject.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(input.movement.x * speed, gameObject.GetComponent<Rigidbody2D>().linearVelocity.y);
        if (input.jumppressed && isGrounded())
        {
            gameObject.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(gameObject.GetComponent<Rigidbody2D>().linearVelocity.x, jump);
            input.jumppressed = false;
        }
        else if (input.jumppressed && blackbug.b_bugobtained)
        {
            gameObject.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(gameObject.GetComponent<Rigidbody2D>().linearVelocity.x, jump * 1.5f);
            input.jumppressed = false;
        }
    }


    public bool isGrounded()
    {
        if (Physics2D.CircleCast(transform.position, raycastradius, -transform.up, castdistance, groundlayer))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position - transform.up * castdistance, raycastradius);
    }
    private void OnDestroy()
    {
        if (restart.isrestarting || restart == null) return;
        Instantiate(death, transform.position, transform.rotation);
    }
    public void explode()
    {
        Instantiate(death, transform.position, transform.rotation);
        audiomanager.playsfx(audiomanager.player_death);
    }
}
