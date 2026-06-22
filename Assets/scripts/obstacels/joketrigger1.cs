using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class joketrigger1 : MonoBehaviour
{
    GameObject player;
    restarter restarter;
    public GameObject joke1;
    bool cankill;
    private void Start()
    {
        restarter = GameObject.FindWithTag("restarter").GetComponent<restarter>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("black player"))
        {
            cankill = true;
            joke1.SetActive(true);
            Invoke(nameof(killafterXsec), 6.5f);
            player = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        cankill = false;
    }


    void killafterXsec()
    {
        if (cankill)
        {
            Destroy(player);
            restarter.restart();
        }
    }
}
