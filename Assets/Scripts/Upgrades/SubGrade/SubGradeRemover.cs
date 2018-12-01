
public class SubGradeRemover : SubGrade {

    public override void GainAbility()
    {
        Destroy(this);
    }

    public override void RemoveAbility()
    {
        Destroy(this);
    }

    public override void UseAbility()
    {
        Destroy(this);
    }
}
