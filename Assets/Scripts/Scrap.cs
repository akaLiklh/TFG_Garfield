using UnityEngine;

public class Scrap : MonoBehaviour
{
    private Animator animator;
    private Collider2D col;
    private bool collected;
    public int value = 1;
    public GameManager GameManager;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        col = GetComponent<Collider2D>();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (collected || !other.CompareTag("Player")) return;

        collected = true;
        col.enabled = false;
        animator.SetTrigger("Collect");
        Debug.Log("Chatarra recogida");
    }
    public void OnCollectFinished()
    {
        GameManager.AddPoints(value);
        Destroy(gameObject);
    }
}


