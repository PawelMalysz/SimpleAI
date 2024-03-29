﻿using UnityEngine;
using System.Collections;

public abstract class State<T>
{
    public abstract void EnterState(T owner);

    public abstract void ExitState(T owner);

    public abstract void UpdateState(T owner);
}
