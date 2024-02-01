namespace SocialMedia.Graph
{
    public class Vertex<E, V> 
    {
        private V element;
        
        private Position<Vertex<E, V>> pos;
        private Dictionary<Vertex<E, V>, Edge<E, V>> outgoing;
        private Dictionary<Vertex<E, V>, Edge<E, V>> incoming;
        public Vertex(V element, bool graphIsDirected)
        {
            this.element = element;
            outgoing = new Dictionary<Vertex<E, V>, Edge<E, V>>();
            if (graphIsDirected)
            {
                incoming = new Dictionary<Vertex<E, V>, Edge<E, V>>();
            }
            else
            {
                incoming = outgoing;
            }
        }
        public V getElement() { return this.element; }
        public void setPosition(Position<Vertex<E, V>> l) { this.pos = l; }
        public Position<Vertex<E, V>> getPosition() { return pos; }
        public Dictionary<Vertex<E, V>, Edge<E, V>> getOutgoing() { return outgoing; }
        public Dictionary<Vertex<E, V>, Edge<E, V>> getIncoming() { return incoming; }

    }
}
