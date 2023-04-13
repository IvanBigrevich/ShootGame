using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float fuerzaSalto;
    public Rigidbody rigid;
    // public BoxCollider col;
    // public CapsuleCollider col2;
    public Keyboard controlls;
    private bool onFloor = false;
    public bool isDead = false;
    private Animator anim;
    private bool pauseActive;
    // public GameObject deadMenu;
    public float cooldown = 200f;

    void Start()
    {
        isDead = false;
        rigid = GetComponent<Rigidbody>();
        // col.GetComponent<BoxCollider>();
        // col2.GetComponent<CapsuleCollider>();
        controlls = Keyboard.current;
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if(onFloor)
        {
            Jump();
        }
    }

    void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.tag == "Suelo" && !onFloor)
        {
            onFloor = true;
            rigid.velocity = new Vector3(rigid.velocity.x, 0, rigid.velocity.z);
        }
    }

    void Jump()
    {
        if(controlls.upArrowKey.isPressed && !controlls.downArrowKey.isPressed)
        {
            rigid.AddForce(new Vector3(0, fuerzaSalto, 0));
            onFloor = false;
        }
    }
}