using SocialMedia.Graph.Vertex;

namespace SocialMedia.Graph.Edge
{
    public class ALEdge<E,V>
    {
        private E element;
        private Position<Edge<E, V>> pos;
        private ALVertex<E, V>[] endpoints;

        public ALEdge(ALVertex<E, V> u, ALVertex<E, V> v, E element)
        {
            this.element = element;
            endpoints = new ALVertex<E, V>[] { u, v };
        }

        public E getElement()
        {
            return element;
        }

        public ALVertex<E, V>[] getEndpoints()
        {
            return endpoints;
        }

        public void setPositions(Position<Edge<E, V>> p)
        {
            pos = p;
        }

        public Position<Edge<E, V>> getPosition()
        {
            return pos;
        }
    }
}
