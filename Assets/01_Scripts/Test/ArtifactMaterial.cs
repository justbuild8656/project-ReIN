public enum ArtifactMaterialID
{
    Gold = 0,
    MagicBook01 = 1,
    Ruby = 2,
    Diamond = 3,
}
public enum ArtifactMaterialGrade
{
    UltraRare,
    SuperRare,
    Rare,
    UnCommon,
    Common,
}

public class ArtifactMaterial
{
    public ArtifactMaterialGrade grade;
    public string name;
    public int count;
    public ArtifactMaterial(ArtifactMaterialGrade _grade, string _name, int _count)
    {
        this.grade = _grade;
        this.name = _name;
        this.count = _count;
    }
}