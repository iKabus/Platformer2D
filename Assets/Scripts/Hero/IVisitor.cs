using UnityEngine;

public interface IVisitor
{
    public void Visit(Coin coin);
    public void Visit(Potion potion);
}
