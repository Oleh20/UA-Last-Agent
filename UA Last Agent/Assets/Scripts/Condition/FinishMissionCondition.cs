using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class FinishMissionCondition : Condition
{

    public override bool FinishMission
    {
        get { return endMission; }
        set { endMission = value; }
    }

    public bool endMission;

    public override bool CheckCondition()
    {
        return FinishMission;
    }

}
