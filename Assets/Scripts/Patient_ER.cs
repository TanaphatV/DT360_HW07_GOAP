using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patient_ER : GAgent
{
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        // Set up the subgoal "isWaiting"
        SubGoal s1 = new SubGoal("isWaiting", 1, true);
        // Add it to the goals
        goals.Add(s1, 3);

        // Set up the subgoal "isTreated"
        SubGoal s2 = new SubGoal("isTreated", 1, true);
        // Add it to the goals
        goals.Add(s2, 5);

        //Set up the subgoal "isHome"
        SubGoal s3 = new SubGoal("isHome", 1, true);
        //Add it to the goals
        goals.Add(s3, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
