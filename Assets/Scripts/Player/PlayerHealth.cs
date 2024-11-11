
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public GameObject timeGame;
    public GameObject scoreGame;
    public GameObject highestScoreGame;
    public int maxHealth = 100;
    public float currentHealth;
    public Slider healthSlider;
    public GameManager gameManager; // Thêm tham chiếu đến GameManager


    void Start()
    {
        currentHealth = maxHealth;
        healthSlider.maxValue = maxHealth;
        StartCoroutine(LogEveryFiveSeconds());
    }
    private bool isDead = false;
    private void Update()
    {
        if (isDead)
        {
            // Gọi hàm xử lý khi nhân vật chết từ ScoreManager
            ScoreManager.instance.OnPlayerDeath();
            // Đặt lại isDead để không gọi hàm nhiều lần
            isDead = false;
        }
        healthSlider.value = currentHealth;
    }
    IEnumerator LogEveryFiveSeconds()
    {
        while (true)
        {
            if (currentHealth < maxHealth)
            {
                currentHealth += 5;
                if (currentHealth > 100)
                {
                    currentHealth = maxHealth;
                }
            }
            yield return new WaitForSeconds(5);
        }
    }
        public void TakeDamage(int damage)
    {
        // Kiểm tra nếu máu đã hết
        if (currentHealth <= 0)
        {
            return;
        }

        currentHealth -= damage;
        healthSlider.value = currentHealth;

        // Kiểm tra nếu máu đã giảm xuống dưới 0
        if (currentHealth <= 0)
        {
            Die();
        }
   }
    

        void Die()
        {
            timeGame.SetActive(false);
            highestScoreGame.SetActive(false);
            scoreGame.SetActive(false);
            isDead = true;
            Debug.Log("Player has died.");

            gameManager.EndGame(); // Khi máu về 0, kích hoạt màn hình game over

        }

}
