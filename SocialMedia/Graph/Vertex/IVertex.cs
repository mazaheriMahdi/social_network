using SocialMedia.Graph.Edge;
using System.Text;
using System.Xml.Linq;

namespace SocialMedia.Graph.Vertex
{
    public interface IVertex<E,V>
    {
        public V getElement();

        public void setPosition(Position<Vertex<E, V>> l);

        public Position<Vertex<E, V>> getPosition();

    }
}
