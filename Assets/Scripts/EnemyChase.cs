using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    private int hitCount = 0;
    // public GameObject FloatingText;

    public GameObject player;
    public Animator animator;
    public float speed;
    private float distance;
    //  public GameObject destroyEffect;
    public ScoreText scoreManager;

    public AudioSource source;

    public AudioClip clip;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        scoreManager = GameObject.FindObjectOfType<ScoreText>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Fly", speed);
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if (!GetComponent<Collider2D>().IsTouching(player.GetComponent<Collider2D>()))
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        }

    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            hitCount++;

            if (hitCount == 1)
            {
                //  GameObject floatingText = Instantiate(FloatingText, transform.position, transform.rotation);
                ParticleSystem[] particleSystems = GetComponentsInChildren<ParticleSystem>();

                // Play all ParticleSystems
                foreach (ParticleSystem damageEffect in particleSystems)
                {
                    damageEffect.Play();
                }

            }

            if (hitCount >= 2)
            {

                ParticleSystem[] particleSystems = GetComponentsInChildren<ParticleSystem>();

                // Play all ParticleSystems
                foreach (ParticleSystem damageEffect in particleSystems)
                {
                    damageEffect.Play();
                }
                source.clip= clip;
                source.Play();

                scoreManager.AddScore(1);

                // Start fading out and destroying the GameObject
                StartCoroutine(FadeAndDestroy());

            }


        }
    }

    private IEnumerator FadeAndDestroy()
    {
        // Disable all colliders on this object
        Collider2D[] colliders = GetComponentsInChildren<Collider2D>();
        foreach (Collider2D collider in colliders)
        {
            collider.enabled = false;
        }

        Renderer[] renderers = GetComponentsInChildren<Renderer>();
        float duration = 0.5f;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(0.3f, 0f, elapsedTime / duration);

            foreach (Renderer renderer in renderers)
            {
                if (renderer.material.HasProperty("_Color"))
                {
                    Color color = renderer.material.color;
                    color.a = alpha;
                    renderer.material.color = color;
                }
            }

            yield return null;
        }

        Destroy(gameObject);
    }
}
