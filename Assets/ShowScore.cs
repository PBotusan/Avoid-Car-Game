using TMPro;
using UnityEngine;

public class ShowScore : MonoBehaviour
{

    public TextMeshProUGUI score;

    float scoreAmount;


    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        GameObject gamemanagerAsGameobject = GameObject.FindGameObjectWithTag("GameManager");
        gameManager = gamemanagerAsGameobject.GetComponent<GameManager>();
    }

    private void Update()
    {
        UpdateScore();
    }

    //score system with extra stuff and collect points


    // Update is called once per frame
    public void UpdateScore()
    {
        scoreAmount += Time.deltaTime;

        score.text = "Time escaped:  " + ((int)scoreAmount);
        // score.text = "Cars Passed" + gameManager.currentScore.ToString();
    }
}
