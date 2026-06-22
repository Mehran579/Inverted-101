using UnityEngine;

public class fake_carcass : MonoBehaviour
{
    public GameObject finalboss;
    audiomanager audiomanager;
    private void Start()
    {
        finalboss.SetActive(false);
        audiomanager = GameObject.FindWithTag("audio").GetComponent<audiomanager>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        Invoke(nameof(activateboss),1f);
        audiomanager.playmusic(audiomanager.finalbosslaugh, true);
    }
    void activateboss()
    {
        finalboss.SetActive(true);
    }
}
