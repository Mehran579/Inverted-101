using UnityEngine;

public class whitebug : MonoBehaviour
{
    public bool bugobtained;
    GameObject player;
    public GameObject text;
    public audiomanager audiomanager;
    private void Start()
    {
        audiomanager = GameObject.FindWithTag("audio").GetComponent<audiomanager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("white player"))
        {
            gameObject.GetComponent<Collider2D>().enabled = false;
            text.SetActive(true);
            //gameObject.GetComponent<SpriteRenderer>().enabled = false;
            player = collision.gameObject;
            bugobtained = true;
            audiomanager.playmusic(audiomanager.bees, true);
            Invoke(nameof(killdabug), 3.2f);
        }
    }
    void killdabug()
    {
        bugobtained=false;
        Debug.Log("flying ability taken");
        Destroy(gameObject);
        audiomanager.playmusic(audiomanager.bees, false);
    }
    private void Update()
    {
        if (bugobtained)
        {
            transform.position = new Vector2(player.transform.position.x,player.transform.position.y+0.6f);
        }
    }
}

