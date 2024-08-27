using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : MonoBehaviour
{
    GameObject player = null;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("PLAYER");
    }

    private void LateUpdate()
    {
        // �÷��̾� ���� ���� ���� ���󰡰� �ϱ�
        this.gameObject.transform.position = player.transform.position + new Vector3(0f, 10f, 0f);
    }
}