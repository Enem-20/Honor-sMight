using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharParam : MonoBehaviour
{
    //Orcs Ammunation
    protected float weaponProt;
    protected float armorProt;

    protected float weaponChamp;
    protected float armorChamp;

    protected float weaponStone;
    protected float armorStone;

    protected float weaponDwarf;
    protected float armorDwarf;

    //Humans Ammunation
    protected float weaponHeavy;
    protected float armorHeavy;

    protected float weaponAvant;
    protected float armorAvant;

    protected float weaponLight;
    protected float armorLight;

    protected float weaponSpear;
    protected float armorSpear;

    //Orcs avoidence
    protected float BlockProt;
    protected float ParryProt;
    protected float EvadeProt;

    protected float BlockChamp;
    protected float ParryChamp;
    protected float EvadeChamp;

    protected float BlockStone;
    protected float ParryStone;
    protected float EvadeStone;

    protected float BlockDwarf;
    protected float ParryDwarf;
    protected float EvadeDwarf;

    //Humans avoidence
    protected float BlockHeavy;
    protected float ParryHeavy;
    protected float EvadeHeavy;

    protected float BlockAvant;
    protected float ParryAvant;
    protected float EvadeAvant;

    protected float BlockLight;
    protected float ParryLight;
    protected float EvadeLight;

    protected float BlockSpear;
    protected float ParrySpear;
    protected float EvadeSpear;

    public CharParam()
    {
        //OrcsStartParam

        //Ammunation
        weaponProt = 10.0f;
        armorProt = 15.0f;

        weaponChamp = 15.0f;
        armorChamp = 10.0f;

        weaponStone = 7.0f;
        armorStone = 7.0f;

        weaponDwarf = 3.0f;
        armorDwarf = 3.8f;

        //Avoidence

        BlockProt = 30.0f;
        ParryProt = 15.0f;
        EvadeProt = 15.0f;

        BlockChamp = 15.0f;
        ParryChamp = 15.0f;
        EvadeChamp = 17.0f;

        BlockStone = 10.0f;
        ParryStone = 10.0f;
        EvadeStone = 15.0f;

        BlockDwarf = 8;
        ParryDwarf = 10.0f;
        EvadeDwarf = 17.0f;

        //HumansStartParam

        //Ammunation
        weaponHeavy = 8.0f;
        armorHeavy = 10.5f;

        weaponAvant = 12.0f;
        armorAvant = 6.5f;

        weaponLight = 4.5f;
        armorLight = 5;

        weaponSpear = 3;
        armorSpear = 7;

        //Avoidence
        BlockHeavy = 25.0f;
        ParryHeavy = 45.0f;
        EvadeHeavy = 65.0f;

        BlockAvant = 15.0f;
        ParryAvant = 20.0f;
        EvadeAvant = 20.0f;

        BlockLight = 8.0f;
        ParryLight = 12.0f;
        EvadeLight = 20.0f;

        BlockSpear = 5.0f;
        ParrySpear = 8.0f;
        EvadeSpear = 15.0f;

        
    }
    public void GetHeavy(float[] BPEH)
    {
        
        BPEH[0] = BlockHeavy;
        BPEH[1] = ParryHeavy;
        BPEH[2] = EvadeHeavy;
    }
    public void GetHeavy(float AmmunationWeap, float AmmunationArmor)
    {
        AmmunationWeap = weaponProt;
        AmmunationArmor = armorHeavy;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
