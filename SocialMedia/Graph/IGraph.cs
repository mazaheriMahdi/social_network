namespace SocialMedia.Graph
{
    public interface IGraph<E, V>
    {
        int numVertices();
        List<Vertex<E, V>> vertices();
        int numEdges();
        List<Edge<E, V>> edges();
        Edge<E, V> getEdge(Vertex<E, V> u, Vertex<E, V> v);
        Vertex<E, V>[] endVertices(Edge<E, V> e);
        Vertex<E, V> opposite(Vertex<E, V> v, Edge<E, V> e);
        int outDegreee(Vertex<E, V> v);
        int inDegreee(Vertex<E, V> v);
        List<Edge<E, V>> outgoingEdges(Vertex<E, V> v);
        List<Edge<E, V>> incomingEdges(Vertex<E, V> v);
        public Vertex<E, V> insertVertex(V element);
        public Edge<E, V> insertEdge(Vertex<E, V> u, Vertex<E, V> v, E element);
        public void removeVertex(Vertex<E, V> v);
        public void removeEdge(Edge<E, V> e);
    }
}