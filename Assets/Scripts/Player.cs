using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private bool canMove = false;
    private Vector3 startPos;
    private AudioSource jumpSound;

    private bool isdead = false;

    [SerializeField] private CanvasGroup respawnText;

    public bool levelCompleted = false;

    private int timesDead = 0;
    private void Start()
    {
        startPos = transform.position;
        jumpSound = GetComponent<AudioSource>();
        StartCoroutine(waitToAgain());
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canMove == true && !isdead)
        {
            canMove = false;
            StartCoroutine(Move());
            StartCoroutine(waitToAgain());
        }
    }
    private IEnumerator waitToAgain()
    {
        yield return new WaitForSeconds(0.2f);
        canMove = true;
    }
    public IEnumerator dead()
    {
        isdead = true;
        transform.position = startPos;
        StartCoroutine(RespawnTextNumerator());
        yield return new WaitForSeconds(1);
        transform.position = startPos;
        isdead = false;
        timesDead++;
        if (timesDead == 7)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    private IEnumerator RespawnTextNumerator()
    {
        for (int i = 0; i < 10; i++)
        {
            respawnText.alpha += 0.1f;
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(3);
        for (int i = 0; i < 10; i++)
        {
            respawnText.alpha -= 0.1f;
            yield return new WaitForSeconds(0.05f);
        }
    }
    private IEnumerator Move()
    {
        //dont ask about this movement system
        Vector3 pos = transform.position;
        float a = 0;
        if (!levelCompleted && !isdead)
        { 
            jumpSound.Play();
        }
        for (int i = 0; i < 3; i++)
        {
            if (!isdead && !levelCompleted)
            {
                yield return new WaitForSeconds(0.01f);
                transform.position += new Vector3(0, 0, 0.2f);
                a += 0.2f;
            }
            else
            {
                StopCoroutine(Move());
            }
            Debug.Log(a);
        }
        if (!isdead && !levelCompleted)
        {
            transform.position += new Vector3(0, 0, 0.1f);
            a += 0.1f;
            a -= 0.017f;
        }
        else
        {
            StopCoroutine(Move());
        }
        transform.position = new Vector3(pos.x, pos.y, pos.z + a);
        //it works so it is fine
    }
   
}
