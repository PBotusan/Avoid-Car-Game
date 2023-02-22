using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_StartGame : MonoBehaviour
{
    //used for score in the future/ maybe
  //  GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
       // GameObject gameManagerAsGameobject = GameObject.FindGameObjectWithTag("GameManager");
      //  gameManager = gameManagerAsGameobject.GetComponent<GameManager>();
    }


    public void StartTheGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
