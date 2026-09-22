using System.Collections.Generic;
using UnityEngine;
public class PhysicsEngine : MonoBehaviour
{
    public float mass;
    public Vector3 velocityVector; // 평균 이동속도
    public Vector3 netForceVector;
    public List<Vector3> forceVectorList = new List<Vector3>();
    // 여러개의 힘들을 합칠 리스트 생성

    void FixedUpdate()
    {
        AddForces();
        UpdateVelocity();


        transform.position += velocityVector * Time.deltaTime;


    }
    void AddForces()
    {
        netForceVector = Vector3.zero;
        foreach (Vector3 forceVector in forceVectorList) //리스트안의 힘들을 가져옴
        {
            netForceVector = netForceVector + forceVector; //힘들을 합침
        }
    }
    void UpdateVelocity()
    {
        Vector3 accelerationVector = netForceVector / mass; //F=ma 의 공식을 이용하여 a = f/m
        velocityVector += accelerationVector * Time.deltaTime; // 계산한값을 속도에 적용
    }
}
