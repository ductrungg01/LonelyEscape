public interface IObstacle
{
    // Method to handle when the obstacle is hit by the player
    void HitByPlayer();

    // Method to deactivate the collider of the obstacle
    void DeactivateCollider();
}
