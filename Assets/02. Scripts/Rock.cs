using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour, IInteractable
{
    private float oneDay = 600f;    //리스폰 시간 => 하루: 10분, 600초

    private SphereCollider rockCol; //광석 콜라이더
    private MeshRenderer rockMesh;  //광석 메시

    private ItemManager itemManager;

    private void Awake()
    {
        //씬에서 ItemManager 찾아오기
        itemManager = FindObjectOfType<ItemManager>();
        if (itemManager == null)
        {
            Debug.LogError("ItemManager is not found in the scene.");
        }

        //콜라이더, 메시 지정
        rockCol = this.gameObject.GetComponent<SphereCollider>();
        rockMesh = this.gameObject.GetComponent<MeshRenderer>();
    }

    public void Interact()
    {
        //채광 코루틴 실행
        StartCoroutine(Mining());
    }

    //채광
    private IEnumerator Mining()
    {
        rockCol.enabled = false;
        rockMesh.enabled = false;

        //돌10개 철 3개 획득
        itemManager.StoneCount += 10;
        itemManager.IronCount += 3;

        //리스폰 코루틴 실행
        StartCoroutine(Respawn());

        yield return null;
    }

    //일정 시간(하루) 지난 후 리스폰
    private IEnumerator Respawn()
    {
        yield return new WaitForSeconds(oneDay);
        rockCol.enabled = true;
        rockMesh.enabled = true;
    }
}