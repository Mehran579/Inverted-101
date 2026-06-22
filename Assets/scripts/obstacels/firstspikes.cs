using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class firstspikes : MonoBehaviour
{
    public GameObject spike;
    public restarter restarter;
    public audiomanager audiomanager;

    private void Start()
    {
        restarter = GameObject.FindWithTag("restarter").GetComponent<restarter>();
        audiomanager = GameObject.FindWithTag("audio").GetComponent<audiomanager>();    
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        spike.SetActive(true);
        if(collision.gameObject.CompareTag("white player"))
        {
            collision.gameObject.GetComponent<whiteplayercontroller>().explode();
            audiomanager.playsfx(audiomanager.player_death);
        }
        if(collision.gameObject.CompareTag("black player"))
        {
            audiomanager.playsfx(audiomanager.player_death);
            Debug.Log("fooooosh");
            collision.gameObject.GetComponent<BlackPlayerController>().explode();
        }
        restarter.restart();
        Destroy(collision.gameObject);

    }
    
}
