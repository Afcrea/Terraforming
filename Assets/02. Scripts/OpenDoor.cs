using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    Animator doorAnim; // �� �ִϸ�����
    string doorAnimName = "character_nearby"; // �� �ִϸ������� �Ķ���� �̸�

    private void Awake()
    {
        // �ִϸ����� ������Ʈ ��������
        doorAnim = GetComponent<Animator>();
        // ó���� ���� �����ִ� ���·�
        doorAnim.SetBool(doorAnimName, false);
    }

    private void OnTriggerStay(Collider other)
    {
        // �ݶ��̴� �ȿ� �÷��̾ ���� ��
        if (other.CompareTag("PLAYER"))
        {
            // �� ����
            doorAnim.SetBool(doorAnimName, true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // �÷��̾ �ݶ��̴��� ���������� ��
        if (other.CompareTag("PLAYER"))
        { 
            // �� ����
            doorAnim.SetBool(doorAnimName, false);
        }
    }
}