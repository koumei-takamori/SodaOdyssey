using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageReceivable
{
    public void TakeDamage(int damage);

    public int HP { get; }
}
