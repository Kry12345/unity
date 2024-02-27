using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private List<float> inputHistory = new List<float>();

    private float speed = 4.5f;
    
    private Rigidbody2D body;

    private Transform transform;

    public float getSpeed()
    {
        return speed;
    }

    

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        transform = GetComponent<Transform>();
    }

    public Transform getTransform()
    {
        return transform;
    }

    public List<float> getInputHistory()
    {
        return inputHistory;
    }

    public void RemoveMostRecentInputValue()
    {
        inputHistory.RemoveAt(0);
    }

    // Update is called once per frame
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        Vector2 movement = new Vector2(deltaX, body.velocity.y);
        body.velocity = movement;
        StartCoroutine(addToInputHistory(deltaX));
    }

    IEnumerator addToInputHistory(float x)
    {
        yield return new WaitForSeconds(0.03f);
        inputHistory.Add(x);
    }
}
