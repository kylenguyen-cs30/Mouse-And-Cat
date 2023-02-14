// Name : Hoang Nguyen

public class DirectionLogic
{
    private System.Random random_generator = new System.Random();
    public double get_random_direction()
    {
        double random_number;
        double ball_angle_radians;

        random_number = random_generator.NextDouble();
        ball_angle_radians = (random_number * 180 ) / System.Math.PI;

        return ball_angle_radians;
    }
}