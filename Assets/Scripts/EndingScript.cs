using UnityEngine;
using System.Collections;

public class EndingScript : MonoBehaviour
{
    public GameObject[] sprites;
    public float delayBetween = 5f;
    public float fadeSpeed = 2f;
    public float endWait = 5f;
    public AudioClip successSound;
    public AudioSource audioSource;

    public GameObject Canvas;

    void Start()
    {
        if (audioSource != null && successSound != null)
            audioSource.PlayOneShot(successSound);
        StartCoroutine(SwitchSprites());
        Canvas.SetActive(false);
    }

    IEnumerator SwitchSprites()
    {
        
        for (int i = 0; i < sprites.Length; i++)
        {
            GameObject obj = sprites[i];
            SpriteRenderer sr = obj.GetComponent<SpriteRenderer>();

            Color c = sr.color;
            c.a = 0f;
            sr.color = c;

            obj.SetActive(true);

            while (sr.color.a < 1f)
            {
                c.a += Time.deltaTime * fadeSpeed;
                sr.color = c;
                yield return null;
            }

            c.a = 1f;
            sr.color = c;

            yield return new WaitForSeconds(delayBetween);
        }

        
        yield return new WaitForSeconds(endWait);

       
        bool fading = true;

        while (fading)
        {
            fading = false;

            for (int i = 0; i < 4 && i < sprites.Length; i++)
            {
                SpriteRenderer sr = sprites[i].GetComponent<SpriteRenderer>();
                Color c = sr.color;

                if (c.a > 0f)
                {
                    c.a -= Time.deltaTime * fadeSpeed;
                    c.a = Mathf.Clamp01(c.a);
                    sr.color = c;

                    if (c.a > 0f)
                     fading = true;
                     Canvas.SetActive(true);
                }
            }

            yield return null;
        }
    }
}
