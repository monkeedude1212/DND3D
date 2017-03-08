using System.Collections;
using System.Collections.Generic;

public class Human : Race {

    public override string raceName()
    {
        return "Human";
    }

    Human()
    {
        base.bonusAttributes = new int[6];

        for (int i = 0; i < 6; i++)
        {
            base.bonusAttributes[i] = 1;
        }
    }
}
