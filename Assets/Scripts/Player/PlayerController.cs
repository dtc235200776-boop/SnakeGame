using UnityEngine;
using System.Collections.Generic;
public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public List<Transform> snakeBody = new List<Transform>();

    public GameObject snakeBodyPrefab;

    private Vector3 direction = Vector3.right;

    void Update()
    {
        Vector3 previousPosition = transform.position;
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
        if (snakeBody.Count > 0)
        {
            Vector3 currentPosition = previousPosition;

            for (int i = 0; i < snakeBody.Count; i++)
            {
                Vector3 temp = snakeBody[i].position;
                snakeBody[i].position = currentPosition;
                currentPosition = temp;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        int randomX = Random.Range(-10, 10);
        int randomY = Random.Range(-1, 3);
        other.transform.position = new Vector3(randomX, randomY, 0);
        GameManager.Instance.AddScore();
        GameObject body = Instantiate(snakeBodyPrefab);
        body.transform.position = transform.position;
        snakeBody.Add(body.transform);
    }
    
}