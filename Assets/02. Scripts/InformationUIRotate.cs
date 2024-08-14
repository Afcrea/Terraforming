using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InformationUIRotate : MonoBehaviour
{
    Transform playerTr = null;
    Vector3 lookVector;

    private void Awake()
    {
        // 플레이어 Transform 가져오기
        playerTr = GameObject.FindGameObjectWithTag("PLAYER").GetComponent<Transform>();
    }

    private void Update()
    {
        // 바라볼 방향 계산
        lookVector = new Vector3(playerTr.position.x - this.transform.position.x, this.transform.position.y, playerTr.position.z - this.transform.position.z);
        // 바라보기
        transform.LookAt(lookVector);
    }
}