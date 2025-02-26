using UnityEngine;

public interface IVisitable
{
    public abstract void Accept(IVisitor visitor);
}
