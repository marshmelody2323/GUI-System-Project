using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public float sprintSpeed = 10f;
    private float movementSpeed;

    // Start is called before the first frame update
    void Start()
    {
        movementSpeed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * movementSpeed;



        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            movementSpeed = sprintSpeed;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            movementSpeed = moveSpeed;
        }
    }



    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }


}