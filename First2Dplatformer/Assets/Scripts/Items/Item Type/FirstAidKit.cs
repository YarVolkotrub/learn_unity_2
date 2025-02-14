public class FirstAidKit : Item
{
    public override void Collecte()
    {
        Destroy(gameObject);
    }
}