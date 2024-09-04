using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackLobbyUI : MonoBehaviour
{
    // ������ ���� ����
    Rocket rocket = null;
    // ������Ƽ�� get�� �����ֱ�
    public Rocket Rocket { get { return rocket; } }

    // BackLobbyUI Init �޼���
    public void BackLobbyUIInit()
    {
        rocket = GameObject.Find("rocket").GetComponentInChildren<Rocket>();
    }   

    // �ؽ�Ʈ ��/���� �޼���
    public void OnOffBackLobbyText()
    {
        // RocketFindPlayer�޼��带 �̿��ؼ� �ؽ�Ʈ ���� �״� ���ֱ� 
        this.gameObject.SetActive(rocket.RocketFindPlayer());
    }
}