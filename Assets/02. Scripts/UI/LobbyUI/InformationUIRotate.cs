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
        // �÷��̾� Transform ��������
        playerTr = GameObject.FindGameObjectWithTag("PLAYER").GetComponent<Transform>();
    }

    private void Update()
    {
        // �ٶ� ���� ���
        lookVector = new Vector3(playerTr.position.x - this.transform.position.x, this.transform.position.y, playerTr.position.z - this.transform.position.z);
        // �ٶ󺸱�
        transform.LookAt(lookVector);
    }
}