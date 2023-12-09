using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using TMPro;

public class Inventory : MonoBehaviour
{
    [Header("Class References")]
    [SerializeField] private GachaManager gachaManager;

    [Header("Item Inventory")]
    [SerializeField] private Transform itemContentParent;
    [SerializeField] private GameObject itemContent;
    private List<CharacterScriptable> unlockedCharacters = new List<CharacterScriptable>();
    private List<WeaponScriptable> unlockedWeapons = new List<WeaponScriptable>();

    public List<CharacterScriptable> UnlockedCharacters { get { return unlockedCharacters; } }
    public List<WeaponScriptable> UnlockedWeapons { get { return unlockedWeapons; } }

    [Header("Events")]
    public Action<CharacterScriptable> OnCharaPressed;
    public Action<WeaponScriptable> OnWeapPressed;

    private void OnEnable()
    {
        gachaManager.OnCharacterDropped += (CharacterScriptable _charaToAdd) =>
        {
            unlockedCharacters.Add(_charaToAdd);
        };
        gachaManager.OnWeaponsDropped += (WeaponScriptable _weapToAdd) =>
        {
            unlockedWeapons.Add(_weapToAdd);
        };
    }

    private void OnDisable()
    {
        gachaManager.OnCharacterDropped += (CharacterScriptable _charaToAdd) =>
        {
            unlockedCharacters.Add(_charaToAdd);
        };
        gachaManager.OnWeaponsDropped += (WeaponScriptable _weapToAdd) =>
        {
            unlockedWeapons.Add(_weapToAdd);
        };
    }

    private void Start()
    {
        if (!File.Exists(Application.persistentDataPath + "Item Data.json")) return;

        unlockedCharacters = SaveManager.instance.LoadCharacters();
        unlockedWeapons = SaveManager.instance.LoadWeapons();
    }

    public void OpenInventory(bool _isOpeningCharInv)
    {
        foreach(Transform child in itemContentParent)
        {
            Destroy(child.gameObject);
        }

        if (_isOpeningCharInv)
        {
            foreach (CharacterScriptable chara in unlockedCharacters)
            {
                GameObject charaInvGO = Instantiate(itemContent, itemContentParent);
                Image charaImg = charaInvGO.transform.Find("ItemImage").GetComponent<Image>();
                TextMeshProUGUI charaName = charaInvGO.transform.Find("ItemName").GetComponent<TextMeshProUGUI>();
                
                charaImg.sprite = chara.characterSprite;
                charaName.text = chara.characterName;
                charaInvGO.GetComponent<ItemIdentifier>().ItemType = chara;
                charaInvGO.GetComponent<Button>().onClick.AddListener(() => { OnCharaPressed?.Invoke(chara); });
            }
        }
        else
        {
            foreach (WeaponScriptable weap in unlockedWeapons)
            {
                GameObject weapInvGO = Instantiate(itemContent, itemContentParent);
                Image weapImg = weapInvGO.transform.Find("ItemImage").GetComponent<Image>();
                TextMeshProUGUI weapName = weapInvGO.transform.Find("ItemName").GetComponent<TextMeshProUGUI>();

                weapImg.sprite = weap.weaponSprite;
                weapName.text = weap.weaponName;
                weapInvGO.GetComponent<ItemIdentifier>().ItemType = weap;
                weapInvGO.GetComponent<Button>().onClick.AddListener(() => { OnWeapPressed?.Invoke(weap); });
            }
        }
    }
}