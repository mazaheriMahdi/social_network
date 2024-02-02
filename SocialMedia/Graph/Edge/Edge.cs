using SocialMedia.Graph.Vertex;

namespace SocialMedia.Graph.Edge
{
    public class Edge<E, V>
    {
        private E element;
        private Position<Edge<E, V>> pos;
        private AMVertex<E, V>[] endpoints;

        public Edge(AMVertex<E, V> u, AMVertex<E, V> v, E element)
        {
            this.element = element;
            endpoints = new AMVertex<E, V>[] { u, v };
        }

        public E getElement()
        {
            return element;
        }

        public AMVertex<E, V>[] getEndpoints()
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