using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SetMission : MonoBehaviour
{
    public TMPro.TMP_Dropdown missionsdd;
    public Button startbtn;
    public int i;
    // Start is called before the first frame update
    void Start()
    {
        
        startbtn.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void callmission()
    {
        SceneManager.LoadScene(missionsdd.value + 1);
    }
    void TaskOnClick()
    {
        SceneManager.LoadScene(missionsdd.value + 1);
    }
}
