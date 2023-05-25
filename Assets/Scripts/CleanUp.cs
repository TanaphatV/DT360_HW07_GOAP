using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanUp : GAction
{
    public override bool PrePerform()
    {
        target = GWorld.Instance.RemoveDead();
        if (target == null)
            return false;
        return true;
    }

    public override bool PostPerform()
    {
        GWorld.Instance.GetWorld().ModifyState("Dead", -1);
        Destroy(target.gameObject);
        beliefs.ModifyState("exhausted", 0);
        return true;
    }
}
