using UnityEngine;

public class boxobstrigger : MonoBehaviour
{
    public Rigidbody2D box;
    public audiomanager audiomanager;
    private void Start()
    {
        audiomanager = GameObject.FindWithTag("audio").GetComponent<audiomanager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("props"))
        {
            box.simulated = true;
            //Invoke(nameof(makefallingsound), 0.01f);
        }
    }
    void makefallingsound()
    {
        audiomanager.playsfx(audiomanager.box_falling);
    }
}
