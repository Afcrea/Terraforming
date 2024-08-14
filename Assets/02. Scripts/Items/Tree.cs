using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.UI;

public class Tree : MonoBehaviour, IInteractable
{
    private ItemManager itemManager;

    private bool isGathering = true;   //ä�� ���� ���� �Ǻ� ����

    GameObject seedlingPrefab;  //���� ������Ʈ

    private void Awake()
    {
        //������ ItemManager ã�ƿ���
        itemManager = FindObjectOfType<ItemManager>();
        if (itemManager == null)
        {
            Debug.LogError("ItemManager is not found in the scene.");
        }
    }

    private void Start()
    {
        seedlingPrefab = Resources.Load<GameObject>("Prefabs/Seedling");
    }

    public void Interact()
    {
        Debug.Log("���ͷ�Ʈ ����");
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

        //���� ������ ��� ����
        Instantiate(seedlingPrefab, this.transform.position, this.transform.rotation);

        //�� ������Ʈ �ı�
        Destroy(this.gameObject);

        yield return null;
    }

    //�� ����
    //�ܰ迡 ���� Mesh ����? / ������ ����
    //������ �̿Ϸ�� ������ ���� isGathering => false�� ����
}