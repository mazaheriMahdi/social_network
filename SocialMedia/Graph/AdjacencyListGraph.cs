using SocialMedia.Graph.Edge;
using SocialMedia.Graph.Vertex;

namespace SocialMedia.Graph
{
    public class AdjacencyListGraph<E,V>
    {
        bool isDeirected;
        private List<Position<ALEdge<E, V>>> edgeList;
        private List<Position<ALVertex<E, V>>> vertexList;

        public AdjacencyListGraph(bool direcred)
        {
            edgeList = new List<Position<ALEdge<E, V>>>();
            vertexList = new List<Position<ALVertex<E, V>>>();
            isDeirected = direcred;
        }

        public void removeEdge(ALEdge<E, V> e)
        {
            edgeList.Remove(e.getPosition());
        }

        public void removeVertex(ALVertex<E, V> v)
        {
            foreach (var e in outgoingEdges(v))
            {
                removeEdge(e);
            }

            foreach (var e in incomingEdges(v))
            {
                removeEdge(e);
            }

            vertexList.Remove(v.getPosition());
        }

        public ALEdge<E, V> insertEdge(ALVertex<E, V> u, ALVertex<E, V> v, E element)
        {
            if (getEdge(u, v) == null)
            {
                ALEdge<E, V> newEdge = new ALEdge<E, V>(u, v, element);
                Position<ALEdge<E, V>> newPos = new Position<ALEdge<E, V>>(newEdge);
                edgeList.Add(newPos);
                newPos.position = edgeList.Last();
                u.getOutgoing().Add(newEdge);
                v.getIncoming().Add(newEdge);
                return newEdge;
            }

            throw new ArgumentException();
        }

        public ALVertex<E, V> insertVertex(V element)
        {
            ALVertex<E, V> newVertex = new ALVertex<E, V>(element, isDeirected);
            Position<ALVertex<E, V>> pos = new Position<ALVertex<E, V>>(newVertex);
            vertexList.Add(pos);
            pos.position = vertexList.Last();
            newVertex.setPosition(vertexList.Last());
            return newVertex;
        }

        public ALVertex<E, V>[] endVertices(ALEdge<E, V> e)
        {
            ALVertex<E, V>[] arr = new ALVertex<E, V>[2];
            foreach (var end in e.getEndpoints()) arr.Append(end);
            return arr;
        }

        public ALVertex<E, V> opposite(ALVertex<E, V> v, ALEdge<E, V> e)
        {
            var endpoints = e.getEndpoints();
            if (endpoints[0] == v) return endpoints[1];
            else if (endpoints[1] == v) return endpoints[0];
            else throw new InvalidDataException();
        }

        public ALVertex<E, V> getEdge(ALVertex<E, V> u, ALVertex<E, V> v)
        {
            if (!u.getOutgoing().TryGetValue(v, out var result))
            {
                return result;
            }

            return null;
        }

        public int inDegreee(ALVertex<E, V> v)
        {
            return v.getIncoming().Count;
        }

        public int outDegreee(ALVertex<E, V> v)
        {
            return v.getOutgoing().Count;
        }

        public List<ALEdge<E, V>> outgoingEdges(ALVertex<E, V> v)
        {
            return v.getOutgoing();
        }

        public List<ALEdge<E, V>> edges()
        {
            var tempEdgeList = new List<ALEdge<E, V>>();
            foreach (var ed in edgeList) tempEdgeList.Add(ed.getValue());
            return tempEdgeList;
        }

        public List<ALVertex<E, V>> vertices()
        {
            var tempVertexList = new List<ALVertex<E, V>>();
            foreach (var ver in vertexList) tempVertexList.Add(ver.getValue());
            return tempVertexList;
        }

        public int numEdges()
        {
            return this.edgeList.Count;
        }

        public List<ALEdge<E, V>> incomingEdges(ALVertex<E, V> v)
        {
            return v.getIncoming();
        }

        public int numVertices()
        {
            return vertexList.Count;
        }

    }
}
