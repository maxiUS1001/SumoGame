using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class JoinCode
{
    private static string _joinCode;

    public static string Value
    {
        get
        {
            return _joinCode;
        }
        set
        {
            _joinCode = value;
        }
    }
}
