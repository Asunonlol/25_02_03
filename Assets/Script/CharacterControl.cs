using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Transform _transform;
    private Animator _animator;
    private float _horizontal;
    private float _vertical;
    private GameObject MainCamera;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        MainCamera = Camera.main.gameObject;
        _rigidbody = GetComponent<Rigidbody>();
        _transform = GetComponent<Transform>();
        _animator = GetComponent<Animator>();

        this.target = GameObject.Find("Muryotaisu(1)").transform;
    }
    [SerializeField]
    private float _speed = 0.1f;
    // Update is called once per frame
    void Update()
    {
        var velocity = Vector3.zero;

        //transform.rotation = MainCamera.transform.rotation;

        //transform.rotation = Quaternion.Euler(0, MainCamera.transform.localEulerAngles.y, 0); 

        if (UnityEngine.Input.anyKey)
        {
            if (UnityEngine.Input.GetKey(KeyCode.W))
            {
                velocity.z = _speed;
            }
            if (UnityEngine.Input.GetKey(KeyCode.A))
            {
                velocity.x = -_speed;
            }
            if (UnityEngine.Input.GetKey(KeyCode.S))
            {
                velocity.z = -_speed;
            }
            if (UnityEngine.Input.GetKey(KeyCode.D))
            {
                velocity.x = _speed;
            }

            if (velocity.x != 0 || velocity.z != 0)
            {
                _transform.position += transform.rotation * velocity;
            }
        }
        //対象オブジェクトの現在の回転
        Vector3 currentRotation = transform.eulerAngles;
        //他オブジェクト(F07)の回転を取得
        Vector3 targetRotation = target.eulerAngles;
        if (target != null)
        {
            //Y軸のみ他オブジェクトに一致させる
            transform.rotation = Quaternion.Euler(currentRotation.x, targetRotation.y, currentRotation.z);
        }

    }
}
