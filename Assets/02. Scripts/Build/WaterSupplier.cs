using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�޼���
public class WaterSupplier : MonoBehaviour, IInteractable, IDemolish
{
    private ItemManager itemManager = null;

    private void Awake()
    {
        //������ ItemManager ã�ƿ���
        itemManager = FindObjectOfType<ItemManager>();
        if (itemManager == null)
        {
            Debug.LogError("ItemManager is not found in the scene.");
        }
    }

    //�ڻ�ȣ�ۿ�� �÷��̾� ���� + 
    public void Interact()
    {

    }

    //�ǹ� �μ��� �ٽ� ��� ��ȯ�ϴ� �Լ� - IDemolish �������̽�
    //�޼���: �� 20�� ö 10��
    public void Demolish()
    {
        itemManager.StoneCount += 20;
        itemManager.IronCount += 10;

        Destroy(this.gameObject);
    }
}