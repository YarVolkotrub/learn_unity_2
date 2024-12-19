public class ItemFromScene : Item
{
    public override void Destroy()
    {
        Destroy(gameObject);
    }
}