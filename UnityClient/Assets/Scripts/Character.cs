﻿using System.Collections;
using System.Collections.Generic;

public class Character{

    // These are the basic attributes
    public int strength { get; protected set; }
    public int dexterity { get; protected set; }
    public int constitution { get; protected set; }
    public int intelligence { get; protected set; }
    public int wisdom { get; protected set; }
    public int charisma { get; protected set; }

    // These are the numbers that actually matter, derived from
    // the attributes
    public int strMod { get; private set; }
    public int dexMod { get; private set; }
    public int conMod { get; private set; }
    public int intMod { get; private set; }
    public int wisMod { get; private set; }
    public int chaMod { get; private set; }

    // This is the value of maximum possible hit points. This should be
    // replaced by a dedicated hit point interface later on
    public int maxHitPoints { get; private set; }

    public int playerLevel { get; private set; }

    public bool hasInspiration { get; private set; }
    // Use this for initialization
    void Start () {
        // This is how modifiers are calculated from attruibutes
        // They should probably have an "update" function
		strMod = (int) (((float)strength / 2.0) - 5.0);
        dexMod = (int) (((float)dexterity / 2.0) - 5.0);
        conMod = (int) (((float)constitution / 2.0) - 5.0);
        intMod = (int) (((float)intelligence / 2.0) - 5.0);
        wisMod = (int) (((float)wisdom / 2.0) - 5.0);
        chaMod = (int) (((float)charisma/ 2.0) - 5.0);
        
        maxHitPoints = (8 + chaMod) * playerLevel;
    }
	
}
