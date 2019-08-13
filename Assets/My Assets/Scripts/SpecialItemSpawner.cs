using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialItemSpawner : MonoBehaviour {

    public GameObject HUD;
    public GameObject SpecialItemPrefab;
    List<int> SpecialItems = new List<int>(){1,2,3,4,5,6,7,8,9,0};
    int SizeOfList;
    int RemainingItems;

    void Start()
    {
        RemainingItems = SpecialItems.Count;
        SizeOfList = SpecialItems.Count;
    }

    public void DecreaseItems()
    {
        RemainingItems--;
    }

    public int GetRemaingItems()
    {
        return RemainingItems;
    }
	// Update is called once per frame
    public void SpawnNextItem()
    {
        if (SizeOfList > 0)
        {
            
            PlayerController.ICoordinates Coord = new PlayerController.ICoordinates();
            int ItemIndex = SpecialItems[Random.Range(0, SpecialItems.Count - 1)];
            SpecialItems.Remove(ItemIndex);
            GameObject Item;
            switch (ItemIndex)
            {
                case 5:
                    Coord = PlayerController.GetItemCoordinates(1);
                    Item = Instantiate(SpecialItemPrefab, new Vector3(-Coord.x, Coord.y, gameObject.transform.position.z), Quaternion.identity);
                    Item.GetComponent<SpecialItem>().InitializeItem(ItemIndex, HUD.GetComponent<SpecialHUD>(), this.gameObject);
                    break;
                case 4:
                    Coord = PlayerController.GetItemCoordinates(2);
                    Item = Instantiate(SpecialItemPrefab, new Vector3(-Coord.x, Coord.y, gameObject.transform.position.z), Quaternion.identity);
                    Item.GetComponent<SpecialItem>().InitializeItem(ItemIndex, HUD.GetComponent<SpecialHUD>(), this.gameObject);
                    break;
                case 3:
                    Coord = PlayerController.GetItemCoordinates(3);
                    Item = Instantiate(SpecialItemPrefab, new Vector3(-Coord.x, Coord.y, gameObject.transform.position.z), Quaternion.identity);
                    Item.GetComponent<SpecialItem>().InitializeItem(ItemIndex, HUD.GetComponent<SpecialHUD>(), this.gameObject);
                    break;
                case 2:
                    Coord = PlayerController.GetItemCoordinates(4);
                    Item = Instantiate(SpecialItemPrefab, new Vector3(-Coord.x, Coord.y, gameObject.transform.position.z), Quaternion.identity);
                    Item.GetComponent<SpecialItem>().InitializeItem(ItemIndex, HUD.GetComponent<SpecialHUD>(), this.gameObject);
                    break;
                case 1:
                    Coord = PlayerController.GetItemCoordinates(5);
                    Item = Instantiate(SpecialItemPrefab, new Vector3(-Coord.x, Coord.y, gameObject.transform.position.z), Quaternion.identity);
                    Item.GetComponent<SpecialItem>().InitializeItem(ItemIndex, HUD.GetComponent<SpecialHUD>(), this.gameObject);
                    break;
                case 6:
                    Coord = PlayerController.GetItemCoordinates(1);
                    Item = Instantiate(SpecialItemPrefab, new Vector3(Coord.x, Coord.y, gameObject.transform.position.z), Quaternion.identity);
                    Item.GetComponent<SpecialItem>().InitializeItem(ItemIndex, HUD.GetComponent<SpecialHUD>(), this.gameObject);
                    break;
                case 7:
                    Coord = PlayerController.GetItemCoordinates(2);
                    Item = Instantiate(SpecialItemPrefab, new Vector3(Coord.x, Coord.y, gameObject.transform.position.z), Quaternion.identity);
                    Item.GetComponent<SpecialItem>().InitializeItem(ItemIndex, HUD.GetComponent<SpecialHUD>(), this.gameObject);
                    break;
                case 8:
                    Coord = PlayerController.GetItemCoordinates(3);
                    Item = Instantiate(SpecialItemPrefab, new Vector3(Coord.x, Coord.y, gameObject.transform.position.z), Quaternion.identity);
                    Item.GetComponent<SpecialItem>().InitializeItem(ItemIndex, HUD.GetComponent<SpecialHUD>(), this.gameObject);
                    break;
                case 9:
                    Coord = PlayerController.GetItemCoordinates(4);
                    Item = Instantiate(SpecialItemPrefab, new Vector3(Coord.x, Coord.y, gameObject.transform.position.z), Quaternion.identity);
                    Item.GetComponent<SpecialItem>().InitializeItem(ItemIndex, HUD.GetComponent<SpecialHUD>(), this.gameObject);
                    break;
                case 0:
                    Coord = PlayerController.GetItemCoordinates(5);
                    Item = Instantiate(SpecialItemPrefab, new Vector3(Coord.x, Coord.y, gameObject.transform.position.z), Quaternion.identity);
                    Item.GetComponent<SpecialItem>().InitializeItem(ItemIndex, HUD.GetComponent<SpecialHUD>(), this.gameObject);
                    break;
                default:
                    break;
            }
            SizeOfList--;
        }
    }
}
