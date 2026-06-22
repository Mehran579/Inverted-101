using UnityEngine;
using UnityEngine.Audio;

public class Letterbehaviour : MonoBehaviour
{
    public ParticleSystem colliision;
    public ParticleSystem ncollision;
    public audiomanager audiomanager;
    private void Start()
    {
        audiomanager = GameObject.FindWithTag("audio").GetComponent<audiomanager>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DEBUGG"))
        {
            if (GetComponent<Rigidbody2D>().gravityScale >= 0)
            {
                audiomanager.playsfx(audiomanager.box_destroying);
                Instantiate(colliision,transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            if(GetComponent<Rigidbody2D>().gravityScale <= 0)
            {
                audiomanager.playsfx(audiomanager.box_destroying);
                Instantiate(ncollision,transform.position,Quaternion.identity);
                Destroy (gameObject);
            }
        }
        if(GetComponent<Rigidbody2D>().gravityScale <= 0 && LayerMask.LayerToName(colliision.gameObject.layer)=="White layer" || GetComponent<Rigidbody2D>().gravityScale >= 0 && LayerMask.LayerToName(colliision.gameObject.layer) == "Black layer")
        {
            audiomanager.playsfx(audiomanager.box_falling);
            Debug.Log("touychubng groudn");
        }
        
    }
}
