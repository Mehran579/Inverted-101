using UnityEngine;

public class followposition : MonoBehaviour
{
    public GameObject otherplayer;
    
    //Collider2D playercol;
    //Collider2D otherplayercol;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (gameObject.GetComponent<Collider2D>().enabled == false) 
        {
            transform.position = new Vector2(otherplayer.transform.position.x, -otherplayer.transform.position.y);
        }
    }
}
