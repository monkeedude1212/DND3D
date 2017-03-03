using System.Collections;
using System.Collections.Generic;

public class Race {

    // This class is to define the character's race
    // There can be many different races in D&D, including sub-races
    // This list should be expandable
    // Maybe Race should be an abstract class? Probably a reasonable approach

    private bool isInitialized;
    private string raceName;

    // This probably shouldn't be defined as an array, but it's 
    // probably okay for now. 
    private int[] bonusAttributes;

    // We don't have these things defined yet, but they will become necessary 
    // private Ability raceAbility;
    // private Trait raceTrait;

    public Race()
    {
        // Right now, the only race is human
        raceName = "Human";

        // Humans get +1 to all attributes in 5e
        // 
        bonusAttributes = new int[6];
        for (int i = 0; i < bonusAttributes.Length; i++)
        {
            bonusAttributes[i] = 1;
        }
    }
}
