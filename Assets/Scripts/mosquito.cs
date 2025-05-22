using UnityEngine;

public class MosquitoBug : MonoBehaviour
{
    void Update()
    {
        if (transform.position.y < -6f)
        {
            if (GameManager.instance != null)
            {
                GameManager.instance.LoseLife();
            }
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            Debug.Log("خورده شد");
            if (GameManager.instance != null)
            {
                GameManager.instance.AddScore(1);
            }
            Destroy(gameObject);
        }
        else if (col.tag == "Ground")
        {
            Debug.Log("افتاد زمین");
            if (GameManager.instance != null)
            {
                GameManager.instance.LoseLife();
            }
            Destroy(gameObject);
        }
    }
}
