using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    private MeshRenderer waterMesh = null;      //물 메시
    private Collider waterCol = null;           //수면 콜라이더
    private Collider waterBedCol = null;        //강바닥 콜라이더

    private void Awake()
    {
        waterMesh = this.GetComponent<MeshRenderer>();
        waterCol = this.GetComponent<Collider>();
        waterBedCol = this.GetComponentInChildren<Collider>();
    }

    private void Start()
    {
        //게임 시작했을 때는 안 보이게
        waterMesh.enabled = false;
        waterCol.enabled = false;
        waterBedCol.enabled = false;
    }

    private void Update()
    {
        //물 생성기가 하나 이상 존재하면
        if (ItemManager.Instance.waterMakerCnt > 0)
        {
            waterMesh.enabled = true;
            waterCol.enabled = true;
            waterBedCol.enabled = true;
        }
        //물 생성기가 하나도 없으면
        else
        {
            waterMesh.enabled = false;
            waterCol.enabled = false;
            waterBedCol.enabled = false;
        }
    }
}