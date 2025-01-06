using System.Collections.Generic;

public class Player: BaseEntity
{
    private int curExp;
    private int maxExp;
    
    // TODO: 소지하고 있는 소재 리스트추가
    
    private List<Artifact> artifacts;
    
    private CharacterClass characterClass;
}
