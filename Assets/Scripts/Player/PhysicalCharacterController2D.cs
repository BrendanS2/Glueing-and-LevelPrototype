using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class PhysicalCharacterController2D : MonoBehaviour
{

    public float moveSpeed;
    public float drag = 6f;
    public float moveMultiplier = 10f;
    public SpriteRenderer color;
    private float timer;
    bool canGetHit;

    private Vector2 _moveDirection = Vector2.zero;
    private Rigidbody2D _rb;

    private float _v = 0f;
    private float _h = 0f;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        timer = Time.deltaTime;
        canGetHit = true;
    }

    void Update()
    {
        _h = Input.GetAxisRaw("Horizontal");
        _v = Input.GetAxisRaw("Vertical");
        _moveDirection = transform.up * _v + transform.right * _h;

        _rb.drag = drag;

        var flatVelocity = new Vector2(_rb.velocity.x, _rb.velocity.y);
        if (flatVelocity.magnitude <= moveSpeed)
            return;
        var limitVelocity = flatVelocity.normalized * moveSpeed;
        _rb.velocity = new Vector2(limitVelocity.x, limitVelocity.y);
        
    }

    void FixedUpdate()
    {
        _rb.AddForce(_moveDirection.normalized * (moveSpeed * moveMultiplier), ForceMode2D.Force);
    }
    public void Glued()
    {


        if (canGetHit == true)
        {
            StartCoroutine("Change");
        }
            color.color = Color.yellow;



        

    }

    IEnumerator Change()
    {
        canGetHit = false;
        Color orginColor = color.color;
        color.color = Color.yellow;
        moveSpeed = 1f;
        yield return new WaitForSeconds(1f);
        color.color = orginColor;
        moveSpeed = 5f;
        canGetHit = true;
    }

    
}