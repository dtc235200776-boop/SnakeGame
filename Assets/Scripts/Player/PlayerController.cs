using UnityEngine;
using System.Collections.Generic;
public class PlayerController : MonoBehaviour
{
    public float speed = 5f;

    public List<Transform> SnakeBody = new List<Transform>();

    public GameObject SnakeBodyPrefab;

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

        int randomX = Random.Range(-10, 10);
        int randomY = Random.Range(-1, 3);
        other.transform.position = new Vector3(randomX, randomY, 0);
        GameObject body = Instantiate(SnakeBodyPrefab);
        body.transform.position = transform.position;
        SnakeBody.Add(body.transform);
    }
    
}