using JetBrains.Annotations;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class bossfightscript : MonoBehaviour
{
    public GameObject DEBUGG;
    public GameObject enteringarena;
    public GameObject motivetext1;
    public GameObject motivetext2;
    public GameObject[] positivetitle;
    public GameObject[] negativetitle;
    public float timebetweenappearance = 0.5f;
    public bool fightstarting;
    public GameObject stopper;
    public audiomanager audiomanager;
    
    private void Start()
    {
        audiomanager = GameObject.FindWithTag("audio").GetComponent<audiomanager>();
        DEBUGG.SetActive(false);
        foreach (GameObject i in positivetitle)
        {
            i.SetActive(false);
        }
        foreach(GameObject i in negativetitle)
        {
            i.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("white player") || collision.CompareTag("black player"))
        {
            GetComponent<Collider2D>().enabled = false;
            fightstarting = true;
            Invoke(nameof(startended), 8f);
            DEBUGG.SetActive(true);
            motivetext1.SetActive(false);
            motivetext2.SetActive(false);
            Destroy(enteringarena);
            StartCoroutine(showtitle());
            StartCoroutine(nshowtitle());
            Invoke(nameof(fallletters), 6.5f);
            Invoke(nameof(nfallletters), 6.5f);
            audiomanager.playsfx(audiomanager.bossentry);
            audiomanager.music.Stop();
        }
    }
    IEnumerator showtitle()
    {
        foreach(GameObject i in positivetitle)
        {
            i.SetActive(true);
            audiomanager.playsfx(audiomanager.letterpop);
            yield return new WaitForSeconds(timebetweenappearance);
        }
    }
    IEnumerator nshowtitle()
    {
        foreach (GameObject i in negativetitle)
        {
            i.SetActive(true);
            
            audiomanager.playsfx(audiomanager.letterpop);
            yield return new WaitForSeconds(timebetweenappearance);
        }
    }

     void makefallingsound()
     {
        audiomanager.playsfx(audiomanager.box_falling);
     }
     void startended()
    {
        audiomanager.playmusic(audiomanager.boss_theme, true);
        Destroy(stopper);
        fightstarting = false;
    }
    void fallletters()
    {
        StartCoroutine(fallletter());
    }
    IEnumerator fallletter()
    {
        foreach(GameObject i in positivetitle)
        {
            Rigidbody2D letterb = i.GetComponent<Rigidbody2D>();
            letterb.simulated = true;
            yield return new WaitForSeconds(0.2f);
        }
    }
    void nfallletters()
    {
        StartCoroutine(nfallletter());
    }
    IEnumerator nfallletter()
    {
        foreach(GameObject i in negativetitle)
        {
            Rigidbody2D nletterrb = i.GetComponent<Rigidbody2D>();
            nletterrb.simulated = true;
            yield return new WaitForSeconds(0.2f);
        }
    }
}
