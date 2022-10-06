using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

public class Bubble : MonoBehaviour
{
    [SerializeField]
    List<Material> colors;
    public int colorNumber;
    public bool willpop = false;

private void Awake()
    {
        colorNumber = Random.Range(0, 5);
        assignColor(colorNumber);
    }
    void Start()
    {

    }

    public void OnMouseDown()
    {
        markToPop();
        popMarked();
	}

    void assignColor(int color)
    {
        gameObject.GetComponent<MeshRenderer>().material = colors[color];

    }

    protected virtual void pop()
    {
		var manager = GameObject.FindGameObjectWithTag("GameController");
        manager.GetComponent<GameManager>().addscore(1);
		Destroy(gameObject);
	}
    protected void popMarked()
    {
        int popcount = 0;
		var allBubbles = GameObject.FindGameObjectsWithTag("bubble");
		foreach (var bubble in allBubbles)
		{
			if (bubble.GetComponent<Bubble>().willpop)
			{
				//Abstraction
				bubble.GetComponent<Bubble>().pop();
                popcount++;
			}
		}

        var manager = GameObject.FindGameObjectWithTag("GameController");
        manager.GetComponent<GameManager>().reloadBubbles(popcount);
	}


    virtual protected void markToPop()
    {
		var allBubbles = GameObject.FindGameObjectsWithTag("bubble");
        foreach (var bubble in allBubbles)
        {
            if (bubble.GetComponent<Bubble>().colorNumber == colorNumber
            && Mathf.Abs((gameObject.transform.position - bubble.transform.position).magnitude) < 1.1
            && bubble.GetComponent<Bubble>().willpop == false)
            {
                bubble.GetComponent<Bubble>().willpop = true;
                bubble.GetComponent<Bubble>().markToPop();            
            }
		}
	}

}
