using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Omni : Bubble
{
    // Start is called before the first frame update
    void Start()
    {
		gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();

	}

	// Update is called once per frame
	void Update()
    {
        
    }

	protected override void pop()
	{
		markToPop();
		Destroy(gameObject);
	}
	protected override void markToPop()
    {
        {
            var allBubbles = GameObject.FindGameObjectsWithTag("bubble");
            foreach (var bubble in allBubbles)
            {
                if (Mathf.Abs((gameObject.transform.position - bubble.transform.position).magnitude) < 2.5)
                {
                    bubble.GetComponent<Bubble>().willpop = true;
                }
            }
        }
    }
}
