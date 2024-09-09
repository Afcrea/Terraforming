using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    private MeshRenderer waterMesh = null;      //�� �޽�
    private Collider waterCol = null;           //���� �ݶ��̴�
    private Collider waterBedCol = null;        //���ٴ� �ݶ��̴�

    private void Awake()
    {
        waterMesh = this.GetComponent<MeshRenderer>();
        waterCol = this.GetComponent<Collider>();
        waterBedCol = this.GetComponentInChildren<Collider>();
    }

    private void Start()
    {
        //���� �������� ���� �� ���̰�
        waterMesh.enabled = false;
        waterCol.enabled = false;
        waterBedCol.enabled = false;
    }

    private void Update()
    {
        //�� �����Ⱑ �ϳ� �̻� �����ϸ�
        if (ItemManager.Instance.waterMakerCnt > 0)
        {
            waterMesh.enabled = true;
            waterCol.enabled = true;
            waterBedCol.enabled = true;
        }
        //�� �����Ⱑ �ϳ��� ������
        else
        {
            waterMesh.enabled = false;
            waterCol.enabled = false;
            waterBedCol.enabled = false;
        }
    }
}