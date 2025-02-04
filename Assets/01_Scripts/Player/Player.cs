using System;
using System.Collections.Generic;
using UnityEngine;

public class Player: BaseEntity
{
    private int curExp;
    private int maxExp;

    // TODO: 소지하고 있는 소재 리스트추가

    [SerializeField] List<Artifact> artifacts;
    private CharacterClass characterClass;
}
