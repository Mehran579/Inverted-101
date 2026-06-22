using System.Security.Cryptography;
using UnityEngine;

public class bombtrigger : MonoBehaviour
{
    public GameObject knightwithbomb;
    public float timetospawnknight;
    public boxtrigger_spawner boxtrigger_Spawner;
    public GameObject hehebomb;
    public GameObject bossdialogue1st;
    public GameObject bossdialogue2nd;
    public GameObject thanksd3;
    public GameObject knightd;
    public GameObject continuetext;
    public GameObject bosshealth;
    bool knightinvoked = true;
    bool D1activated = true;
    public audiomanager audiomanager;
    private void Start()
    {
        audiomanager = GameObject.FindWithTag("audio").GetComponent<audiomanager>();
        knightd.SetActive(false);
        knightwithbomb.SetActive(false);
        bossdialogue1st.SetActive(false);
        bossdialogue2nd.SetActive(false);
        thanksd3.SetActive(false);
        continuetext.SetActive(false);
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("white player") || collision.gameObject.CompareTag("black player"))
        {
            audiomanager.music.Stop();
            if (D1activated)
            {
                Invoke(nameof(activate1stdialogue), 0.5f);
                Invoke(nameof(deactivate1stdialogue), 2.5f);
                Invoke(nameof(activate2ndialogue), 2.5f);
                Destroy(bossdialogue2nd, 3.5f);
                Destroy(bossdialogue1st, 2.5f);
                D1activated = false;
            }
            if (knightinvoked)
            {
                Invoke(nameof(activateknight), timetospawnknight);
                Invoke(nameof(throwbomb), 8.8f);
                Invoke(nameof(thankd3), 10f);
                Debug.Log("iamtired");
                Invoke(nameof(continuetextf), 15f);
                Invoke(nameof(startmusicagain), 14f);
                knightinvoked = false;
            }
            boxtrigger_Spawner.boxcredits = 0;
            //Invoke(nameof(activate1stdialogue), 2.5f);
        }
    }
    void continuetextf()
    {
        continuetext.SetActive(true);
        
        Destroy(continuetext, 5f);  
        GetComponent<Collider2D>().enabled = false;
    }
    void activate1stdialogue()
    {
        bossdialogue1st.SetActive(true);
    }
    void activate2ndialogue()
    {
        bossdialogue2nd.SetActive(true);
    }
    void deactivate1stdialogue()
    {
        bossdialogue1st.SetActive(false);
    }
    void activateknight()
    {
        audiomanager.playmusic(audiomanager.helicopter,true);
        knightwithbomb.SetActive(true);
        Invoke(nameof(activateknighd), 2.3f);
        Destroy(knightd, 4f);
    }
    void activateknighd()
    {
        knightd.SetActive(true);
    }
    void throwbomb()
    {
        hehebomb.SetActive(true);
        hehebomb.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(-10f, -10f);
        audiomanager.playsfx(audiomanager.bomb);
        audiomanager.playmusic(audiomanager.helicopter, false);
        audiomanager.music.Stop();
    }
    void startmusicagain()
    {
        audiomanager.music.Play();
    }
    void thankd3()
    {
        thanksd3.SetActive(true);
        Destroy(thanksd3, 2.5f);
        Destroy(bosshealth, 3f);
        Debug.Log('h');
    }
}
