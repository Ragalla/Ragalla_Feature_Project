using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    public float speedUp;
    public float jumpForce = 5;
    private float horizontalInput;
    public float forwardInput;
    private Rigidbody playerRB;
    public bool isOnGround = true;
    public bool isMoving = false;
    //public float rotationSpeed;

    [SerializeField] private float chargeJumpForce;
    [SerializeField] private float chargeJumpSpeed;
    [SerializeField] private float chargeJumpTime;
    [SerializeField] private float hoverJumpForce;
    private bool isChargingJump;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        movementDirection.Normalize();

        transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }

        if (movementDirection != Vector3.zero)
        {
            //Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            //transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            transform.forward = movementDirection;
        }
        ChargeJump();
        SpeedBoost();
        Hover();
    }

    private void OnCollisionEnter(Collision collision)
    {
        isOnGround = true;
    }

    void ChargeJump()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            chargeJumpTime = 0;
        }
        if (Input.GetKey(KeyCode.J) && chargeJumpTime < 5 && isOnGround == true)
        {
            isChargingJump = true;
            if(isChargingJump == true)
            {
                chargeJumpTime += Time.deltaTime * chargeJumpSpeed;
            }
            
        }
        else if(Input.GetKeyUp(KeyCode.J) && chargeJumpTime >= 3)
            {
                playerRB.velocity = Vector3.up * chargeJumpForce;
                isChargingJump = false;
                chargeJumpTime = 0;
            }
    }

    void SpeedBoost()
    {
        if(Input.GetKeyDown("k"))
        {
            isMoving = true;
        }

        if(Input.GetKeyUp("k"))
        {
            isMoving = false;
        }

        if(Input.GetKey(KeyCode.K) & isMoving == true)
        {
            transform.position += transform.forward * Time.deltaTime * speedUp;
        }
    }

    void Hover()
    {
        if(Input.GetKeyDown("l"))
        {
            isOnGround = false;
        }

        if(Input.GetKeyUp("l"))
        {
            isOnGround = true;
        }
 
        if (Input.GetKey(KeyCode.L) & isOnGround == false)
        {
            GetComponent<Rigidbody>().drag =12;
            if (Input.GetKeyDown("l"))
            {
                playerRB.velocity = Vector3.up * hoverJumpForce;
            }
            
        }
        else
        {
            GetComponent<Rigidbody>().drag =0;
        }
        
    }
}
