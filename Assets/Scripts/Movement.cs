using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.UI;
using UnityEngine.SceneManagement;


/*
 * Bryann Alfaro
 * Clase que controla el movimiento del jugaodr y sus colisiones
 * Referencia: Clase en linea
 */
public class Movement : MonoBehaviour
{

    private Rigidbody2D rgb2d;
    private int score=0;
    public Sprite mario2;
    BoxCollider2D box;
    public AudioClip powerUP;
    public AudioClip jumpSound;
    public AudioClip deathEnemy;
    public AudioClip marioDeath;

    // Start is called before the first frame update
    void Start()
    {
        
        rgb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        Vector3 newScale = transform.localScale;
        if (Input.GetAxis("Horizontal") < 0.0f)
        {
            newScale.x = -5.0f;
        }else if (Input.GetAxis("Horizontal") > 0.0f)
        {
            newScale.x = 5.0f;
        }

        transform.localScale = newScale;
    }

    private void FixedUpdate()
    {
        if (rgb2d)
        {
            rgb2d.AddForce(new Vector2(Input.GetAxis("Horizontal") * 5,0));
        }
    }

    //Al comer el power up
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PowerUp"))
        {
            score++;
            AudioSource audio = GetComponent<AudioSource>();
            audio.PlayOneShot(powerUP);
            Destroy(collision.gameObject);
            gameObject.GetComponent<SpriteRenderer>().sprite = mario2;
            box = GetComponent<BoxCollider2D>();
            box.size = new Vector2(0.14f, 0.3f);

        }
    }

    //Al chocar con el enemigo
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (score < 1)
            {
               
                Destroy(gameObject);
                
            }
            else
            {
                AudioSource audio = GetComponent<AudioSource>();
                audio.PlayOneShot(deathEnemy);
                Destroy(collision.gameObject);
            }
        }
    }

    //realizar salto
    void Jump()
    {
        if (rgb2d)
        {
            if (Mathf.Abs(rgb2d.velocity.y) < 0.05f)
            {
                AudioSource audio = GetComponent<AudioSource>();
                audio.PlayOneShot(jumpSound);
                rgb2d.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
            }
        }
    }

    
}
