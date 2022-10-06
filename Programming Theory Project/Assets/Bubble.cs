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
    List<GameObject> currentCollisions = new List<GameObject>();
    private GameManager manager;
    public bool willpop = false;

private void Awake()
    {
        colorNumber = Random.Range(0, 3);
        assignColor(colorNumber);
    }
    void Start()
    {
        manager = FindObjectOfType<GameManager>();
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
    void popMarked()
    {
		var allBubbles = GameObject.FindGameObjectsWithTag("bubble");
		foreach (var bubble in allBubbles)
		{
			if (bubble.GetComponent<Bubble>().willpop)
			{
                Destroy(bubble);
			}
		}
	}

    void markToPop()
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
