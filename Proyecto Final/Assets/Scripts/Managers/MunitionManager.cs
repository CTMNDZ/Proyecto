using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MunitionManager : MonoBehaviour
{
   
    [SerializeField] GameObject[] munitions;

    [SerializeField] Transform playerHand;
    // Start is called before the first frame update

    [SerializeField] List<GameObject> munitionList;
    public List<GameObject> MunitionList { get => munitionList; set => munitionList = value; }
    public Dictionary<string, GameObject> MunitionDirectory { get => munitionDirectory; set => munitionDirectory = value; }

    private Dictionary<string, GameObject> munitionDirectory;

    void Start()
    {
        munitionList = new List<GameObject>();
        munitionDirectory = new Dictionary<string, GameObject>();
    }
    void DiseableAllWeapons()
    {

        for (int i = 0; i < munitions.Length; i++)
        {
            munitions[i].SetActive(false); // 0 -> Weapon A  1->WB / 2 -> WC
        }
    }


    void EnableAllWeapon()
    {
        foreach (GameObject munition in munitionList)
        {
            munition.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2)) EquipMunition(munitionDirectory["MunitionA"]);
        if (Input.GetKeyDown(KeyCode.Alpha3)) EquipMunition(munitionDirectory["MunitionB"]);
    }

    private void EquipMunition(GameObject munition)
    {
        DetachMunitions();
        munition.SetActive(true);
        munition.transform.parent = playerHand;
        munition.transform.localPosition = Vector3.zero;
    }

     private void DetachMunitions()
    {
        //foreach para recorrer todos los hijos.
        foreach (Transform child in playerHand)
        {
            child.parent = null;
            child.transform.position = new Vector3(Random.Range(0f,3f), 1f,Random.Range(0f,3f));
            child.gameObject.SetActive(true);
        }
    }
}
