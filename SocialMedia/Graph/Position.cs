namespace SocialMedia.Graph
{
    public class Position<T>
    {
        T value;
        Position<T> position;
        public Position(T value)
        {
            this.value = value;
        }

    }
}
