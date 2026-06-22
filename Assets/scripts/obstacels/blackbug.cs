using UnityEngine;

public class blackbug : MonoBehaviour
{
    public bool b_bugobtained;
    GameObject player;
    public audiomanager audiomanager;
    private void Start()
    {
        audiomanager = GameObject.FindWithTag("audio").GetComponent<audiomanager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("black player"))
        {
            gameObject.GetComponent<Collider2D>().enabled = false;
            //gameObject.GetComponent<SpriteRenderer>().enabled = false;
            player = collision.gameObject;
            b_bugobtained = true;
            audiomanager.playmusic(audiomanager.bees, true);
            Invoke(nameof(killdabug), 3.2f);
        }
    }
    private void Update()
    {
        if (b_bugobtained)
        {
            transform.position = new Vector2(player.transform.position.x, player.transform.position.y - 0.6f);
        }
    }
    void killdabug()
    {
        b_bugobtained = false;
        Debug.Log("flying ability taken");
        Destroy(gameObject);
        audiomanager.playmusic(audiomanager.bees, false);
    }
}
