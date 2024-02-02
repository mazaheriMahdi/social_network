using SocialMedia.Graph.Edge;

namespace SocialMedia.Graph.Vertex
{
    public class ALVertex<E,V> : Vertex<E,V>
    {
        private V element;

        private Position<ALVertex<E, V>> pos;
        private List<ALEdge<E, V>> outgoing;
        private List<ALEdge<E, V>> incoming;

        public ALVertex(V element, bool graphIsDirected)
        {
            this.element = element;
            outgoing = new List<ALEdge<E, V>>();
            if (graphIsDirected)
            {
                incoming = new List<ALEdge<E, V>>();
            }
            else
            {
                incoming = outgoing;
            }
        }

        public V getElement()
        {
            return element;
        }

        public void setPosition(Position<ALVertex<E, V>> l)
        {
            pos = l;
        }

        public Position<ALVertex<E, V>> getPosition()
        {
            return pos;
        }

        public List<ALEdge<E, V>> getOutgoing()
        {
            return outgoing;
        }

        public List<ALEdge<E, V>> getIncoming()
        {
            return incoming;
        }
    }
}
