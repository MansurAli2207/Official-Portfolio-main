using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class Bullet : MonoBehaviour
{

    [SerializeField] private GameObject floatingTextPrefab;
    public float damage = 50;
    public int maxHits = 2;
    private int hitCount = 0;
    

    /*private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.CompareTag("Enemy"))
        {
            hitCount++;
            if (hitCount >= maxHits)
            {
                Destroy(hitInfo.gameObject);
            }
          //Destroy(gameObject);
        }
    }*/

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.CompareTag("Enemy"))
        {
            showDamage(damage.ToString());
            hitCount++;
            if (hitCount >= maxHits)
            {
                Destroy(hitInfo.gameObject);
            }
      
          
           
           
        }
        else if (hitInfo.gameObject.CompareTag("Walls"))
        {
            Destroy(gameObject);
        }


    }

    void showDamage(string text)
    {
          if(floatingTextPrefab)
          {
            GameObject prefab = Instantiate(floatingTextPrefab,transform.position,Quaternion.identity);
            prefab.GetComponentInChildren<TextMesh>().text = text;
          }      
    }

   
}



