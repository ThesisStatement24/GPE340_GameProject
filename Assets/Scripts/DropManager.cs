using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DropItem
{

    public GameObject itemToDrop;
    public float dropWeight;

}

public class DropManager : MonoBehaviour
{

    public List<DropItem> dropTable;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject DropItem() 
    {

        // Create our CDF Array
        List<float> CDFArray = new List<float>();

        // For each element in our drop table, fill in the cumulative density in the CDF array
        float runningTotal = 0;
        foreach (DropItem item in dropTable)
        {
            // Update the running total by adding the newest dropweight
            runningTotal = runningTotal + item.dropWeight;
            // Add it to the CDF Array
            CDFArray.Add(runningTotal);

        }

        // Choose a random number < our total density
        float randomNumber = UnityEngine.Random.Range(0, runningTotal);

        // Go through our CDF array, one value at a time.
        for (int index = 0; index < CDFArray.Count; index++)
        {
            // if our random number is < the density at that point
            if (randomNumber < CDFArray[index])
            {
                // Return the item at the same (parallel) point
                return dropTable[index].itemToDrop;
            }
        }


        // If, for some crazy reason that is mathematicall impossible, we get here, return null
        Debug.LogError("ERROR: Random number exceeded CDFArray values");
        return null;
        
    }

}
