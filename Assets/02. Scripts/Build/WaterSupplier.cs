using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�޼���
public class WaterSupplier : MonoBehaviour, IInteractable, IBuild
{
    private PlayerState playerState = null;

    private void Awake()
    {
        //������ PlayerState ã��
        playerState = FindObjectOfType<PlayerState>();
        if (playerState == null)
        {
            Debug.LogError("PlayerState is not found in the scene.");
        }
    }

    //��ȣ�ۿ�� �÷��̾� ü�� ���з� �ִ�ġ��
    public void Interact()
    {
        playerState.PlayerCurrWater = playerState.PlayerInitWater;
    }

    //�ǹ� �μ��� �ٽ� ��� ��ȯ�ϴ� �Լ� - IDemolish �������̽�
    //�޼���: �� 20�� ö 10��
    public void Demolish()
    {
        ItemManager.Instance.StoneCount += 20;
        ItemManager.Instance.IronCount += 10;

        Destroy(this.gameObject);
    }

    public bool BuildEnable()
    {
        if (ItemManager.Instance.StoneCount >= 20 && ItemManager.Instance.IronCount >= 10)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void BuildCost()
    {
        ItemManager.Instance.StoneCount -= 20;
        ItemManager.Instance.IronCount -= 10;
    }
}