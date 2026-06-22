using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class boxobsscript : MonoBehaviour
{
    private Rigidbody2D rb;
    public audiomanager audiomanager;

    private void Start()
    {
        audiomanager = GameObject.FindWithTag("audio").GetComponent<audiomanager>();
        rb = GetComponent<Rigidbody2D>();
        rb.simulated = false;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer != LayerMask.NameToLayer("White layer") && collision.gameObject.CompareTag("black player"))
        {
            Destroy(collision.gameObject);
            audiomanager.playsfx(audiomanager.player_death);
            Invoke(nameof(restart), 0.9f);
        }
    }
    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }

}
