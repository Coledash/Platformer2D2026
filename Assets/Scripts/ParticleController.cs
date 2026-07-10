using UnityEngine;

public class ParticleController : MonoBehaviour
{
    public ParticleSystem movementParticle;
    
    [Range(0, 10)]
    public int occurAfterVelocity;

    [Range(0, 0.2f)]
    public float dustFormationPeriod;

    public Rigidbody2D rb;

    float counter;
    bool isGrounded;

    private void Update()
    {
        counter += Time.deltaTime;

        if(isGrounded && Mathf.Abs(rb.linearVelocityX) > occurAfterVelocity)
        {
            if(counter > dustFormationPeriod)
            {
                movementParticle.Play();
                counter = 0;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
