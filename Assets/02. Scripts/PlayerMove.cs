using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float playerMoveSpeed = 5;
    public float gravity = -20; // 중력가속도 임의로 20으로 설정한것. 원래 9.8
    float yVelocity; // 중력

    public float jumpPower = 5;
    public int maxJumpCount = 1;
    int jumpCount = 0;

    public Animator ani;
    public Collider col;

    CharacterController cc; // 컨트롤러 이용

    // Start is called before the first frame update
    void Start()
    {
        cc = gameObject.GetComponent<CharacterController>(); // 컨트롤러 가져옴
        ani = GetComponent<Animator>();
        col = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal"); // 사용자 입력 처리
        float v = Input.GetAxis("Vertical"); // 사용자 입력 처리

        Vector3 dir = new Vector3(h, 0, v); // 움직이는 것이 y축이 아닌 x,z축만 사용하여 이동
        dir.Normalize(); // 정규화

        dir = Camera.main.transform.TransformDirection(dir); // 내가 보는 방향으로(카메라의 방향으로) 이동하고싶다

        // Player가 땅에 내려오면 점프카운트 초기화
        if (cc.collisionFlags == CollisionFlags.Below) // 플레이어와 바닥이 닿으면
        {
            jumpCount = 0;
            yVelocity = 0;
        }

        if (Input.GetButtonDown("Jump")) // 만약 spacebar를 누르면
        {
            if (jumpCount == 0 && cc.collisionFlags != CollisionFlags.Below) return;

            else if (jumpCount < maxJumpCount)
            {
                yVelocity = jumpPower;
                jumpCount++;
            }
        }

        // 중력 적용
        yVelocity += gravity * Time.deltaTime; // V = V0 + at
        dir.y = yVelocity; // y에 중력 적용
        //transform.position += dir * playerMoveSpeed * Time.deltaTime; // P = P0 + vt

        cc.Move(dir * playerMoveSpeed * Time.deltaTime);
    }
}
