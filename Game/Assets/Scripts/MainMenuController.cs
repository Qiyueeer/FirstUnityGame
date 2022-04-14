
using UnityEngine;

using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //GameObject.Find("start").GetComponent<Button>().onClick.AddListener(playGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void playGame()
    {
        SceneManager.LoadScene("MainScene"); //this will have the name of your main game scene
        Debug.Log("Click");

    }
    public void restart()
    {
        SceneManager.LoadScene("StartMenu"); //this will have the name of your main menu scene
    }
    public void exitGame()
    {
        Application.Quit();
    }

}
