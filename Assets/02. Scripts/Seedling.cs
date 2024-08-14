using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class Seedling : MonoBehaviour, IInteractable
{
    private ItemManager itemManager;
    private Transform playerTr;         //�÷��̾� ��ġ ��ƿ� ����
    private float distance = 3f;        //�ڼ� ȿ�� ������ �÷��̾�� ������Ʈ ���� �Ÿ�
    private float magnetSpeed = 0.2f;   //�ڼ� ȿ�� �ӵ�

    public void Interact()
    {
        itemManager.SeedlingCount++;
        Debug.Log(this.name + " ���� : " + itemManager.SeedlingCount);
        Destroy(this.gameObject);
    }

    private void Awake()
    {
        //������ ItemManager ã�ƿ���
        itemManager = FindObjectOfType<ItemManager>();
        if (itemManager == null)
        {
            Debug.LogError("ItemManager is not found in the scene.");
        }

        playerTr = GameObject.FindWithTag("PLAYER").GetComponent<Transform>();  //�÷��̾� �±׷� ��ġ �޾ƿ���
    }

    private void Update()
    {
        if (Vector3.Distance(this.transform.position, playerTr.position) < distance)
        {
            Vector3 magnetToPlayer = playerTr.position - this.transform.position;
            transform.Translate(magnetToPlayer * magnetSpeed * Time.deltaTime, Space.Self);
        }
    }
}