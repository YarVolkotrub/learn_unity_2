public class GemStaticAtScene : Item
{
    public override void Collecte()
    {
        Destroy(gameObject);
    }
}