using System.Collections;
using System.Collections.Generic;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public Image healthBar;
    [SerializeField] float damage = 20;
    [SerializeField] Color fullHealthColor = Color.green;
    [SerializeField] Color lowHealthColor = Color.red;
    [SerializeField] Color midHealthColor = Color.yellow;
    [SerializeField] float lowHealthThreshold = 0.4f;
    [SerializeField] float midHealthThreshold = 0.8f;



    public GameObject ReStartPanel;

    public GameObject player;

    public GameObject Enemy;

    void Start()
    {
        maxHealth = health;
        UpdateHealthBarColor();
    }

    void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);
        UpdateHealthBarColor();

        // Check if health is zero
        if (health <= 0)
        {
            GameOver();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            health -= damage;
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            float damagePerSecond = damage / 5f;
            health -= damagePerSecond * Time.deltaTime;
        }
    }

    void UpdateHealthBarColor()
    {
        if (health / maxHealth > midHealthThreshold)
        {
            healthBar.color = fullHealthColor;
        }
        else if (health / maxHealth > lowHealthThreshold)
        {
            healthBar.color = midHealthColor;
        }
        else
        {
            healthBar.color = lowHealthColor;
        }
    }

    public void GameOver()
    {
        Debug.Log("Game Over!");
        ReStartPanel.SetActive(true);
        if (player != null)
        {
            player.SetActive(false);
        }

        if (Enemy != null)
        {
            Enemy.SetActive(false);
        }


        // You can add additional logic here, such as:
        // - Triggering a Game Over screen
        // - Restarting the level
        // - Disabling player movement, etc.
    }
}
