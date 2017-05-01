using System.Collections;
using System.Collections.Generic;

public class Human : Race {

    // Abstract class? Not certain this is the best way of doing this
    public override string raceName()
    {
        return "Human";
    }

    // Constructor for race Human
    Human()
    {
        // Humans get +1 to all attributes
        base.bonusAttributes = new int[6];

        for (int i = 0; i < 6; i++)
        {
            base.bonusAttributes[i] = 1;
        }

        // Humans are medium sized
        base.raceSize = Size.Medium;

        // Their base movement rate is 30ft / round
        base.raceSpeed = 30;
    }
}
