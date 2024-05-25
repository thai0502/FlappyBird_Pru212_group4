using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdControl : MonoBehaviour
{
    public float flyPower = 15f;
    public AudioClip flyClip;
    public AudioClip gameOverClip;

    public AudioSource audioSource;

    GameObject obj;
    GameObject gameController;
    private Animator anim;
    void Start()
    {
        obj = gameObject;
        audioSource = obj.GetComponent<AudioSource>();
        audioSource.clip = flyClip;
        anim = obj.GetComponent<Animator>();
        anim.SetFloat("flyPower",0);
        anim.SetBool("isDead",false);

        if(gameController == null)
        {
            Debug.LogError("GameController not found. Make sure it is tagged correctly.");
            gameController = GameObject.FindGameObjectWithTag("GameController");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (!gameController.GetComponent<GameController>().isEndGame)
            {
                audioSource.Play();
                obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, flyPower), ForceMode2D.Impulse);
            }
        }
        anim.SetFloat("flyPower", obj.GetComponent<Rigidbody2D>().velocity.y);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        EndGame();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (gameController != null)
        {
            gameController.GetComponent<GameController>().GetPoint();
        }
    }
    void EndGame()
    {
        anim.SetBool("isDead",true);
        audioSource.clip = gameOverClip;
        audioSource.Play();

        gameController.GetComponent<GameController>().EndGame();
    }
}
