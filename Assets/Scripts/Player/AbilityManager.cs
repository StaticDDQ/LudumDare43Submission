using UnityEngine;

public class AbilityManager : MonoBehaviour {

    public SubGrade currAbility;
		
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

    public void AssignNewAbility(SubGrade newAbility)
    {
        if(currAbility != null)
        {
            currAbility.RemoveAbility();
        }

        currAbility = newAbility;

        currAbility.GainAbility();
    }
}
