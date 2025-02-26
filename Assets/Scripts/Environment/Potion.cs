using UnityEngine;

public class Potion : MonoBehaviour, IVisitable
{
    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}
