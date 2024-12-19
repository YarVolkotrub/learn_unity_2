public class PlayerInventory : IPlayerInventory
{
    private int _points = 0;

    public void AddPoints(int points)
    {
        _points += points;
    }
}