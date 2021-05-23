using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sizeMenu : MonoBehaviour
{
	public Button sizeChBtn;
	public Image buttons;
	Image btns;
	int contr=0;
	void Start()
	{
		Button btn = sizeChBtn.GetComponent<Button>();
	    btns = buttons.GetComponent<Image>();
		btns.gameObject.SetActive(false);
		btn.onClick.AddListener(TaskOnClick);
	}

	public void TaskOnClick()
	{
        if (contr == 0)
        {
			btns.gameObject.SetActive(true);
			contr = 1;
        }
        else
        {
			btns.gameObject.SetActive(false);
			contr = 0;
		}
	}
}
