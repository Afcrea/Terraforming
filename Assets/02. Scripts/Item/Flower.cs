using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.UI;
using static UnityEditor.Progress;

public class Flower : MonoBehaviour, IInteractable
{
    private ItemManager itemManager;
    public bool isGathering = true;    //ä�� ���� ���� �Ǻ� ����
    GameObject seedPrefab;              //���� ������Ʈ
    GameObject fruitPrefab;             //���� ������Ʈ

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
        seedPrefab = Resources.Load<GameObject>("Prefabs/Seed");
        fruitPrefab = Resources.Load<GameObject>("Prefabs/Fruit");
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
        //���� ������ 1�� ��� ����
        Instantiate(seedPrefab, this.transform.position, this.transform.rotation);
        //���� ������ 3�� ��� ����
        for (int i = 0; i < 3; i++)
        {
            Vector3 RandomPos = new Vector3(Random.Range(-0.3f, 0.3f), 0, Random.Range(-0.3f, 0.3f));
            Instantiate(fruitPrefab, this.transform.position + RandomPos, this.transform.rotation);
        }

        //�� ������Ʈ �ı�
        Destroy(this.gameObject);

        yield return null;
    }

    //�� ����
    //�ܰ迡 ���� Mesh ����? / ������ ����
    //������ �̿Ϸ�� ������ ���� isGathering => false�� ����
}