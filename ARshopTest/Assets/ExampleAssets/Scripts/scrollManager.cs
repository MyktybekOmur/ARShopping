using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

//Button listener
public static class ButtonExtension
{
	public static void AddEventListener<T>(this Button button, T param, Action<T> OnClick)
	{
		button.onClick.AddListener(delegate () {
			OnClick(param);
		});
	}
}

public class scrollManager : MonoBehaviour
{
	//List cotent
	[Serializable]
	public struct item
	{
		public int ID;
		public string Name;
		public string explainObj;
		public Sprite Icon;
		public int typeItem;
	}

	[SerializeField] item[] allItem;

	

	void Start()
	{
		GameObject itemPrefab = transform.GetChild(0).gameObject;
		GameObject g;

		int N = allItem.Length;//item length
		//Add Item
		for (int i = 0; i < N; i++)
		{
			g = Instantiate(itemPrefab, transform);
			g.transform.GetChild(0).GetComponent<Image>().sprite = allItem[i].Icon;
			g.transform.GetChild(1).GetComponent<Text>().text = allItem[i].Name;
			
			g.GetComponent<Button>().AddEventListener(allItem[i].ID, ItemClicked);
		}

		Destroy(itemPrefab);
	}
	//Open 2nd scene
	void ItemClicked(int itemIndex)
	{
		itemSelect.isSelectItem = itemIndex;//set item id
	
		Debug.Log("------------item " + itemIndex + " clicked---------------"+ allItem[itemIndex].typeItem);
       
		if (allItem[itemIndex].typeItem == 0)
        {
			SceneManager.LoadScene(1);
        }
        else
        {
			SceneManager.LoadScene(2);
		}
		

	}
}