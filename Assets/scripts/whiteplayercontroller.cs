using UnityEngine;
using UnityEngine.InputSystem;

public class whiteplayercontroller : MonoBehaviour
{
    public restarter restart;
    public ParticleSystem death;
    public float raycastradius;
    public float castdistance;
    public LayerMask groundlayer;
    public GameObject BlackPlayer;
    public inputs input;
    public float speed;
    public float jump;
    public Animator animator;
    public whitebug whitebug;
    public audiomanager audiomanager;
    private void Start()
    {
        restart = GameObject.FindWithTag("restarter").GetComponent<restarter>();
        audiomanager = GameObject.FindWithTag("audio").GetComponent<audiomanager>();
    }
    void Update()
    {
        if(gameObject.GetComponent<Collider2D>().enabled == false)
        {
            transform.position = new Vector2(BlackPlayer.transform.position.x, -BlackPlayer.transform.position.y);
        }
        if(gameObject.GetComponent<Collider2D>().enabled == true && input.movement.x != 0 && isGrounded())
        {
            
            animator.SetBool("iswalking",true);
            
        }else
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
        }else if (input.jumppressed && whitebug.bugobtained)
        {
            gameObject.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(gameObject.GetComponent<Rigidbody2D>().linearVelocity.x, jump *1.2f);
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
    //    if (restart == null || restart.isrestarting) return;
     //   Instantiate(death, transform.position, transform.rotation);
    }
    public void explode()
    {
        Instantiate(death, transform.position, transform.rotation);
        audiomanager.playsfx(audiomanager.player_death);
    }
}
