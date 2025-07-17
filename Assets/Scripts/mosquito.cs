using UnityEngine;

public class MosquitoBug : MonoBehaviour
{
    void Update()
    {
        if (transform.position.y < -6f)
        {
            // اگر پشه از پایین صحنه بیفته → جون کم میشه
            if (GameManager.instance != null)
            {
                GameManager.instance.LoseLife();
            }

            // کم کردن قلب از HealthManager
            var healthManager = FindObjectOfType<HealthManager>(); 
            if (healthManager != null)
            {
                healthManager.TakeDamage();
            }

            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            Debug.Log("خورده شد");

            // اجرای انیمیشن دهان قورباغه
            var frogAnim = col.GetComponent<FrogAnimationController>();
            if (frogAnim != null)
            {
                frogAnim.EatMosquito();
            }

            // اضافه کردن امتیاز
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

            // کم کردن قلب از HealthManager
            var healthManager = FindObjectOfType<HealthManager>(); 
            if (healthManager != null)
            {
                healthManager.TakeDamage();
            }

            Destroy(gameObject);
        }
    }
}
