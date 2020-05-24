using UnityEngine;
using UnityEngine.SceneManagement;

public class captureGem : MonoBehaviour
{
    public GemBar gemBar;
    public int maxScore = 5;
    public int currentScore = 0;
    public GameObject gemObject;
    public Vector2 initalPosition;
    float curTime = 0;
    float nextScore = 1;

    public GameObject collectPreFab;

    GameObject effect;
    void Start()
    {
        initalPosition.x = -6.5f;
        initalPosition.y = 6f;
        gemBar.setScore(currentScore);
        gemBar.setMaxScore(maxScore);
        gemObject.transform.position = initalPosition;
    }

    void Update()
    {
        curTime = 0;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            if (curTime <= 0)
            {
                addScore();
                curTime = nextScore;
                effect = Instantiate(collectPreFab ,other.gameObject.transform.position, Quaternion.identity);
                Invoke("destroyEffect", 1f);
                switch (currentScore)
                {
                    case 1:
                        //First Score
                        gemObject.transform.position = new Vector2(-11.3f, -3.4f);
                        break;
                    case 2:
                        //Second Score
                        gemObject.transform.position = new Vector2(0.6f, 1.85f);
                        break;
                    case 3:
                        //Third Score
                        gemObject.transform.position = new Vector2(-10f, 0f);
                        break;
                    case 4:
                        //Fourth Score
                        gemObject.transform.position = new Vector2(7.5f, -2.6f);
                        break;
                    case 5:
                        Destroy(gemObject);
                        break;
                    default:
                        Debug.Log("currentScore unknown value");
                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                        break;
                }
            }
        }

    }
    void addScore()
    {
        currentScore++;
        gemBar.setScore(currentScore);
    }

    private void destroyEffect() {
        Destroy(effect);
    }
}
