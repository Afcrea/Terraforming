using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    private MeshRenderer waterMesh = null;      //�� �޽�
    private Collider[] waterCol = null;         //�� ���� �ݶ��̴�

    private void Awake()
    {
        waterMesh = this.GetComponent<MeshRenderer>();
        waterCol = this.GetComponentsInChildren<Collider>();
    }

    private void Start()
    {
        //���� �������� ���� �� ���̰�
        waterMesh.enabled = false;
        waterCol[0].enabled = false;    //���� �ݶ��̴�
        waterCol[1].enabled = false;    //�� �عٴ� �ݶ��̴�
    }

    private void Update()
    {
        //�� �����Ⱑ �ϳ� �̻� �����ϸ�
        if (ItemManager.Instance.waterMakerCnt > 0)
        {
            waterMesh.enabled = true;
            waterCol[0].enabled = true;
            waterCol[1].enabled = true;
        }
        //�� �����Ⱑ �ϳ��� ������
        else
        {
            //������ 0 ���ϰ� �Ǹ� 0���� �����ϰ� ���� ��� ����
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