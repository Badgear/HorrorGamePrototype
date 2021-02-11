using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    List<Item> item;
    public float itemDistance = 10f;
    public GameObject cellContainer;
    public KeyCode showInventory;
    public KeyCode takeButton;

    public GameObject messageManager;
    public GameObject message;
    // Start is called before the first frame update
    void Start()
    {
        item = new List<Item>();

        cellContainer.SetActive(false);

        for (int i = 0; i < cellContainer.transform.childCount; i++)
        {
            item.Add(new Item());
        }
    }

    // Update is called once per frame
    void Update()
    {
        ToggleInventory();
        if (Input.GetKeyDown(takeButton))
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, itemDistance))
            {
                if (hit.collider.TryGetComponent(out Item currentItem))
                {
                    MessedgeSpawn(currentItem);
                    AddItem(currentItem); 
                }
            }
        }
    }

    void MessedgeSpawn(Item currentItem)
    {
        GameObject msgObj = Instantiate(message);
        msgObj.transform.SetParent(messageManager.transform);

        Image msgImg = msgObj.transform.GetChild(0).GetComponent<Image>();
        msgImg.sprite = Resources.Load<Sprite>(currentItem.pathIcon);

        Text msgTxt = msgObj.transform.GetChild(1).GetComponent<Text>();
        msgTxt.text = currentItem.nameItem;

    }

    void AddItem(Item currentItem)
    {
        if (currentItem.isStackable)
        {
            AddStackableItem(currentItem);
        }
        else 
        {
            AddUnstackableItem(currentItem);
        }
    }

    void AddUnstackableItem(Item currentItem)
    {
        {
            for (int i = 0; i < item.Count; i++)
            {
                if (item[i].id == 0)
                {
                    item[i] = currentItem;
                    item[i].countItem = 1;
                    DisplayItems();
                    Destroy(currentItem.gameObject);
                    break;
                }
            }
        }
    }

    void AddStackableItem(Item currentItem)
    {
        for (int i = 0; i < item.Count; i++)
        {
            if (item[i].id == currentItem.id) 
            {
                item[i].countItem++;
                DisplayItems();
                Destroy(currentItem.gameObject);
                return;
            }
        }
        AddUnstackableItem(currentItem);
    }


    void ToggleInventory()
    {
        if (Input.GetKeyDown(showInventory))
        {
            if (cellContainer.activeSelf)
            {
                cellContainer.SetActive(false);
            }
            else
            {
                cellContainer.SetActive(true);
            }
        }
    }

    void DisplayItems()
    {
        for (int i = 0; i < item.Count; i++)
        {
            Transform cell = cellContainer.transform.GetChild(i);
            Transform icon = cell.GetChild(0);
            Transform count = icon.GetChild(0);
            Text txt = count.GetComponent<Text>();
            Image img = icon.GetComponent<Image>();
            if (item[i].id != 0)
            {
                             img.enabled = true;
                img.sprite = Resources.Load<Sprite>(item[i].pathIcon);
                if (item[i].countItem > 1)
                {
                    txt.text = item[i].countItem.ToString();
                }
                
            }
            else
            {
                img.enabled = false;
                img.sprite = null;
                txt.text = null;
            }
                }
            }
        }
    

