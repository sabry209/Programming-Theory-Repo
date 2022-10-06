using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameManager : MonoBehaviour
{
    //encapsulation
    [SerializeField]
    private int TotalBubbles;
    [SerializeField]
    private GameObject BubblePrefab;
    [SerializeField]
    private List<GameObject> powerups;
    [SerializeField]
    private TMPro.TextMeshProUGUI scoreText;
    [SerializeField]
    private TMPro.TextMeshProUGUI movesText;
    [SerializeField]
    private TMPro.TextMeshProUGUI gameovertext;
    private int score = 0;
    public int moves { get;  private set; }
 
    // Start is called before the first frame update
    void Start()
    {
        reloadBubbles(TotalBubbles);
        spawnPowerBubble(1);
        moves = 10;
        score = 0;
		scoreText.text = "SCORE \n" + score;
		movesText.text = "MOVES \n" + moves;

	}

    public void move()
    {
        moves -= 1;
		movesText.text = "MOVES \n" + moves;
        if(moves == 0)
        {
            GameOver();
        }
	}

    private void GameOver()
    {
        gameovertext.gameObject.SetActive(true);
	}
	public void addscore()
    {
        score += 1;
        scoreText.text = "SCORE \n" + score;
        //spawn powerup every 50 points
        if(score%50 ==0)
        {
            spawnPowerBubble(1);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void spawnPowerBubble(int number)
    {
        for (int i = 0; i < number; i++)
        {
			int n = Random.Range(0, 2);
			GameObject rowBubble = Instantiate(powerups[n], gameObject.transform);
			float xpos = Random.Range(-3, 3);
			rowBubble.transform.position = new Vector3(xpos, 11, 0);
		}

	}

    public void reloadBubbles(int num)
    {
        StartCoroutine(spawnBubbles(num));
    }
    void randomBubble()
    {
        GameObject bubble = Instantiate(BubblePrefab,gameObject.transform);
        float xpos = Random.Range(-3,3);
        bubble.transform.position = new Vector3(xpos, 11, 0);

    }

    IEnumerator spawnBubbles(int number)
    {
        for(int i = 0; i < number; i++)
        {
            randomBubble();
            yield return new WaitForSeconds(1.5f/number);
        }
    }

    int countBubbles()
    {
        var getCount = GameObject.FindGameObjectsWithTag("bubble");
        int count = getCount.Length;
        return count;
    }
}
