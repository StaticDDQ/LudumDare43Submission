using UnityEngine;

public class AbilityManager : MonoBehaviour {

    private SubGrade currAbility;
		
	// Update is called once per frame
	private void Update () {
        if (Input.GetKeyDown(KeyCode.E))
        {
            PerformAbility();
        }
	}

    private void PerformAbility()
    {
        if(currAbility != null)
        {
            currAbility.UseAbility();
        }
    }

    private void AssignNewAbility(SubGrade newAbility)
    {
        if(currAbility != null)
        {
            currAbility.RemoveAbility();
        }

        currAbility = newAbility;

        currAbility.GainAbility();
    }
}
