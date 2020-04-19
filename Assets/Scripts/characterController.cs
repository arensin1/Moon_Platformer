using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

public class characterController : MonoBehaviour
{
    public Rigidbody2D ourRigidbody; //rigid body used for player physics
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f; //smoothing rate

                       // A mask determining what is ground to the character
    [SerializeField] private Transform m_GroundCheck;                           // A position marking where to check if the player is grounded.
    [SerializeField] private Transform m_CeilingCheck;
    public bool obj_complete = false;
    private float m_JumpForce = 400f; //jump force
    private bool m_Grounded = false;  //boolean if character is grounded
    private Vector3 m_Velocity = Vector3.zero; //setting velocity to zero
    Collision2D collision; 
    
    public bool clue_collect = false; //check if clue is found
    public GameController gameController;
    private bool m_FacingRight = true;  // For determining which way the player is currently facing.
    public UnityEvent OnLandEvent;
    public Animator animator_UI;
    public player Sam;
    private float waitTime = 5f;
    private void Awake()
    {
        ourRigidbody = GetComponent<Rigidbody2D>();
        //getting component for our rigid body
        if (OnLandEvent == null)
            OnLandEvent = new UnityEvent();

    }


    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if we collide with the ground set grounded to true
        if(collision.collider.tag == "Ground")
        {
            m_Grounded = true;
            OnLandEvent.Invoke();
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        //when we interact with the datalog, the datalog will dissapear and we'll find the clue
            if (other.gameObject.CompareTag ("Datalog"))
            {
                other.gameObject.SetActive(false);
                clue_collect = true;
                animator_UI.SetBool("Datalog", true);
                other.gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
            }
            else if (other.gameObject.CompareTag("objective"))
            {   
                obj_complete = true;
                animator_UI.SetBool("Objective", true);
                other.gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
                
            }
        }
    
    public void Move(float move, bool jump)
    {
            //check the win and lose situation
            gameController.winSituation();
            gameController.loseSituation();

            //setting up horizontal movement
            Vector3 targetVelocity = new Vector2(move * 10f, ourRigidbody.velocity.y);

            ourRigidbody.velocity = Vector3.SmoothDamp(ourRigidbody.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

            // If the input is moving the player right and the player is facing left...
            if (move > 0 && !m_FacingRight)
            {
                // ... flip the player.
                Flip();
            }
            // Otherwise if the input is moving the player left and the player is facing right...
            else if (move < 0 && m_FacingRight)
            {
                // ... flip the player.
                Flip();
            }

            // If the player should jump...
            if (m_Grounded && jump)
            {
                // Add a vertical force to the player.
                m_Grounded = false;


                ourRigidbody.AddForce(new Vector2(0f, m_JumpForce));
            }
    }

    private void Flip()
    {
            // Switch the way the player is labelled as facing.
            m_FacingRight = !m_FacingRight;

            // Multiply the player's x local scale by -1.
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
    }
}
