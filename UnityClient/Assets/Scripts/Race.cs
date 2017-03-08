using System.Collections;
using System.Collections.Generic;

public abstract class Race {

    // This class is to define the character's race
    // There can be many different races in D&D, including sub-races
    // This list should be expandable
    // Maybe Race should be an abstract class? Probably a reasonable approach

    public abstract string raceName();

    // This probably shouldn't be defined as an array, but it's 
    // probably okay for now. 
    protected int[] bonusAttributes;

    enum Size { Fine, Diminutive, Tiny, Small, Medium, Large, Huge, Gargantuan, Colossal};

    // We don't have these things defined yet, but they will become necessary 
    // private Ability[] raceAbilities;
    // private Trait[] raceTraits;


}
