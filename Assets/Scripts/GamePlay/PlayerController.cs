using System.Collections;
using System.Collections.Generic;
using JumpFrog;
using UnityEngine;

public class PlayerController : Singleton<PlayerController>
{
    public Rigidbody2D Rigidbody2D;
    private bool play;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void Play()
    {
        play = true;
    }

    public float speed = 2;

    public GameObject act;

    

    public bool onButton;
    Vector3 offset;
    Vector3 mousePosition;
    public float maxSpeed = 10;
    Vector2 mouseForce;
    Vector3 lastPosition;

    void Update()
    {
        if (play && GameManager.Instance.currentState == State.Playing)
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (onButton)
            {
                mouseForce = (mousePosition - lastPosition) / Time.deltaTime;
                mouseForce = Vector2.ClampMagnitude(mouseForce, maxSpeed);
                lastPosition = mousePosition;
            }

            if (Input.GetMouseButtonDown(0))
            {
                onButton = true;
                offset = transform.position - mousePosition;
            }

            if (Input.GetMouseButtonUp(0) && onButton)
            {
                Rigidbody2D.velocity = Vector2.zero;
                onButton = false;
            }
        }
    }
    
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            if (!act.activeSelf)
            {
                act.SetActive(true);
            }

            TheLevelTMP.Instance.Add();
            Destroy(col.gameObject);
        }
    }

    void FixedUpdate()
    {
        if (onButton)
        {
            Rigidbody2D.MovePosition(mousePosition + offset);
        }
    }
}