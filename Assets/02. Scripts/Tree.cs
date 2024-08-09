using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.UI;

public class Tree : MonoBehaviour, IInteractable
{
    private ItemManager itemManager;

    private bool isGathering = false;   //ä�� ���� ���� �Ǻ� ���� 

    private void Awake()
    {
        //������ ItemManager ã�ƿ���
        itemManager = FindObjectOfType<ItemManager>();
        if (itemManager == null)
        {
            Debug.LogError("ItemManager is not found in the scene.");
        }
    }

    public void Interact()
    {
        if (isGathering)
        {
            //ä�� �ڷ�ƾ ����
            StartCoroutine(Gathering());
        }
    }

    //ä��
    private IEnumerator Gathering()
    {
        //���� 1�� ���� 3�� ȹ��
        itemManager.WoodCount += 3;

        //�� ���� ������ ��� ����

        //�� ������Ʈ �ı�
        Destroy(this.gameObject);

        yield return null;
    }

    //�� ����
    //�ܰ迡 ���� Mesh ����?
    //������ �Ϸ�� �����̸� isGathering => true�� ����
}