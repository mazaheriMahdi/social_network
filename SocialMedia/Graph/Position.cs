namespace SocialMedia.Graph
{
    public class Position<T>
    {
        private T value;
        public Position<T> position;
        public Position(T value)
        {
            this.value = value;
        }
        public T getValue() { return value; }

    }
}
