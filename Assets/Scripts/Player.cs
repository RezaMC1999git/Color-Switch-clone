using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public bool isStarted = false;
    public float jumpForce = 10f;
    public string currentColor;
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public Color colorCyan;
    public Color colorYellow;
    public Color colorMagenta;
    public Color colorPink;
    private void Start()
    {
        rb.gravityScale = 0f;
        SetRandomColor();
    }
    private void Update()
    {
        if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
        {
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            rb.gravityScale = 3f;
            rb.velocity = Vector2.up * jumpForce;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "ColorChanger")
        {
            SetRandomColor();
            Destroy(other.gameObject);
            return;
        }
        if(other.tag != currentColor)
        {
            SceneManager.LoadScene(0);
        }
    }
    void SetRandomColor()
    {
        int index = Random.Range(0, 4);
        switch (index)
        {
            case 0:
                if (currentColor != "Cyan")
                {
                    currentColor = "Cyan";
                    sr.color = colorCyan;
                }
                else
                {
                    currentColor = "Yellow";
                    sr.color = colorYellow;
                }
                break;
            case 1:
                if (currentColor != "Yellow")
                {
                    currentColor = "Yellow";
                    sr.color = colorYellow;
                }
                else
                {
                    currentColor = "Cyan";
                    sr.color = colorCyan;
                }
                break;
            case 2:
                if (currentColor != "Magenta")
                {
                    currentColor = "Magenta";
                    sr.color = colorMagenta;
                }
                else
                {
                    currentColor = "Pink";
                    sr.color = colorPink;
                }
                break;
            case 3:
                if (currentColor != "Pink")
                {
                    currentColor = "Pink";
                    sr.color = colorPink;
                }
                else
                {
                    currentColor = "Magenta";
                    sr.color = colorMagenta;
                }
                break;
        }
    }
}
