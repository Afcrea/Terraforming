using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    Animator doorAnim; // 문 애니메이터
    string doorAnimName = "character_nearby"; // 문 애니메이터의 파라미터 이름

    private void Awake()
    {
        // 애니메이터 컴포넌트 가져오기
        doorAnim = GetComponent<Animator>();
        // 처음은 문이 닫혀있는 상태로
        doorAnim.SetBool(doorAnimName, false);
    }

    private void OnTriggerStay(Collider other)
    {
        // 콜라이더 안에 플레이어가 있을 때
        if (other.CompareTag("PLAYER"))
        {
            // 문 열림
            doorAnim.SetBool(doorAnimName, true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // 플레이어가 콜라이더를 빠져나왔을 때
        if (other.CompareTag("PLAYER"))
        { 
            // 문 닫힘
            doorAnim.SetBool(doorAnimName, false);
        }
    }
}