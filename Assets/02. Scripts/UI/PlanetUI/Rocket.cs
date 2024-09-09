using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Rocket : MonoBehaviour
{
    // �÷��̾� Ž�� ����
    float findRange = 5f;
    // �÷��̾ ã�Ҵ��� �Ǵ��ϴ� ����
    bool isFindPlayer = false;
    // �÷��̾� ���̾� ����ũ ���� ����
    int playerLayerMask = 1 << 6;

    // Planet Scene���� Lobby Scene���� �̵��ϴ� �޼���
    public void PlanetToLobby()
    {
        // EŰ�� ������ ��
        if (Input.GetKeyDown(KeyCode.E))
        {
            // �κ� ������ �̵�
            SceneManager.LoadScene("LobbyScene");
        }
    }

    // ���Ͽ��� �÷��̾ ã�� bool���� �����ϴ� �޼���
    public bool RocketFindPlayer()
    {
        // _colliders�� �÷��̾ ã�Ƽ� ����
        Collider[] _colliders = Physics.OverlapSphere(transform.position, findRange, playerLayerMask);

        // _colliders���� �÷��̾ ����Ǿ��ٸ�
        if (_colliders.Length >= 1)
        {
            // ã�Ҵ�
            isFindPlayer = true;
            PlanetToLobby();
        }
        else // _colliders�� �÷��̾ ã�� ���ߴٸ�
        {
            // �� ã�Ҵ�
            isFindPlayer = false;
        }

        // isFindPlayer�� bool���� ����
        return isFindPlayer;
    }
}