using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    [SerializeField] private CanvasGroup LevelText;
    [SerializeField] private CanvasGroup LevelCompletedText;

    [SerializeField] private int level;

    private bool LevelCompleted = false;
    IEnumerator Start()
    {
        for (int i = 0; i < 10; i++)
        {
            LevelText.alpha += 0.1f;
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(0.9f);
        for (int i = 0; i < 10; i++)
        {
            LevelText.alpha -= 0.1f;
            yield return new WaitForSeconds(0.05f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<Player>().levelCompleted = true;

        StartCoroutine(levelCompleted());
    }
    private void Update()
    {

        if (LevelCompleted && Input.GetKeyDown(KeyCode.Space))
        {

            //loads next level
            if (level == 1)
            {
                SceneManager.LoadScene("Level2");
            }
            if (level == 2)
            {
                SceneManager.LoadScene("Level3");
            }
            if (level == 3)
            {
                SceneManager.LoadScene("Level4");
            }
            if (level == 4)
            {
                SceneManager.LoadScene("Level5");
            }
            if (level == 5)
            {
                SceneManager.LoadScene("Level6");
            }
            if (level == 6)
            {
                SceneManager.LoadScene("Outro");
            }
        }
    }
    IEnumerator levelCompleted()
    {
        for (int i = 0; i < 10; i++)
        {
            LevelCompletedText.alpha += 0.1f;
            yield return new WaitForSeconds(0.05f);
        }
        LevelCompleted = true;
    }
}
