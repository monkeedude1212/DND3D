using System.Collections;
using System.Collections.Generic;

public class Character{

    // These are the basic attributes
    private int strength = 10;
    private int dexterity = 10;
    private int constitution = 10;
    private int intelligence = 10;
    private int wisdom = 10;
    private int charisma = 10;

    // These are the numbers that actually matter, derived from
    // the attributes
    private int strMod;
    private int dexMod;
    private int conMod;
    private int intMod;
    private int wisMod;
    private int chaMod;

    // This is the value of maximum possible hit points. This should be
    // replaced by a dedicated hit point interface later on
    private int maxHitPoints;

    private int playerLevel = 1;

    private bool hasInspiration = false;
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
