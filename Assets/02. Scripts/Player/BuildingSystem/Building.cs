using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Building : MonoBehaviour
{
    private bool _isBuilding;
    public bool isBuilding
    {
        get { return _isBuilding; }
    }

    [SerializeField]
    private List<GameObject> bulidObjects = null;

    ThirdPersonController ThirdPersonController;

    PlayerInput playerInput;
    
    public Camera mainCamera;

    private InputActionMap currentActionMap; // ���� Ȱ��ȭ�� �׼� ��

    private GameObject buildingPrefab;
    public Material previewShader;

    private GameObject previewObject;
    private Material originalShader;

    private Material previewEnableShader;
    private Material previewUnenableShader;

    int groundLayer;
    int defaultLayer;
    int previewLayer;
    int buildObjLayer;

    int buildingLayer;

    bool build = false;

    Selector selector;

    int currIndex;
    int prevIndex;

    bool prevBuildEnable = false;
    bool prevBuildCostEnable = false;
    bool buildEnable = false;
    bool buildCostEnable = false;

    [Tooltip("�Ǽ� ������Ʈ ���� ����")]
    public float rotationAngle = 15f;
    float rotation;

    private void Awake()
    {
        bulidObjects = new List<GameObject>();

        GameObject wallGameObject = Resources.Load<GameObject>("Prefabs/BuildingSystem/Wall");
        GameObject floorGameObject = Resources.Load<GameObject>("Prefabs/BuildingSystem/Floor");
        GameObject oxyMakerGameObject = Resources.Load<GameObject>("Prefabs/BuildingSystem/OxyMaker");
        GameObject waterMakerGameObject = Resources.Load<GameObject>("Prefabs/BuildingSystem/WaterMaker");
        GameObject waterSupplierGameObject = Resources.Load<GameObject>("Prefabs/BuildingSystem/WaterSupplier");
        GameObject soilPuriGameObject = Resources.Load<GameObject>("Prefabs/BuildingSystem/SoilPuri");

        bulidObjects.Add(wallGameObject);
        bulidObjects.Add(floorGameObject);
        bulidObjects.Add(oxyMakerGameObject);
        bulidObjects.Add(waterMakerGameObject);
        bulidObjects.Add(waterSupplierGameObject);
        bulidObjects.Add(soilPuriGameObject);
    }

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

        previewEnableShader = Resources.Load<Material>("Materials/BuildingSystem/PreviewEnable");
        previewUnenableShader = Resources.Load<Material>("Materials/BuildingSystem/PreviewUnenable");

        if (previewEnableShader == null)
        {
            Debug.LogError("Failed to load material. Make sure the path is correct and the material is located in the Resources folder.");
        }
        else
        {
            //Debug.Log("Material loaded successfully.");
        }

        if (previewUnenableShader == null)
        {
            Debug.LogError("Failed to load material. Make sure the path is correct and the material is located in the Resources folder.");
        }
        else
        {
            //Debug.Log("Material loaded successfully.");
        }
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

        if (previewObject)
        {
            buildEnable = previewObject.GetComponent<PreviewCollision>().prewviewEnable;
            buildCostEnable = previewObject.GetComponent<IBuild>().BuildEnable();

            if (buildEnable && buildCostEnable)
            {
                previewShader = previewEnableShader;
            }

            else
            {
                previewShader = previewUnenableShader;
            }

            if (prevBuildEnable != buildEnable || prevBuildCostEnable != buildCostEnable)
            {
                BuildObjectChange();
            }
            prevBuildCostEnable = buildCostEnable;
            prevBuildEnable = buildEnable;
        }
    }

    // ���� ��� �� ������ ������Ʈ�� ���׸����� �����ϴ� �Լ� ���� previewShader �� �����
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

        previewObject.transform.rotation = Quaternion.Euler(0, rotation, 0);

        // ������Ʈ�� ���̴��� �̸����� ���̴��� ����
        var renderer = previewObject.GetComponent<Renderer>();
        originalShader = renderer.material;
        renderer.material = previewShader;
        BoxCollider box = previewObject.GetComponent<BoxCollider>();

        box.isTrigger = true;

        previewObject.AddComponent<PreviewCollision>();
    }

    // BŰ�� ���ε� �� �Լ� ���� ��� ��ȯ �Լ�
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

    // ���콺 ��Ŭ���� ���ε� ���� ��忡�� ���� üũ �� �Ǽ� �Լ� ȣ��
    public void OnBuildingConfirm()
    {
        if (bulidObjects.Count <= 0)
        {
            Debug.LogError("Buliding System Error !");
            return;
        }

        if (buildEnable && buildCostEnable)
        {
            PlaceBuilding();
        }
    }

    // C Ű�� ���ε� ���������Ʈ �ı�
    void OnDestoryBuildObj()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out RaycastHit hitinfo, 50f, 1 << buildObjLayer))
        {
            hitinfo.collider.gameObject.GetComponent<IBuild>().Demolish();
        }
    }

    // E Ű�� ���ε� ���� ������Ʈ ȸ��
    void OnChangRotation()
    {
        rotation = rotation + rotationAngle;
        previewObject.transform.rotation = Quaternion.Euler(0, rotation, 0);
    }

    // ������ ������Ʈ ��ġ ������ �Լ�
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

    // ������ ������Ʈ�� ���׸����� ���󺹱��Ͽ� �����ϴ� �Լ� // �Ǽ� �Լ�
    void PlaceBuilding()
    {
        previewObject.GetComponent<IBuild>().BuildCost();
        // �̸����� ������Ʈ�� ��ġ�� ���� �ǹ� ����
        GameObject newObject = Instantiate(buildingPrefab, previewObject.transform.position, previewObject.transform.rotation);

        newObject.layer = buildObjLayer;
    }

    
}
