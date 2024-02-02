using SocialMedia.Graph.Edge;

namespace SocialMedia.Graph.Vertex
{
    public class Vertex<E,V> : IVertex<E,V>
    {
        private V element;
        private Position<Vertex<E, V>> pos;


        public V getElement()
        {
            return element;
        }


        public void setPosition(Position<Vertex<E, V>> l)
        {
            pos = l;
        }

        public Position<Vertex<E, V>> getPosition()
        {
            return pos;
        }
    }
}
