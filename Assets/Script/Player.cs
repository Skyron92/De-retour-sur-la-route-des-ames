using UnityEngine;

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
        
    }

    void Move() {
        if (Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical")) _timer = 0;
        float h = 0;
        float v = 0;
        h += Input.GetAxisRaw("Horizontal");
        v += Input.GetAxisRaw("Vertical");
        Vector3 move = new Vector3(h, 0, v) * Speed;
        _characterController.Move(move);
        if (move != Vector3.zero) {
            float rotationAngle = Vector3.Angle(move, Vector3.forward);
            if (h < 0) rotationAngle = -rotationAngle;
            Quaternion rotation = Quaternion.Euler(0, rotationAngle, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, _timer);
            if (_timer >= 1) {
                _timer = 1f;
            }
        }
    }
}
