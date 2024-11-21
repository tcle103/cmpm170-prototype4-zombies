using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public const float PLAYER_SPEED = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // move
        parseWASD();
    }

    public void parseWASD()
    {
        float upDirection = 0.0f;
        float rightDirection = 0.0f;

        if (Input.GetKey(KeyCode.W)) upDirection++;
        if (Input.GetKey(KeyCode.S)) upDirection--;
        if (Input.GetKey(KeyCode.A)) rightDirection--;
        if (Input.GetKey(KeyCode.D)) rightDirection++;

        Vector3 direction = new Vector3(rightDirection, upDirection, 0.0f);
        direction.Normalize();
        moveSelf(direction);
        updateRotation(direction);
    }
    private void moveSelf(Vector3 direction)
    {
        this.transform.position += direction * Time.deltaTime * PLAYER_SPEED;
    }
    
    private void updateRotation(Vector3 direction)
    {
        if (direction.x == 0 && direction.y == 0)
        {
            // idle
        }
        else if (direction.x < 0)
        {
            if      (direction.y < 0)   this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 135.0f);
            else if (direction.y == 0)  this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 90.0f);
            else if (direction.y > 0)   this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 45.0f);
        }
        else if (direction.x == 0)
        {
            if      (direction.y < 0)   this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 180.0f);
            else if (direction.y > 0)   this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        }
        else if (direction.x > 0)
        {
            if      (direction.y < 0)   this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, -135.0f);
            else if (direction.y == 0)  this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, -90.0f);
            else if (direction.y > 0)   this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, -45.0f);
        }
    }

}
