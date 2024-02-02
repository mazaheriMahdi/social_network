using SocialMedia.Graph.Edge;

namespace SocialMedia.Graph.Vertex
{
    public class AMVertex<E, V>: Vertex<E,V>
    {
        private V element;

        private Position<AMVertex<E, V>> pos;
        private Dictionary<AMVertex<E, V>, Edge<E, V>> outgoing;
        private Dictionary<AMVertex<E, V>, Edge<E, V>> incoming;

        public AMVertex(V element, bool graphIsDirected)
        {
            this.element = element;
            outgoing = new Dictionary<AMVertex<E, V>, Edge<E, V>>();
            if (graphIsDirected)
            {
                incoming = new Dictionary<AMVertex<E, V>, Edge<E, V>>();
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

        public void setPosition(Position<AMVertex<E, V>> l)
        {
            pos = l;
        }

        public Position<AMVertex<E, V>> getPosition()
        {
            return pos;
        }

        public Dictionary<AMVertex<E, V>, Edge<E, V>> getOutgoing()
        {
            return outgoing;
        }

        public Dictionary<AMVertex<E, V>, Edge<E, V>> getIncoming()
        {
            return incoming;
        }
    }
}