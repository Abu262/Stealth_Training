using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartAndExit : MonoBehaviour
{
    public bool IsExitBtn;
    public int SceneToLoad;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void TaskOnClick()
    {
        //Output this to console when Button1 or Button3 is clicked
        Debug.Log("You have clicked the button!");
        if (IsExitBtn)
        {
            Application.Quit();
        }
        else
        {
            SceneManager.LoadScene(SceneToLoad);
        }
        

    }

    // Update is called once per frame
    void Update()
    {



    }
}
