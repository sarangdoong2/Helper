using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{

    public float rotSpeed = 200;
    float mx;   // 마우스 x각도
    float my;   // 마우스 y각도

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Mouse X");  // 마우스 X축 움직임 감지
        float v = Input.GetAxis("Mouse Y");  // 마우스 Y축 움직임 감지

        mx += h * rotSpeed * Time.deltaTime; // 마우스 X각도를 누적
        my += v * rotSpeed * Time.deltaTime; // 마우스 Y각도를 누적

/*        if (my >= 90)
        {
            my = 90;
        }
        else if (mx <= -90) {
            mx = -90;
        }*/

        my = Mathf.Clamp(my, -90, 90); // my의 범위값 지정
        transform.eulerAngles = new Vector3(-my, mx, 0); // 픽셀 부호가 위아래 반대이므로 my*-1

    }
}
