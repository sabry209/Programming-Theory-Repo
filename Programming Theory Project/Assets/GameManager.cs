using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameManager : MonoBehaviour
{
    [SerializeField]
    private int TotalBubbles;
    [SerializeField]
    private GameObject BubblePrefab;
    public List<GameObject> popList;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnBubbles(TotalBubbles));

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void randomBubble()
    {
        GameObject bubble = Instantiate(BubblePrefab,gameObject.transform);
        float xpos = Random.Range(-2,2);
        bubble.transform.position = new Vector3(xpos, 10, 0);

    }

    IEnumerator spawnBubbles(int number)
    {
        for(int i = 0; i < number; i++)
        {
            randomBubble();
            yield return new WaitForSeconds(0.05f);
        }
    }

    int countBubbles()
    {
        var getCount = GameObject.FindGameObjectsWithTag("bubble");
        int count = getCount.Length;
        return count;
    }
}
