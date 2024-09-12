using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    private MeshRenderer waterMesh = null;      //물 메시
    private Collider[] waterCol = null;         //물 관련 콜라이더

    private void Awake()
    {
        waterMesh = this.GetComponent<MeshRenderer>();
        waterCol = this.GetComponentsInChildren<Collider>();
    }

    private void Start()
    {
        //게임 시작했을 때는 안 보이게
        waterMesh.enabled = false;
        waterCol[0].enabled = false;    //수면 콜라이더
        waterCol[1].enabled = false;    //물 밑바닥 콜라이더
    }

    private void Update()
    {
        //물 생성기가 하나 이상 존재하면
        if (ItemManager.Instance.waterMakerCnt > 0)
        {
            waterMesh.enabled = true;
            waterCol[0].enabled = true;
            waterCol[1].enabled = true;
        }
        //물 생성기가 하나도 없으면
        else
        {
            //오류로 0 이하가 되면 0으로 보정하고 같은 결과 실행
            if (ItemManager.Instance.waterMakerCnt < 0)
            {
                ItemManager.Instance.waterMakerCnt = 0;
            }

            waterMesh.enabled = false;
            waterCol[0].enabled = false;
            waterCol[1].enabled = false;
        }
    }
}