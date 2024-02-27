using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEffect : MonoBehaviour
{
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] Rigidbody2D playerBody;
    private Rigidbody2D body;
    private Transform transform;
    
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        transform = GetComponent<Transform>();
    }
    void Update()
    {
        moveEffect();
    }

    private void moveEffect()
    {
        List<float> inputHistory = playerMovement.getInputHistory();
        float deltaX = 0;
        try
        {
            deltaX = inputHistory[0];
            Vector2 movement = new Vector2(deltaX, body.velocity.y);
            body.velocity = movement;
            playerMovement.RemoveMostRecentInputValue();

            if (playerBody.velocity == Vector2.zero)
            {
                Debug.Log("I ran");
                body.velocity = new Vector2(0, 0);
                transform.position = Vector2.MoveTowards(transform.position, playerMovement.getTransform().position, playerMovement.getSpeed() * Time.deltaTime);
            }

            
        }
        catch
        {

        }
    }

    
}
