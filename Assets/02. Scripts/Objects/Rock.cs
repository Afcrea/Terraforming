using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour, IInteractable
{
    private float oneDay = 600f;    //������ �ð� => �Ϸ�: 10��, 600��

    private SphereCollider rockCol; //���� �ݶ��̴�
    private MeshRenderer rockMesh;  //���� �޽�

    private ItemManager itemManager;

    private void Awake()
    {
        //������ ItemManager ã�ƿ���
        itemManager = FindObjectOfType<ItemManager>();
        if (itemManager == null)
        {
            Debug.LogError("ItemManager is not found in the scene.");
        }

        //�ݶ��̴�, �޽� ����
        rockCol = this.gameObject.GetComponent<SphereCollider>();
        rockMesh = this.gameObject.GetComponent<MeshRenderer>();
    }

    public void Interact()
    {
        //ä�� �ڷ�ƾ ����
        StartCoroutine(Mining());
    }

    //ä��
    private IEnumerator Mining()
    {
        rockCol.enabled = false;
        rockMesh.enabled = false;

        //��10�� ö 3�� ȹ��
        itemManager.StoneCount += 10;
        itemManager.IronCount += 3;

        //������ �ڷ�ƾ ����
        StartCoroutine(Respawn());

        yield return null;
    }

    //���� �ð�(�Ϸ�) ���� �� ������
    private IEnumerator Respawn()
    {
        yield return new WaitForSeconds(oneDay);
        rockCol.enabled = true;
        rockMesh.enabled = true;
    }
}