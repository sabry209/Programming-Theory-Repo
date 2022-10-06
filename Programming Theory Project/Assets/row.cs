using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//inheritance
public class row : Bubble
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	protected override void pop()
	{
		markToPop();
		//popMarked();
		Destroy(gameObject);
	}
	//polymorphism
	protected override void markToPop()
    {
		var allBubbles = GameObject.FindGameObjectsWithTag("bubble");
		foreach (var bubble in allBubbles)
		{
			if (Mathf.Abs(bubble.transform.position.y - gameObject.transform.position.y) < 0.5)
			{
				bubble.GetComponent<Bubble>().willpop = true;
			}
		}
	}
}
