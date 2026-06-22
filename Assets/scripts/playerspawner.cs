using UnityEngine;
using UnityEngine.InputSystem;

public class playerspawner : MonoBehaviour
{
    public whitebug whitebug;
    public blackbug blackbug;
    [Header("White Player")]
    public GameObject WhitePlayer;
    public Rigidbody2D whiterb;
    public SpriteRenderer whitesr;
    public Collider2D whitecol;
    public whiteplayercontroller whitecontroller;
    public TrailRenderer whitetrail;
    [Header("Black Player")]
    public GameObject BlackPlayer;
    public Rigidbody2D blackrb;
    public SpriteRenderer blacksr;
    public Collider2D blackcol;
    public BlackPlayerController blackcontroller;
    public TrailRenderer blacktrail;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        blackrb.simulated = false;
        blackcol.enabled = false;
        blacksr.enabled = false;
        blackcontroller.enabled = false;
        blacktrail.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayerInvert()
    {
        if (whitebug.bugobtained) return;
        if (blackbug.b_bugobtained) return;
        
        if (whitecol.isActiveAndEnabled)
        {
            whitecol.enabled = false;
            whiterb.simulated = false;
            whitesr.enabled = false;
            whitecontroller.enabled = false;
            whitetrail.enabled = false;

            blackrb.simulated = true;
            blackcol.enabled = true;
            blacksr.enabled = true;
            blackcontroller.enabled = true;
            blacktrail.enabled = true;
        }
        else if (blackcol.isActiveAndEnabled)
        {
            blackrb.simulated = false;
            blackcol.enabled = false;
            blacksr.enabled = false;
            blackcontroller.enabled = false;
            blacktrail.enabled = false;

            whitecol.enabled = true;
            whiterb.simulated = true;
            whitesr.enabled = true;
            whitecontroller.enabled = true;
            whitetrail.enabled = true;
        }
    }
}
