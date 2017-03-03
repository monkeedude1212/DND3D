using System.Collections;
using System.Collections.Generic;

public class Race {

    // This class is to define the character's race
    // There can be many different races in D&D, including sub-races
    // This list should be expandable

    private bool isInitialized;
    private string raceName;
    private int[] bonusAttributes;

    // private Ability raceAbility;
    // private Trait raceTrait;
    public Race()
    {
        // Right now, the only race is human
        raceName = "Human";

        // Humans get +1 to all attributes in 5e
        bonusAttributes = new int[6];
        for (int i = 0; i < bonusAttributes.Length; i++)
        {
            bonusAttributes[i] = 1;
        }
    }
}
