using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SwipeController : MonoBehaviour
{
    public GameObject scrollbar;
    float scroll_pos = 0;
    float[] pos;


    private void Update()
    {
        StartCoroutine(ScrollFunction());
    }

    IEnumerator ScrollFunction()
    {
        pos = new float[transform.childCount];
        float distance = 1f / (pos.Length - 1f);

        for (int i = 0; i < pos.Length; i++)
        {
            pos[i] = distance * i;
        }

        if (Input.GetMouseButton(0))
        {
            scroll_pos = scrollbar.GetComponent<Scrollbar>().value;
        }
        else
        {
            for (int i = 0; i < pos.Length; i++)
            {
                if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
                {
                    scrollbar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollbar.GetComponent<Scrollbar>().value, pos[i], 0.1f);
                }
            }
        }

        for (int i = 0; i < pos.Length; i++)
        {
            if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
            {
                // MoveTowards ensures it reaches exactly 1f
                transform.GetChild(i).localScale = Vector2.MoveTowards(transform.GetChild(i).localScale, new Vector2(1f, 1f), Time.deltaTime * 5f);

                for (int a = 0; a < pos.Length; a++)
                {
                    if (a != i)
                    {
                        transform.GetChild(a).localScale = Vector2.MoveTowards(transform.GetChild(a).localScale, new Vector2(0.8f, 0.8f), Time.deltaTime * 5f);
                    }
                }
            }
        }

        yield return null;

    }
}

