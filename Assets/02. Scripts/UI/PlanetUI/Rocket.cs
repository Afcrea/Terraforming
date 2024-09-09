using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Rocket : MonoBehaviour
{
    // 플레이어 탐지 범위
    float findRange = 5f;
    // 플레이어를 찾았는지 판단하는 변수
    bool isFindPlayer = false;
    // 플레이어 레이어 마스크 저장 변수
    int playerLayerMask = 1 << 6;

    // Planet Scene에서 Lobby Scene으로 이동하는 메서드
    public void PlanetToLobby()
    {
        // E키를 눌렀을 때
        if (Input.GetKeyDown(KeyCode.E))
        {
            // 로비 씬으로 이동
            SceneManager.LoadScene("LobbyScene");
        }
    }

    // 로켓에서 플레이어를 찾아 bool값을 리턴하는 메서드
    public bool RocketFindPlayer()
    {
        // _colliders에 플레이어를 찾아서 저장
        Collider[] _colliders = Physics.OverlapSphere(transform.position, findRange, playerLayerMask);

        // _colliders에에 플레이어가 저장되었다면
        if (_colliders.Length >= 1)
        {
            // 찾았다
            isFindPlayer = true;
            PlanetToLobby();
        }
        else // _colliders에 플레이어를 찾지 못했다면
        {
            // 못 찾았다
            isFindPlayer = false;
        }

        // isFindPlayer의 bool값을 리턴
        return isFindPlayer;
    }
}