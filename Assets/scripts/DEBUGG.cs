using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DEBUGG : MonoBehaviour
{
    public restarter restarter;
    public Slider slider;
    public audiomanager audiomanager;
    private void Start()
    {
        restarter = GameObject.FindGameObjectWithTag("restarter").GetComponent<restarter>();
        audiomanager = GameObject.FindGameObjectWithTag("audio").GetComponent<audiomanager>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("white player"))
        {
            collision.gameObject.GetComponent<whiteplayercontroller>().explode();
            audiomanager.playsfx(audiomanager.player_death);
            restarter.restart();
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("black player"))
        {
            restarter.restart();
            collision.gameObject.GetComponent<BlackPlayerController>().explode();
            Destroy(collision.gameObject);
            audiomanager.playsfx(audiomanager.player_death);
        }

    }
    public void increasehealth()
    {
        StartCoroutine(healthincrement());
    }
    IEnumerator healthincrement()
    {
        for (int i = 0; i < 101; i++)
        {
            slider.value = i;
            yield return new WaitForSeconds(0.00001f);
        }
    }
}
