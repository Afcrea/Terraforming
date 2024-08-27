using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snow : MonoBehaviour
{
    GameObject player = null;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("PLAYER");
    }

    private void LateUpdate()
    {
        // �÷��̾� ���� ���� ���� ���󰡰� �ϱ�
        this.gameObject.transform.position = player.transform.position + new Vector3(0f, 5f, 0f);
    }
}