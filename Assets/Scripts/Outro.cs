using System.Collections;
using TMPro;
using UnityEngine;

public class Outro : MonoBehaviour
{
    [SerializeField] private TMP_Text Text;
    [SerializeField] private string FullText;
    private string CurrentText;

    [SerializeField] private TMP_Text Text2;
    [SerializeField] private string FullText2;
    private string CurrentText2;

    [SerializeField] private Transform kangoroo;

    private bool canContinue = false;
    void Start()
    {
        Text.text = "";
        Text2.text = "";

        StartCoroutine(text());
        StartCoroutine(KangRot());
    }
    IEnumerator KangRot()
    {
        //Rotates kangoroo
        while (true)
        {
            kangoroo.rotation = Quaternion.Euler(0, kangoroo.rotation.eulerAngles.y + 1.5f, 0);
            yield return new WaitForSeconds(0.06f);
        }
    }
    private void Update()
    {
        if (canContinue && Input.GetKeyDown(KeyCode.Space))
        {
            //quit game
            Application.Quit();
        }
    }
    IEnumerator text()
    {
        //shows the text
        for (int i = 0; i <= FullText.Length; i++)
        {
            yield return new WaitForSeconds(0.12f);
            CurrentText = FullText.Substring(0, i);
            Text.text = CurrentText;
            GetComponent<AudioSource>().Play();
        }
        yield return new WaitForSeconds(1);
        for (int i = 0; i <= FullText2.Length; i++)
        {
            yield return new WaitForSeconds(0.12f);
            CurrentText2 = FullText2.Substring(0, i);
            Text2.text = CurrentText2;
            GetComponent<AudioSource>().Play();
        }
        canContinue = true;
    }
}
