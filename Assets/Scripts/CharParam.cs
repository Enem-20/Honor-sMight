using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class CharParam
{
    public float weapon { get; set; }
    public float armor { get; set; }
    public float Block { get; set; }
    public float Parry { get; set; }
    public float Evade { get; set; }
    public float DieProbably { get; set; }
}

sealed class ParamHeavy : CharParam
{
    public ParamHeavy()
    {
        weapon = 8.0f;
        armor = 10.5f;

        Block = 25.0f;
        Parry = 45.0f;
        Evade = 65.0f;

        DieProbably = 95.0f;
    }
}

sealed class ParamAvant : CharParam
{
    public ParamAvant()
    {
        weapon = 12.0f;
        armor = 6.5f;

        Block = 15.0f;
        Parry = 20.0f;
        Evade = 20.0f;

        DieProbably = 100.0f;
    }
}

sealed class ParamLight : CharParam
{
    public ParamLight()
    {
        weapon = 4.5f;
        armor = 5;

        Block = 8.0f;
        Parry = 12.0f;
        Evade = 20.0f;

        DieProbably = 100.0f;
    }
}
sealed class ParamSpear : CharParam
{
    public ParamSpear()
    {
        weapon = 3;
        armor = 7;

        Block = 5.0f;
        Parry = 8.0f;
        Evade = 15.0f;

        DieProbably = 100.0f;
    }
}
sealed class ParamProtector : CharParam
{
    public ParamProtector()
    {
        weapon = 10.0f;
        armor = 15.0f;

        Block = 30.0f;
        Parry = 15.0f;
        Evade = 15.0f;

        DieProbably = 90.0f;
    }
}
sealed class ParamChampion : CharParam
{
    public ParamChampion()
    {
        weapon = 15.0f;
        armor = 10.0f;


        Block = 15.0f;
        Parry = 15.0f;
        Evade = 17.0f;

        DieProbably = 95.0f;
    }
}
sealed class ParamStone : CharParam
{
    public ParamStone()
    {
        weapon = 7.0f;
        armor = 7.0f;

        Block = 10.0f;
        Parry = 10.0f;
        Evade = 15.0f;

        DieProbably = 100.0f;
    }
}
sealed class ParamDwarf : CharParam
{
    public ParamDwarf()
    {
        weapon = 3.0f;
        armor = 3.8f;

        Block = 8;
        Parry = 10.0f;
        Evade = 17.0f;

        DieProbably = 100.0f;
    }
}