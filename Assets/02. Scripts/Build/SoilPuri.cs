using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�����ȭ��
public class SoilPuri : MonoBehaviour, IDemolish
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

    //��1���� ���� �������� 1�� ������ => �� ȯ�濡�� ������ �����ͼ� ���߱�

    //�ǹ� �μ��� �ٽ� ��� ��ȯ�ϴ� �Լ� - IDemolish �������̽�
    public void Demolish()
    {
        //�����ȭ��: �� 20�� ö 20��
        itemManager.StoneCount += 20;
        itemManager.IronCount += 20;

        Destroy(this.gameObject);
    }
}