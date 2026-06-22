using System.Transactions;
using UnityEngine;

public class boxtrigger_spawner : MonoBehaviour
{
    public GameObject[] boxes;
    public GameObject playerx;
    public float timebetweenfall;
    public float boxcredits = 39;
    public ParticleSystem[] boxparticles;
    public audiomanager audiomanager;
    private void Start()
    {
        audiomanager = GameObject.FindWithTag("audio").GetComponent<audiomanager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("white player")|| collision.CompareTag("black player"))
        {
            fallbox();
        }
    }
    void fallbox()
    {
        if(boxcredits >= 0)
        {
            GameObject boxprefab = boxes[Random.Range(0, boxes.Length)];
            GameObject box = Instantiate(boxprefab,Vector2.zero,Quaternion.identity);
            box.name = boxprefab.name;
            Destroy(box, 2f);
            if (box.GetComponent<Rigidbody2D>().gravityScale <= 0) 
            {
                if (box.name == "bossbox1")
                {
                    box.transform.position = new Vector2(playerx.transform.position.x + Random.Range(10, 15), -10f);
                    boxcredits -= 1;
                    Invoke(nameof(waitbetweenfall),timebetweenfall);
                }
                else if (box.name == "bossbox2")
                {
                    box.transform.position = new Vector2(playerx.transform.position.x + Random.Range(10, 15), -10f);
                    boxcredits -= 2;
                    Invoke(nameof(waitbetweenfall), timebetweenfall);
                }
                else if (box.name == "bossbox3")
                {
                    box.transform.position = new Vector2(playerx.transform.position.x + Random.Range(10, 15), -10f);
                    boxcredits -= 3;
                    Invoke(nameof(waitbetweenfall), timebetweenfall);
                }
                else if (box.name == "bossbox4" && boxcredits >= 20) 
                {
                    box.transform.position = new Vector2(playerx.transform.position.x + Random.Range(13, 17), -10f);
                    boxcredits -= 20;
                    Invoke(nameof(waitbetweenfall), timebetweenfall+0.5f);
                }
                else if(box.name == "bossbox4" && boxcredits <= 20)
                {
                    Destroy(box);
                    GameObject subbox_prefab = boxes[Random.Range(4, 7)];
                    GameObject subbox = Instantiate(subbox_prefab,new Vector2(playerx.transform.position.x + Random.Range(10, 15), -10f),Quaternion.identity);
                    subbox.name = subbox_prefab.name;
                    boxcredits -= 4;
                    Destroy(subbox,4f);
                    Invoke(nameof(waitbetweenfall), timebetweenfall);
                }
                else
                {
                    Invoke(nameof(waitbetweenfall), timebetweenfall);
                }

            }
            else if (box.GetComponent<Rigidbody2D>().gravityScale >= 0)
            {
                if (box.name == "bossbox1w")
                {
                    box.transform.position = new Vector2(playerx.transform.position.x + Random.Range(10, 15), 10f);
                    boxcredits -= 1;
                    Invoke(nameof(waitbetweenfall), timebetweenfall);
                }
                else if (box.name == "bossbox2w")
                {
                    box.transform.position = new Vector2(playerx.transform.position.x + Random.Range(10, 15), 10f);
                    boxcredits -= 2;
                    Invoke(nameof(waitbetweenfall), timebetweenfall);
                }
                else if (box.name == "bossbox3w")
                {
                    box.transform.position = new Vector2(playerx.transform.position.x + Random.Range(10, 15), 10f);
                    boxcredits -= 3;
                    Invoke(nameof(waitbetweenfall), timebetweenfall);
                }
                else if (box.name == "bossbox4w" && boxcredits >= 20)
                {
                    box.transform.position = new Vector2(playerx.transform.position.x + Random.Range(13, 17), 10f);
                    boxcredits -= 20;
                    Invoke(nameof(waitbetweenfall), timebetweenfall+0.5f);
                }
                else if (box.name == "bossbox4w" && boxcredits <= 20)
                {
                    Destroy(box);
                    GameObject subbox_prefab = boxes[Random.Range(0, 3)];
                    GameObject subbox = Instantiate(subbox_prefab, new Vector2(playerx.transform.position.x + Random.Range(10, 15), 10f), Quaternion.identity);
                    subbox.name = subbox_prefab.name;
                    boxcredits -= 4;
                    Invoke(nameof(waitbetweenfall), timebetweenfall );
                    Destroy(subbox, 4);
                }
                else
                {
                    Invoke(nameof(waitbetweenfall), timebetweenfall);
                }
            }
        }
    }
    void waitbetweenfall()
    {
        fallbox();
        audiomanager.playsfx(audiomanager.box_falling);
    }
}
