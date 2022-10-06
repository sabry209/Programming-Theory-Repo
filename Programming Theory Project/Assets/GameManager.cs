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
    private int score;
 
    // Start is called before the first frame update
    void Start()
    {
        reloadBubbles(TotalBubbles);
        spawnPowerBubble(3);

	}

    public void addscore(int points)
    {
        score += points;
        scoreText.text = "SCORE \n" + score;

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
