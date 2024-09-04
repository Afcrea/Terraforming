using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��һ�����
public class OxyMaker : MonoBehaviour, IInteractable, IDemolish, IBuildable
{
    private PlayerState playerState = null;
    private PlanetManager planetManager = null;

    private void Awake()
    {

        //������ PlayerState ã��
        playerState = FindObjectOfType<PlayerState>();
        if (playerState == null)
        {
            Debug.LogError("PlayerState is not found in the scene.");
        }

        //������ PlanetManager ã�ƿ���
        planetManager = FindObjectOfType<PlanetManager>();
        if (planetManager == null)
        {
            Debug.LogError("PlanetManager is not found in the scene.");
        }
    }

    private void Start()
    {
        StartCoroutine(MakeOxygen());
    }

    //�÷��̾�� ��ȣ�ۿ����� �÷��̾� ��ҷ� Ǯ����
    public void Interact()
    {
        playerState.PlayerCurrOxygen = playerState.PlayerInitOxygen;
    }

    //�ǹ� �μ��� �ٽ� ��� ��ȯ�ϴ� �Լ� - IDemolish �������̽�
    public void Demolish()
    {
        //��һ�����: ���� 20�� ö 20�� �� 20��
        ItemManager.Instance.WoodCount += 20;
        ItemManager.Instance.IronCount += 20;
        ItemManager.Instance.StoneCount += 20;

        Destroy(this.gameObject);
    }

    //��� ��ȭ
    private IEnumerator MakeOxygen()
    {
        while (this.gameObject)
        {
            //��� ������ => 15�� ���� ��� + 1
            yield return new WaitForSeconds(15f);
            planetManager.oxygenLevel += 1f;
            //Debug.Log("��һ����Ⱑ ����� ��");
        }
    }

    public bool BuildEnable()
    {
        if (ItemManager.Instance.StoneCount >= 20 && ItemManager.Instance.IronCount >= 20 && ItemManager.Instance.WoodCount >= 20)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}