using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 6;
    public float leftRightSpeed;

    Vector3 jump;
    public float jumpForce = 2.0f;
    public bool isGrounded;

    Rigidbody rb;
    public GameObject gameOverText;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        gameOverText.SetActive(false);
        FindObjectOfType<GameManager>().showGamePanel(false);
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("platform"))
        {
            isGrounded = true;
        }
    }
    private void LateUpdate()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
        //Move left
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            //if(this.gameObject.transform.position.x > -4.6f)
            //{
                transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed);
            //}
        }
        //Move right
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            //if (this.gameObject.transform.position.x < 4.6f)
            //{
                transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed * (-1));
            //}
        }
        //Jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
        //Restart
        if (rb.position.y < -1f)
        {
            gameOverText.SetActive(true);       
            this.gameObject.SetActive(false);
            FindObjectOfType<GameManager>().showGamePanel(true);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CoinSpeed")
        {
            moveSpeed = 15;
            StartCoroutine(timeSpeed());
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.tag == "Tree")
        {
            moveSpeed = 2;
            StartCoroutine(timeSpeed());
        }
        if (other.gameObject.tag == "Rock")
        {
            gameOverText.SetActive(true);
            this.gameObject.SetActive(false);
            FindObjectOfType<GameManager>().showGamePanel(true);         
        }
    }
    IEnumerator timeSpeed()
    {
        yield return new WaitForSeconds(0.8f);
        moveSpeed = 8;
    }
}
