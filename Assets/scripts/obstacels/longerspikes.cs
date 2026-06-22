using UnityEngine;

public class longerspikes : MonoBehaviour
{
    public restarter restarter;
    public audiomanager audiomanager;
    private void Start()
    {
        restarter = GameObject.FindWithTag("restarter").GetComponent<restarter>();
        audiomanager = GameObject.FindWithTag("audio").GetComponent<audiomanager>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("white player"))
        {
            collision.gameObject.GetComponent<whiteplayercontroller>().explode();
            audiomanager.playsfx(audiomanager.player_death);

        }
        if (collision.gameObject.CompareTag("black player"))
        {
            audiomanager.playsfx(audiomanager.player_death);
            Debug.Log("fooooosh");
            collision.gameObject.GetComponent<BlackPlayerController>().explode();
        }
        Destroy(collision.gameObject);
        restarter.restart();
    }
}
