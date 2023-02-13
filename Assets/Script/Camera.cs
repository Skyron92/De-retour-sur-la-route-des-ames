using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private Transform PlayerTransform;
    private float X;
    private float Z;
    
    void Awake() {
        X = transform.position.x;
        Z = transform.position.z;
    }
    
    void Update() {
        Vector3 position = transform.position;
        position.x = X + PlayerTransform.position.x;
        position.z = Z + PlayerTransform.position.z;
        transform.position = position;
    }
}
