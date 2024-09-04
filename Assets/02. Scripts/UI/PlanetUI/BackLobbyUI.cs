using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackLobbyUI : MonoBehaviour
{
    // 로켓을 담을 변수
    Rocket rocket = null;
    // 프로퍼티로 get만 열어주기
    public Rocket Rocket { get { return rocket; } }

    // BackLobbyUI Init 메서드
    public void BackLobbyUIInit()
    {
        rocket = GameObject.Find("rocket").GetComponentInChildren<Rocket>();
    }   

    // 텍스트 온/오프 메서드
    public void OnOffBackLobbyText()
    {
        // RocketFindPlayer메서드를 이용해서 텍스트 껐다 켰다 해주기 
        this.gameObject.SetActive(rocket.RocketFindPlayer());
    }
}