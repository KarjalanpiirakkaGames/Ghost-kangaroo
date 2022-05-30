using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarInIntroLevel : MonoBehaviour
{
    private Vector3 startPos;
    private AudioSource sounds;

    [SerializeField] private bool Plus;
    void Start()
    {
        sounds = GetComponent<AudioSource>();
        startPos = transform.position;
        StartCoroutine(update());
    }
    IEnumerator update()
    {
        while (true)
        {
            sounds.Stop();
            sounds.Play();
            for (int i = 0; i < 7; i++)
            {
                transform.position += new Vector3(1f, 0, 0);
           
                yield return new WaitForSeconds(0.01f);
            }
            transform.position = startPos;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
       
        Debug.Log("Hit");
        //loads new scene
        SceneManager.LoadScene("Intro2");
    }
}
