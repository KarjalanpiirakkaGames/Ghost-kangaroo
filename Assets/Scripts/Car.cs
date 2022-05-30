using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    private Vector3 startPos;
    private AudioSource sounds;

    [SerializeField] private bool startWithOutWaiting;
    [SerializeField] private bool Plus;
    IEnumerator Start()
    {
        sounds = GetComponent<AudioSource>();
        startPos = transform.position;
        if (!startWithOutWaiting)
        { yield return new WaitForSeconds(Random.Range(0.1f, 4.2f)); }
        StartCoroutine(update());
    }
    IEnumerator update()
    {
        while (true)
        {
            sounds.Stop();
            sounds.Play();
            for (int i = 0; i < 40; i++)
            {
                if (!Plus)
                {
                    transform.position -= new Vector3(0.3f, 0, 0);
                }
                else
                { 
                    transform.position += new Vector3(0.3f, 0, 0);
                }
                yield return new WaitForSeconds(0.04f);
            }
            transform.position = startPos;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit");
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(other.GetComponent<Player>().dead());
        }
    }
}
