using UnityEngine;
using System.Collections;

public class TitleScreenSwitch : MonoBehaviour
{
    public Sprite[] sprites;
    public int index = 0;

    void Start()
    {
        StartCoroutine(SwitchSprites());
    }

    IEnumerator SwitchSprites()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();

        while (true)
        {
            yield return new WaitForSeconds(5f);

            index++;

            // loop back to start so it doesn't crash
            if (index >= sprites.Length)
                index = 0;

            sr.sprite = sprites[index];
        }
    }
}