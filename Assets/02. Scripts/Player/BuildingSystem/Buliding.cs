using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Buliding : MonoBehaviour
{
    private bool _isBuilding;

    public List<GameObject> bulidObjects;

    ThirdPersonController ThirdPersonController;

    PlayerInput playerInput;
    
    public Camera mainCamera;

    private InputActionMap currentActionMap; // ���� Ȱ��ȭ�� �׼� ��

    private GameObject buildingPrefab;
    public Material previewShader;

    private GameObject previewObject;
    private Material originalShader;

    int groundLayer;
    int defaultLayer;
    int previewLayer;
    int buildObjLayer;

    int buildingLayer;

    bool build = false;

    Selector selector;

    int currIndex;
    int prevIndex;

    void Start()
    {
        ThirdPersonController = GetComponent<ThirdPersonController>();
        playerInput = GetComponent<PlayerInput>();
        selector = GetComponent<Selector>();

        groundLayer = LayerMask.NameToLayer("GROUND");
        defaultLayer = LayerMask.NameToLayer("Default");
        previewLayer = LayerMask.NameToLayer("PREVIEW");
        buildObjLayer = LayerMask.NameToLayer("BUILDOBJ");

        buildingLayer = 1 << groundLayer | 1 << buildObjLayer;

        mainCamera = Camera.main;
    }

    private void Update()
    {
        prevIndex = currIndex;
        currIndex = selector.selectedIndex;
        if (bulidObjects.Count > currIndex)
            buildingPrefab = bulidObjects[currIndex];

        if (build && currIndex != prevIndex)
        {
            BuildObjectChange();
        }

        //print(currIndex);
    }

    void BuildObjectChange()
    {
        if(previewObject) 
        {
            Destroy(previewObject);
        }
        
        if(bulidObjects.Count <= 0)
        {
            Debug.LogError("Buliding System Error !");
            return;
        }
        previewObject = Instantiate(buildingPrefab);

        // ������Ʈ�� ���̴��� �̸����� ���̴��� ����
        var renderer = previewObject.GetComponent<Renderer>();
        originalShader = renderer.material;
        renderer.material = previewShader;
        previewObject.GetComponent<BoxCollider>().isTrigger = true;
    }

    void OnBuliding()
    {
        _isBuilding = !_isBuilding;

        if (_isBuilding)
        {
            Cursor.lockState = CursorLockMode.Confined;
            playerInput.SwitchCurrentActionMap("BuildingSystem");

            BuildObjectChange();

            build = true;
            
            StartCoroutine(UpdatePreviewPosition());
        }

        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            playerInput.SwitchCurrentActionMap("Player");
            build = false;
            Destroy(previewObject);
        }
    }

    public void OnBuildingConfirm()
    {
        if (bulidObjects.Count <= 0)
        {
            Debug.LogError("Buliding System Error !");
            return;
        }
        PlaceBuilding();
    }

    IEnumerator UpdatePreviewPosition()
    {
        while(build)
        {
            // Raycast�� ����Ͽ� ���� ��ǥ�� ���
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo, 50f, buildingLayer))
            {
                previewObject.transform.position = hitInfo.point;
            }
            yield return null;
        }
    }

    void PlaceBuilding()
    {
        previewObject.GetComponent<BoxCollider>().isTrigger = false;
        previewObject.GetComponent<Renderer>().material = originalShader;
        // �̸����� ������Ʈ�� ��ġ�� ���� �ǹ� ����
        GameObject newObject = Instantiate(buildingPrefab, previewObject.transform.position, previewObject.transform.rotation);

        newObject.layer = buildObjLayer;

        previewObject.GetComponent<BoxCollider>().isTrigger = true;
        previewObject.GetComponent<Renderer>().material = previewShader;
    }
}
