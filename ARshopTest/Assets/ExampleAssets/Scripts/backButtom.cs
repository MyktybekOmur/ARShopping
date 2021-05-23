using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class backButtom : MonoBehaviour
{
    // Start is called before the first frame update
    private Button button;
   

    // Start is called before the first frame update
    void Start()
    {
        

        button = GetComponent<Button>();
        button.onClick.AddListener(backButton);
    }

    // Update is called once per frame
    void backButton()
    {
        SceneManager.LoadScene(0);
    }
}
