using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�� ������
public class WaterMaker : MonoBehaviour, IBuild
{
    private void Awake()
    {
    }

    //�� �ʿ� �� ���� => ?
    //�� ������ ���� ���� ���� �����ϰ� => ? 

    //�ǹ� �μ��� �ٽ� ��� ��ȯ�ϴ� �Լ� - IDemolish �������̽�
    public void Demolish()
    {
        //�� ������: �� 20�� ö 20��
        ItemManager.Instance.StoneCount += 20;
        ItemManager.Instance.IronCount += 20;

        Destroy(this.gameObject);
    }

    public bool BuildEnable()
    {
        if (ItemManager.Instance.StoneCount >= 20 && ItemManager.Instance.IronCount >= 20)
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
        ItemManager.Instance.IronCount -= 20;
    }
}