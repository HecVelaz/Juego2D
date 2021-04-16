using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    public GameManager gameManager;
    public float fuerzaSalto;
    private Rigidbody2D rigibody2D;
    private Animator animator;
    
  
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigibody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        { 
                animator.SetBool("estaSaltando",true);
            rigibody2D.AddForce(new Vector2(0, fuerzaSalto));
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Suelo")
        {
            animator.SetBool("estaSaltando", false);//se activa animacion de correr
        }
        if (collision.gameObject.tag == "Obstaculo")
        {
            gameManager.gameOver = true;
        }
    }
}
