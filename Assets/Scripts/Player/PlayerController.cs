using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;

    private Vector3 direction = Vector3.right;

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
    && direction != Vector3.down)
        {
            direction = Vector3.up;
        }

        if ((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            && direction != Vector3.up)
        {
            direction = Vector3.down;
        }

        if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            && direction != Vector3.right)
        {
            direction = Vector3.left;
        }

        if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            && direction != Vector3.left)
        {
            direction = Vector3.right;
        }

        transform.position += direction * speed * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
    }
}