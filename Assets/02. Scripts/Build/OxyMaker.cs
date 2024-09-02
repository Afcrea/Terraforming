using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��һ�����
public class OxyMaker : MonoBehaviour, IInteractable, IDemolish
{
    private ItemManager itemManager = null;
    private PlayerState playerState = null;

    private void Awake()
    {
        //������ ItemManager ã�ƿ���
        itemManager = FindObjectOfType<ItemManager>();
        if (itemManager == null)
        {
            Debug.LogError("ItemManager is not found in the scene.");
        }

        //������ PlayerState ã��
        playerState = FindObjectOfType<PlayerState>();
        if (playerState == null)
        {
            Debug.LogError("PlayerState is not found in the scene.");
        }
    }

    //��ȣ�ۿ����� �÷��̾� ��ҷ� Ǯ����
    public void Interact()
    {
        playerState.PlayerCurrOxygen = playerState.PlayerInitOxygen;
    }

    //�ǹ� �μ��� �ٽ� ��� ��ȯ�ϴ� �Լ� - IDemolish �������̽�
    public void Demolish()
    {
        //��һ�����: ���� 20�� ö 20�� �� 20��
        itemManager.WoodCount += 20;
        itemManager.IronCount += 20;
        itemManager.StoneCount += 20;

        Destroy(this.gameObject);
    }
}