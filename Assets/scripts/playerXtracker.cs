using UnityEngine;

public class playerXtracker : MonoBehaviour
{
    public GameObject WhitePlayer;
    public GameObject BlackPlayer;
    public bossfightscript bossfightscript;
    public Transform newcamerapos;
    public Transform othernewcamerpos;
    public finalfight finalfight;
    private void FixedUpdate()
    {
        if (bossfightscript.fightstarting)
        {
            transform.position = newcamerapos.position;
            return;
        }
        if (finalfight.debuggcoming)
        {
            transform.position = othernewcamerpos.position;
            return;
        }
        if (WhitePlayer.GetComponent<Collider2D>().enabled)
        {
            transform.position = new Vector2(WhitePlayer.transform.position.x, 0);
        }
        if (BlackPlayer.GetComponent<Collider2D>().enabled) 
        {
            transform.position = new Vector2(BlackPlayer.transform.position.x, 0);
        }

    }
}
