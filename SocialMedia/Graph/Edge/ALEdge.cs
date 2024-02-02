using SocialMedia.Graph.Vertex;

namespace SocialMedia.Graph.Edge
{
    public class ALEdge<E,V>
    {
        private E element;
        private Position<ALEdge<E, V>> pos;
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

        public void setPositions(Position<ALEdge<E, V>> p)
        {
            pos = p;
        }

        public Position<ALEdge<E, V>> getPosition()
        {
            return pos;
        }
    }
}
