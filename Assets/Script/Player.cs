using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Player : MonoBehaviour
{
    private CharacterController _characterController;
    [Range(0,100)] [SerializeField] private float Speed;
    private float _timer;

    void Start() {
        _characterController = GetComponent<CharacterController>();
    }

    
    void Update() {
        Move();
        _timer += Time.deltaTime;
        if (_timer >= 1) _timer = 1;
    }

    void Move() {
        if (Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical")) _timer = 0;
        float h = 0;
        float v = 0;
        h += Input.GetAxisRaw("Horizontal");
        v += Input.GetAxisRaw("Vertical");
        Vector3 move = new Vector3(h, 0, v) * Speed;
        _characterController.Move(move);

        float rotationAngle = Vector3.Angle(move, Vector3.forward);
        //if (h < 0) rotationAngle = -rotationAngle;
        Quaternion rotation = Quaternion.Euler(0, rotationAngle, 0);
        transform.rotation = new Quaternion(0, Mathf.Lerp(transform.rotation.y, rotation.y, _timer), 0, 0);
    }
}
