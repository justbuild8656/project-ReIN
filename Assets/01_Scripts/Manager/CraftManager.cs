using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class CraftManager : MonoBehaviour
{
    //인벤토리 시스템이랑 합칠때 옮길예정
    [Header("ArtifactIventory")]
    private Dictionary<int, ArtifactMaterial> MaterialInventory;

    [Header("[Artifact Recipe]")]
    public SO_ArtifactRecipe recipe;
    private int reqCondition = 0;

    [Header("[Artifacts]")]
    public int artifactCount;
    [SerializeField] private List<SO_Artifact> resultArtifacts;

    [Header("[UI]")]
    public GameObject craftWidget;
    public GameObject content;
    public GameObject slot;
    public Button craftButton;
    public Button exitButton;
    public Button openButton;
    private void Awake()
    {
        //데이터 초기화
        Initialize();
        //gameObject.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            TestInput();
        }
    }
    //테스트(지울 예정)
    private void TestInput()
    {
        reqCondition = 0;
        AddDictionary(0, ArtifactMaterialGrade.Common, 5, MaterialInventory);
        AddDictionary(1, ArtifactMaterialGrade.SuperRare, 5, MaterialInventory);
        AddDictionary(2, ArtifactMaterialGrade.Rare, 5, MaterialInventory);
        AddDictionary(3, ArtifactMaterialGrade.UltraRare, 5, MaterialInventory);
        for (int i = 0; i < recipe.reqMaterials.Length; i++)
        {
            RefreshSlot(i, recipe.reqMaterials[i].materialID.ToString(), recipe.reqMaterials[i].count, MaterialInventory[i].count);
        }
    }

    private void Initialize()
    {
        reqCondition = 0;
        //인스턴스화
        MaterialInventory = new Dictionary<int, ArtifactMaterial>();
        slots = new List<GameObject>();

        //딕셔너리속 데이터들 null => 0으로 변경
        AddDictionary(0, ArtifactMaterialGrade.Common, 0, MaterialInventory);
        AddDictionary(1, ArtifactMaterialGrade.SuperRare, 0, MaterialInventory);
        AddDictionary(2, ArtifactMaterialGrade.Rare, 0, MaterialInventory);
        AddDictionary(3, ArtifactMaterialGrade.UltraRare, 0, MaterialInventory);
        //테스트


        //슬롯 추가하기


        //버튼 onclick에 함수 델리게이트 추가하기
        craftButton.onClick.AddListener(() => CraftArtifact());
        exitButton.onClick.AddListener(() => CloseCraftWidget());
        openButton.onClick.AddListener(() => OpenCraftWidget());
    }

    #region[Craft]
    private void CraftArtifact()
    {
        if(reqCondition == recipe.reqMaterials.Length)
        {
            artifactCount = resultArtifacts.Count;
            reqCondition = 0;
            for (int i = 0; i < recipe.reqMaterials.Length;i++)
            {
                Debug.Log("등급 :" + MaterialInventory[i].grade.ToString());
                RemoveDictionary(i, recipe.reqMaterials[i].count, MaterialInventory);
                RefreshSlot(i,recipe.reqMaterials[i].materialID.ToString(), recipe.reqMaterials[i].count, MaterialInventory[i].count);
            }
            resultArtifacts.Add(recipe.resultArtifact.artifact);
        }
        else
        {
            Debug.LogWarning("제작 불가능");
        }
    }
    #endregion

    #region [Dictionary_Function]
    private void AddDictionary(int itemID,ArtifactMaterialGrade grade ,int count, Dictionary<int, ArtifactMaterial> inventory)
    {
        if (inventory.ContainsKey(itemID))
        {
            inventory[itemID].count += count;
        }
        else
        {
            inventory.TryAdd(itemID,new ArtifactMaterial(grade,itemID.ToString(),0));
        }
    }
    private void RemoveDictionary(int itemID,int count, Dictionary<int, ArtifactMaterial> inventory)
    {
        if (inventory.ContainsKey(itemID))
        {
            inventory[itemID].count -= count;
        }
    }
    #endregion

    #region [Craft_UI]
    private void OpenCraftWidget()
    {
        craftWidget.SetActive(true);
        for (int i = 0; i < recipe.reqMaterials.Length; i++)
        {
            AddSlot(recipe.reqMaterials[i].materialID.ToString(), recipe.reqMaterials[i].count, MaterialInventory[i].count);
        }
    }
    private void CloseCraftWidget()
    {
        reqCondition = 0;
        for (int i = slots.Count-1; i > -1; i--)
        {
            Destroy(slots[i].gameObject);
            slots.Remove(slots[i]);
        }
        craftWidget.SetActive(false);
    }
    
    private List<GameObject> slots ;
    private void AddSlot(string artifactName,int requireCount,int holdedCount)
    {
        GameObject newSlot = Instantiate(slot, content.transform);
        slots.Add(newSlot);
        if (holdedCount>=requireCount)
        {
            reqCondition++;
            newSlot.GetComponent<Image>().color = new Color(0.749f, 0.580f, 0.894f, 1.0f);
        }
        newSlot.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = artifactName;
        newSlot.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "X{" + requireCount + "}";
        newSlot.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "X{" + holdedCount + "}";
        //newSlot.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "{" + holdingCount + "}";
    }
    private void RefreshSlot(int index,string artifactName, int requireCount, int holdedCount)
    {
        slots[index].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = artifactName;
        slots[index].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "X{" + requireCount + "}";
        slots[index].transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "X{" + holdedCount + "}";
        if (holdedCount >= requireCount)
        {
            reqCondition++;
            slots[index].GetComponent<Image>().color = new Color(0.749f, 0.580f, 0.894f, 1.0f);
        }
        else
        {
            slots[index].GetComponent<Image>().color = new Color(0.517f, 0.517f, 0.517f, 1.0f);
        }
        
    }
    #endregion
}
