using UnityEngine;

public class PlayerFreeze : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        FindObjectOfType<Player>().GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
    }
}
