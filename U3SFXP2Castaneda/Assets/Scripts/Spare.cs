using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spare : MonoBehaviour
{
    private AudioSource playerAudio;
    private Rigidbody playerRb;
    private Animator playerAnim;
    public ParticleSystem dirtParticle;
    public ParticleSystem explosionParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    public float gravityModifier;
    public float jumpForce;
    public bool isOnGround = true;
    public bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;

            playerAnim.SetTrigger("Jump_trig");

            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);


        }




    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over!");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }


    }
}

