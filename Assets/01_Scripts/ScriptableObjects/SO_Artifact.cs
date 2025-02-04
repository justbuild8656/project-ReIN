using JetBrains.Annotations;
using UnityEngine;
public enum RegionType
{
    Accessories,
    Arm,
    Leg,
}
[System.Serializable]
public class WeightSetting
{
    [Header("[Artifact Weight Value]")]
    public int strengthWeight;
    public int intellectWeight;
    public int solidityWeight;
    public int enduranceWeight;
    public int intuitionWeight;
}
[System.Serializable]
public struct ArtifactInfo
{
    [Header("[Artifact Info]")]
    public string name;
    [TextArea]
    public string artifactInfo;
}
[CreateAssetMenu(fileName = "Artifact", menuName = "Scriptable Objects/ArtifactData")]
public class SO_Artifact : ScriptableObject
{
    [Header("[Region Type]")]
    public RegionType regionType;

    public ArtifactInfo artifactInfo;

    public WeightSetting weightSetting;

    [Header("[Ability]")]
    public SO_Ability artifactAbility;
    private void OnEnable()
    {
        OnReset();
    }
    //������ �����ؼ� ����ȭ�� ������ Ȥ�� �̻� ���� ����� ���� �����Լ�(�ϴ� 0���� ����)
    private void OnReset()
    {
        weightSetting.strengthWeight = 0;
        weightSetting.intellectWeight = 0;
        weightSetting.solidityWeight = 0;
        weightSetting.enduranceWeight = 0;
        weightSetting.intuitionWeight = 0;
    }
    public SO_Artifact Clone()
    {
        SO_Artifact data = CreateInstance<SO_Artifact>();
        data.regionType = this.regionType;
        data.weightSetting = this.weightSetting;
        data.artifactAbility = this.artifactAbility;
        return data;
    }
}
