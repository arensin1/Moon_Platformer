using UnityEngine;
using UnityEngine.Events;


public class characterController : MonoBehaviour
{
     public Rigidbody2D ourRigidbody;
     [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f; 
     private float m_JumpForce = 400f; 
     private bool m_Grounded = false;  
     private Vector3 m_Velocity = Vector3.zero;
     Collision2D collision;
     public bool obj_Complete = false;
     public GameController gameController;
   


    private void Awake()
    {
        ourRigidbody = GetComponent<Rigidbody2D>();

    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground")
        {
            m_Grounded = true;
        
        }
    }

    void OnTriggerEnter2D(Collider2D other){
            if (other.gameObject.CompareTag ("Flower"))
            {
                other.gameObject.SetActive(false);
                obj_Complete = true;
            }
        }
    public void Move(float move, bool jump)
    {
        //check the win and lose situation
        gameController.winSituation();
        gameController.loseSituation();
        
        Vector3 targetVelocity = new Vector2(move * 10f, ourRigidbody.velocity.y);
       
        ourRigidbody.velocity = Vector3.SmoothDamp(ourRigidbody.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

     
        // If the player should jump...
        if (m_Grounded && jump)
        {
            // Add a vertical force to the player.
            m_Grounded = false;


            ourRigidbody.AddForce(new Vector2(0f, m_JumpForce));
        }
    }


}
