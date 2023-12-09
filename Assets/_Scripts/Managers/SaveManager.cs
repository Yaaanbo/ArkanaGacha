using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;

    [Header("Class References")]
    [SerializeField] private Inventory inventory;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }

    public void SaveGame()
    {
        ItemData itemData = new ItemData(inventory.UnlockedCharacters, inventory.UnlockedWeapons);

        string dataToSave = JsonUtility.ToJson(itemData);

        if(File.Exists(Application.persistentDataPath + "Item Data.json"))
        {

            File.WriteAllText(Application.dataPath + "Item Data.json", dataToSave);
        }
        else
        {
            File.WriteAllText(Application.dataPath + "Item Data.json", dataToSave);
        }

        Debug.Log(Application.persistentDataPath);
    }

    public List<CharacterScriptable> LoadCharacters()
    {
        string loadData = File.ReadAllText(Application.dataPath + "Item Data.json");
        var data = JsonUtility.FromJson<ItemData>(loadData);

        return data.characterList;
    }

    public List<WeaponScriptable> LoadWeapons()
    {
        string loadData = File.ReadAllText(Application.dataPath + "Item Data.json");
        var data = JsonUtility.FromJson<ItemData>(loadData);

        return data.weaponList;
    }

}

public class ItemData
{
    public List<CharacterScriptable> characterList = new List<CharacterScriptable>();
    public List<WeaponScriptable> weaponList = new List<WeaponScriptable>();

    public ItemData(List<CharacterScriptable> _characters, List<WeaponScriptable> _weaponList)
    {
        characterList = _characters;
        weaponList = _weaponList;
    }
}
