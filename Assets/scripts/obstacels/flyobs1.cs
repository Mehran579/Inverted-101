using UnityEngine;
using UnityEngine.SceneManagement;

public class flyobs1 : MonoBehaviour
{
    public restarter restarter;
    public boxtrigger_spawner spawner;
    public audiomanager audiomanager;
    private void Start()
    {
        restarter = GameObject.FindWithTag("restarter").GetComponent<restarter>();
        spawner = GameObject.FindWithTag("spawner").GetComponent<boxtrigger_spawner>();
        audiomanager= GameObject.FindWithTag("audio").GetComponent<audiomanager>();
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if((collision.gameObject.CompareTag("white player")||collision.gameObject.CompareTag("black player")) && GetComponent<Rigidbody2D>().bodyType == RigidbodyType2D.Static)
        {
            restarter.restart();
            if(collision.gameObject.CompareTag("white player"))
            {
                collision.gameObject.GetComponent<whiteplayercontroller>().explode();
                audiomanager.playsfx(audiomanager.player_death);

                Destroy(collision.gameObject);
            }
            if(collision.gameObject.CompareTag("black player"))
            {
                collision.gameObject.GetComponent<BlackPlayerController>().explode();
                audiomanager.playsfx(audiomanager.player_death);

                Destroy(collision.gameObject);
            }
            //Invoke(nameof(restart), 0.9f);
        }

        if (collision.gameObject.CompareTag("white player") && GetComponent<Rigidbody2D>().gravityScale >= 0)
        {
            restarter.restart();
            collision.gameObject.GetComponent<whiteplayercontroller>().explode();
            audiomanager.playsfx(audiomanager.player_death);
            //Invoke(nameof(restart), 0.9f);
            Destroy(collision.gameObject);
        }else if (collision.gameObject.CompareTag("black player") && GetComponent<Rigidbody2D>().gravityScale <= 0)
        {
            restarter.restart();
            collision.gameObject.GetComponent<BlackPlayerController>().explode();
            audiomanager.playsfx(audiomanager.player_death);
            //dInvoke(nameof(restart), 0.9f);
            Destroy(collision.gameObject);
        }else if (collision.gameObject.CompareTag("DEBUGG"))
        {
            Debug.Log($"gameObject name: {gameObject.name}");
            Debug.Log($"spawner.boxes length: {spawner.boxes.Length}");
            Debug.Log($"boxparticles length: {spawner.boxparticles.Length}");
            audiomanager.playsfx(audiomanager.box_destroying);
            for (int i = 0; i < spawner.boxes.Length; i++)
            {
                if(gameObject.name == spawner.boxes[i].name)
                {
                    Instantiate(spawner.boxparticles[i],transform.position,Quaternion.identity);
                }
            }
            Destroy(gameObject);
        }
    }
    
}
