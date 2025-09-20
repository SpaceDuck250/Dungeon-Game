using UnityEngine;
using UnityEngine.UI;

public class PlayerHand : MonoBehaviour
{
    public GameObject gun;

    public GameObject heldWeapon;
    public IWeapon weapon;

    public Transform container;
    public Transform itemPos;

    public GameObject[] inventoryItems = new GameObject[2]; // just for logic not for use
    public GameObject[] itemsObj = new GameObject[2]; // the actual for use weapons
    public GameObject slotTemplate;
    public Transform slotContainer;
    public float separation;

    public static PlayerHand instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        //SwitchWeapon(gun, 0);
        GenerateSlots();
        GenerateWeapons();
    }

    private void Update()
    {
        if (weapon != null)
        {
            weapon.Use();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetHeldWeapon(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetHeldWeapon(1);
        }
    }

    public void SetHeldWeapon(int index)
    {
        foreach (Transform child in container)
        {
            child.gameObject.SetActive(false);
        }

        itemsObj[index].SetActive(true);
        weapon = itemsObj[index].GetComponent<IWeapon>();
        Debug.Log(weapon);

    }

    public void SwitchWeapon(GameObject newWeaponObj, int index)
    {

        //heldWeapon = Instantiate(newWeaponObj, itemPos.position, Quaternion.identity, container);

        //weapon = heldWeapon.GetComponent<IWeapon>();
        heldWeapon = Instantiate(newWeaponObj, itemPos.position, Quaternion.identity, container);
        if (inventoryItems[index] != null)
        {
            Destroy(inventoryItems[index]);
        }
        inventoryItems[index] = heldWeapon;

    }

    public void GenerateWeapons()
    {
        ClearWeapon(container);

        for (int i = 0; i < 2; i++)
        {
            itemsObj[i] = Instantiate(inventoryItems[i], itemPos.position, Quaternion.identity, container);
            itemsObj[i].SetActive(false);

        }
    }

    public void GenerateSlots() // Generate the inventory slot with the weapons
    {
        ClearWeapon(slotContainer);

        for (int i = 0; i < 2; i++)
        {
            GameObject newSlot = Instantiate(slotTemplate, slotTemplate.transform.position, Quaternion.identity, slotContainer);
            newSlot.GetComponent<RectTransform>().position += new Vector3(i, 0, 0) * separation;

            newSlot.transform.Find("Item").GetComponent<Image>().sprite = inventoryItems[i].GetComponent<SpriteRenderer>().sprite;

        }
    }

    public void ClearWeapon(Transform container)
    {
        foreach (Transform child in container)
        {
            Destroy(child.gameObject);
        }
    }
}
