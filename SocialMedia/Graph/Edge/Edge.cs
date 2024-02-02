namespace SocialMedia.Graph.Edge
{
    public class Edge<E, V>
    {
        private E element;
        private Position<Edge<E, V>> pos;
        private Vertex<E, V>[] endpoints;

        public Edge(Vertex<E, V> u, Vertex<E, V> v, E element)
        {
            this.element = element;
            endpoints = new Vertex<E, V>[] { u, v };
        }

        public E getElement()
        {
            return element;
        }

        public Vertex<E, V>[] getEndpoints()
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