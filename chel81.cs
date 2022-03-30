using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class chel81 : MonoBehaviour
{
    Rigidbody rb;
    Transform transf;
    float vertical;
    float horizontal;
    float jumpForce = 10f;
    bool isGrounded = false;
    
    [SerializeField] TextMeshProUGUI CoinText;
    static int Coin = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        transf = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
       vertical = Input.GetAxis("Vertical");
       horizontal = Input.GetAxis("Horizontal");

       rb.AddRelativeForce(0,0, vertical * 5f);
       transf.Rotate(0, horizontal, 0);

       if(Input.GetKeyDown("space") && isGrounded == true){
           rb.drag = 2f;
           rb.angularDrag = 2f;
           rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
       }
    }

    void OnCollisionEnter(Collision col){
        if(col.gameObject.tag == "ground"){
            isGrounded = true;
        }
        if(col.gameObject.tag == "good"){
            Destroy(col.gameObject);
            Coin = Coin + 1;
            CoinText.text = Coin + "";
        }
    }

    void OnCollisionExit(Collision col){
        if(col.gameObject.tag == "ground"){
            isGrounded = false;
        }
    }
}
