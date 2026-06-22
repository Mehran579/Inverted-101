using UnityEngine;
using UnityEngine.SceneManagement;
public class finalfight : MonoBehaviour
{
    public GameObject bosstext;
    public GameObject dialogue1;
    public GameObject fakeboss;
    public GameObject finalboss;
    bool initiated = true;
    public GameObject barleft;
    public GameObject barright;
    public GameObject bossattack;
    public GameObject finalpieceofart;
    public bool debuggcoming;
    public float attackdestroy;
    public GameObject whtabugdoinghere;
    public GameObject butimaknight;
    public ParticleSystem expo3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        finalpieceofart.SetActive(false);
        barleft.SetActive(false);
        barright.SetActive(false);
        bosstext.SetActive(false);
        fakeboss.SetActive(false);
        finalboss.SetActive(false);
        bossattack.SetActive(false);
        dialogue1.SetActive(false);
        whtabugdoinghere.SetActive(false);
        butimaknight.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("white player") || collision.CompareTag("black player"))
        {
            
            if (initiated)
            {
                Invoke(nameof(movecamera), 10f);
                bosstext.SetActive(true);
                Invoke(nameof(activatewrait), 3.3f);
                Destroy(bosstext, 4f);
                fakeboss.SetActive(true);
                Invoke(nameof(activateboss), 1f);
                initiated = false;
                barright.SetActive(true);
                barleft.SetActive(true);
                Invoke(nameof(BOSSIattack),7f);
                Invoke(nameof(startfinalpieceofart), 7f);
                Destroy(bossattack, attackdestroy);
                Invoke(nameof(expo), attackdestroy-0.1f);
                Invoke(nameof(showwhtabug), attackdestroy + 0.3f);
                Invoke(nameof(butamaknight), attackdestroy + 1.5f);
                Invoke(nameof(endgame), attackdestroy + 5f);
            }

        }
    }
    void endgame()
    {
        SceneManager.LoadScene(0);
    }
    void expo()
    {
        Instantiate(expo3,bossattack.transform.position, Quaternion.identity);
    }
    void butamaknight()
    {
        butimaknight.SetActive(true);
    }
    void showwhtabug()
    {
        whtabugdoinghere.SetActive(true);
    }
    void activatewrait()
    {
        dialogue1.SetActive(true);
        Destroy(dialogue1, 3.5f);
    }
    void activateboss()
    {
        finalboss.SetActive(true);
    }
    void BOSSIattack()
    {
        bossattack.SetActive (true);
    }
    void movecamera()
    {
        debuggcoming = true;
    }
    void startfinalpieceofart()
    {
        finalpieceofart.SetActive(true);
    }
}
