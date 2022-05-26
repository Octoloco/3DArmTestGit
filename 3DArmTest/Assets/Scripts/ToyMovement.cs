using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;

    public Toyspawner toyspawner;
    private bool mayMove;

    void Start()
    {
        mayMove = true;
    }

    void Update()
    {
        if (mayMove)
        {
            Move();
        }
    }

    private void Move()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Stop"))
        {
            mayMove = false;
            transform.position = other.transform.position;
        }
        else if (other.gameObject.CompareTag("Go"))
        {
            mayMove = true;
        }
        else if (other.gameObject.CompareTag("Kill"))
        {
            toyspawner.DestroyToy(this);
        }
    }
}
