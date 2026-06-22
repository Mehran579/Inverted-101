using UnityEngine;

public class boxobstrigger : MonoBehaviour
{
    public Rigidbody2D box;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("props"))
        {
            box.simulated = true;
        }
    }
}
