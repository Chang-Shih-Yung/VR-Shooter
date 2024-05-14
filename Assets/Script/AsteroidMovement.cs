using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    //前進速度
    [Header("Control the speed of the Asteroid")]
    public float maxSpeed;
    public float minSpeed;
    //轉速
    [Header("Control the rotational speed")]
    public float rotationalSpeedMin;
    public float rotationalSpeedMax;
    //儲存轉速
    private float rotationalSpeed;
    //轉動角度
    private float xAngle, yAngle, zAngle;

    //運動方向
    public Vector3 movementDirection;

    private float asteroidSpeed;


    // Start is called before the first frame update
    void Start()
    {
        //取得隨機速度
        asteroidSpeed = Random.Range(minSpeed, maxSpeed);

        //取得隨機旋轉角度
        xAngle = Random.Range(0, 360);
        yAngle = Random.Range(0, 360);
        zAngle = Random.Range(0, 360);
        //隨機旋轉
        transform.Rotate(xAngle, yAngle, zAngle);

        rotationalSpeed = Random.Range(rotationalSpeedMin, rotationalSpeedMax);

    }

    // Update is called once per frame
    void Update()
    {
        //讓世界坐標系移動
        transform.Translate(movementDirection * Time.deltaTime * asteroidSpeed, Space.World);
        //持續旋轉
        transform.Rotate(rotationalSpeed * Time.deltaTime, rotationalSpeed * Time.deltaTime, rotationalSpeed * Time.deltaTime);



    }
}
