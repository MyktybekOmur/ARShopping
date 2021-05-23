using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scaleCh : MonoBehaviour
{
    
	public Button smallBtn,normalBtn,largeBtn;
	public GameObject obj,b;
	public Vector3 small;
	Vector3 newVector3 = new Vector3(-0.2f, -0.2f, -0.2f);
	private int itemIndex1;
	void Start()
	{
		Button smallbtn = smallBtn.GetComponent<Button>();

		

		smallbtn.onClick.AddListener(delegate { TaskOnClick(small); });
		//normalbtn.onClick.AddListener(delegate { TaskOnClick(ProgrammManager.item[itemSelect.isSelectItem].normal); });
		//largebtn.onClick.AddListener(delegate { TaskOnClick(ProgrammManager.item[itemSelect.isSelectItem].large); });
	}
	void Update()
    {
		//transform.localScale += new Vector3(1, 1, 1);
	}

	 void TaskOnClick(Vector3 scale)
	{
		Debug.Log(scale);
	   obj.transform.localScale = scale;
	}
}
