using UnityEngine;

public class boss_entry_script : MonoBehaviour
{
    public bool enteredarena;
    public GameObject barright;
    public GameObject barleft;
    public GameObject motivationtext;
    public GameObject motivationTEXT2;
    public audiomanager audiomanager;
    private void Start()
    {
        motivationtext.SetActive(false);
        barright.SetActive(false);
        barleft.SetActive(false);
        motivationTEXT2.SetActive(false);
        audiomanager = GameObject.FindWithTag("audio").GetComponent<audiomanager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("white player") || collision.gameObject.CompareTag("black player"))
        {
            enteredarena = true;
            barright.SetActive(true);
            barleft.SetActive(true);
            audiomanager.playsfx(audiomanager.closing   );
            motivationtext.SetActive(true);
            motivationTEXT2.SetActive(true);
        }
    }
}
