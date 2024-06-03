using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullingJunp : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 clickPosition;
    [SerializeField]
    private float jumpPower = 10;
    private bool isCanJump;

    enum GravityDirection
    {
        Up, Left, Down, Right
    }

    GravityDirection gravityDirection = GravityDirection.Down;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 gravity = new Vector3(0,0,0);
        //if (Input.GetKeyDown(KeyCode.UpArrow)) { gravityDirection = GravityDirection.Up; }
        //if (Input.GetKeyDown(KeyCode.DownArrow)) { gravityDirection = GravityDirection.Down; }
        //if (Input.GetKeyDown(KeyCode.RightArrow)) { gravityDirection = GravityDirection.Right; }
        //if (Input.GetKeyDown(KeyCode.LeftArrow)) { gravityDirection = GravityDirection.Left; }

        //if (gravityDirection == GravityDirection.Up)
        //{
        //    gravity = new Vector3(0, 9.8f, 0);
        //}
        //else if (gravityDirection == GravityDirection.Down)
        //{
        //    gravity = new Vector3(0, -9.8f, 0);
        //}
        //else if (gravityDirection == GravityDirection.Left)
        //{
        //    gravity = new Vector3(-9.8f, 0, 0);
        //}
        //else if (gravityDirection == GravityDirection.Right) 
        //{
        //    gravity = new Vector3(9.8f, 0, 0);
        //}
        //Physics.gravity = gravity;

        if (Input.GetMouseButtonDown(0))
        {
            clickPosition = Input.mousePosition;
        }
        if(isCanJump)
        {
            if (Input.GetMouseButtonUp(0))
            {
                // �N���b�N�������W�ƕ��������W�̍������擾
                Vector3 dist = clickPosition - Input.mousePosition;
                // �N���b�N�ƃ����[�X���������W�Ȃ�Ζ���
                if (dist.sqrMagnitude == 0) { return; }
                // ������W�������AJumpPower���������킹���l���ړ��ʂƂ���
                rb.velocity = dist.normalized * jumpPower;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

    }
    private void OnCollisionStay(Collision collision)
    {
        isCanJump = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        isCanJump = false;
    }
}
