using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class Player : NetworkBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _collisionForce;

    private Rigidbody _rb;  

    void Start()
    {
        RandomPlayerColor();

        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        var _horizontalInput = Input.GetAxis("Horizontal");
        var _verticalInput = Input.GetAxis("Vertical");

        var _moveDirection = Vector3.forward * _verticalInput + Vector3.right * _horizontalInput;

        _rb.AddForce(_moveDirection.normalized * _moveSpeed, ForceMode.Force);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            var _collisionDirection = collision.gameObject.transform.position - transform.position;
            collision.gameObject.GetComponent<Rigidbody>().AddForce(_collisionDirection * _collisionForce, ForceMode.Impulse);
        }
    }

    private void RandomPlayerColor()
    {
        GetComponent<MeshRenderer>().material.color = new Color(Random.Range(0f,1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }
}
