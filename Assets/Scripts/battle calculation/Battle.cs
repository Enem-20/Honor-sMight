using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle : MonoBehaviour
{
    public BattleDeterminate battleDeterminate;

    public BattleContext context;

    public delegate void SetUnit(BattleDeterminate battleDeterminate);

    public SetUnit setUnit;

    private void Awake()
    {
        context = new BattleContext();
        setUnit = context.SetUnits;
    }


    private void Update()
    {

    }
}
sealed public class BattleContext
{

    BattleDeterminate battleDeterminate;
    public void SetUnits(BattleDeterminate battle)
    {
        this.battleDeterminate = battle;
    }
}