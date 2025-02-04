using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public struct ResultArtifactInfo
{
    [Header("[Result Artifact]")]
    public SO_Artifact artifact;
    public int count;
}

[System.Serializable]
public struct RequireMateiralInfo
{
    public ArtifactMaterialID materialID;
    //Todo : ��� Ŭ���� �ʿ�
    public int count;
}
[CreateAssetMenu(fileName = "SO_ArtifactRecipe", menuName = "Scriptable Objects/ArtifactRecipe")]
public class SO_ArtifactRecipe : ScriptableObject
{
    [SerializeField] public ResultArtifactInfo resultArtifact;
    [Header("[Require Materials]")]
    [SerializeField] public RequireMateiralInfo[] reqMaterials;
}
