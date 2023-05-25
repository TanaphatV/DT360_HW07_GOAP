using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Patient : GAgent {
    bool dead = false;
    new void Start() {

        // Call the base start
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

    private void Update()
    {
        Collider[] col = Physics.OverlapSphere(transform.position, 1);
        foreach(Collider c in col)
        {
            if(c.gameObject.CompareTag("Home"))
            {
                Destroy(gameObject);
            }

            if (c.gameObject.CompareTag("DieSpot") && !dead)
            {
                Invoke("Die", Random.Range(1.0f, 4.0f));
                dead = true;
            }
        }
    }

    void Die()
    {
        if(Random.Range(0,100) < 20)//10% chance to die
        {
            GetComponent<NavMeshAgent>().enabled = false;
            GWorld.Instance.GetWorld().ModifyState("Dead", 1);
            GWorld.Instance.AddDead(this.gameObject);
            gameObject.transform.Rotate(new Vector3(90, 0, 0));
        }
    }

}