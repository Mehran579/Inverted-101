using System.Collections;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;
public class hehebomb : MonoBehaviour
{
    public Slider bosshealt;
    public ParticleSystem explosion;
    GameObject debug;
    private void Start()
    {
        gameObject.SetActive(false);
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DEBUGG"))
        {
            debug = collision.gameObject;

            Invoke(nameof(showparticles), 0.2f);
            Destroy(gameObject, 0.3f);

        }
    }
    void showparticles()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        debug.GetComponent<DEBUGG>().increasehealth();
    }
}
