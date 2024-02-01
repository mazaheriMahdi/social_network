namespace SocialMedia.Graph
{
    public class Edge<E, V>
    {
        private E element;
        private Position<Edge<E, V>> pos;
        private Vertex<E, V>[] endpoints;

        public Edge(Vertex<E, V> u, Vertex<E, V> v, E element)
        {
            this.element = element;
            endpoints = (Vertex<E, V>[])new Vertex<E, V>[] { u, v };
        }

        public E getElement()
        {
            return this.element;
        }

        public Vertex<E, V>[] getEndpoints()
        {
            return this.endpoints;
        }

        public void setPositions(Position<Edge<E, V>> p)
        {
            this.pos = p;
        }

        public Position<Edge<E, V>> getPosition()
        {
            return this.pos;
        }
    }
}