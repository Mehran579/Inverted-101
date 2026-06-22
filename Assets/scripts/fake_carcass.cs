using UnityEngine;

public class fake_carcass : MonoBehaviour
{
    public GameObject finalboss;
    private void Start()
    {
        finalboss.SetActive(false);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Invoke(nameof(activateboss),1f);
    }
    void activateboss()
    {
        finalboss.SetActive(true);
    }
}
