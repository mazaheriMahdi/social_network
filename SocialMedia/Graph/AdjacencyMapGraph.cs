
using SocialMedia.Graph.Edge;
using SocialMedia.Graph.Vertex;
namespace SocialMedia.Graph
{
    public class AdjacencyMapGraph<E, V>
    {
        bool isDeirected;
        private List<Position<Edge<E, V>>> edgeList;
        private List<Position<AMVertex<E, V>>> vertexList;

        public AdjacencyMapGraph(bool direcred)
        {
            edgeList = new List<Position<Edge<E, V>>>();
            vertexList = new List<Position<AMVertex<E, V>>>();
            isDeirected = direcred;
        }

        public void removeEdge(Edge<E, V> e)
        {
            edgeList.Remove(e.getPosition());
        }

        public void removeVertex(AMVertex<E, V> v)
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

        public Edge<E, V> insertEdge(AMVertex<E, V> u, AMVertex<E, V> v, E element)
        {
            if (getEdge(u, v) == null)
            {
                Edge<E, V> newEdge = new Edge<E, V>(u, v, element);
                Position<Edge<E, V>> newPos = new Position<Edge<E, V>>(newEdge);
                edgeList.Add(newPos);
                newPos.position = edgeList.Last();
                u.getOutgoing().Add(v, newEdge);
                v.getIncoming().Add(u, newEdge);
                return newEdge;
            }

            throw new ArgumentException();
        }

        public AMVertex<E, V> insertVertex(V element)
        {
            AMVertex<E, V> newVertex = new AMVertex<E, V>(element, isDeirected);
            Position<AMVertex<E, V>> pos = new Position<AMVertex<E, V>>(newVertex);
            vertexList.Add(pos);
            pos.position = vertexList.Last();
            newVertex.setPosition(vertexList.Last());
            return newVertex;
        }

        public Vertex<E, V>[] endVertices(Edge<E, V> e)
        {
            AMVertex<E, V>[] arr = new AMVertex<E, V>[2];
            foreach (var end in e.getEndpoints()) arr.Append(end);
            return arr;
        }

        public AMVertex<E, V> opposite(AMVertex<E, V> v, Edge<E, V> e)
        {
            var endpoints = e.getEndpoints();
            if (endpoints[0] == v) return endpoints[1];
            else if (endpoints[1] == v) return endpoints[0];
            else throw new InvalidDataException();
        }

        public Edge<E, V> getEdge(AMVertex<E, V> u, AMVertex<E, V> v)
        {
            if (!u.getOutgoing().TryGetValue(v, out var result))
            {
                return result;
            }

            return null;
        }

        public int inDegreee(AMVertex<E, V> v)
        {
            return v.getIncoming().Count;
        }

        public int outDegreee(AMVertex<E, V> v)
        {
            return v.getOutgoing().Count;
        }

        public  List<Edge<E, V>> outgoingEdges(AMVertex<E, V> v)
        {
            return new List<Edge<E, V>>(v.getOutgoing().Values);
        }

        public List<Edge<E, V>> edges()
        {
            var tempEdgeList = new List<Edge<E, V>>();
            foreach (var ed in edgeList) tempEdgeList.Add(ed.getValue());
            return tempEdgeList;
        }

        public List<AMVertex<E, V>> vertices()
        {
            var tempVertexList = new List<AMVertex<E, V>>();
            foreach (var ver in vertexList) tempVertexList.Add(ver.getValue());
            return tempVertexList;
        }

        public int numEdges()
        {
            return this.edgeList.Count;
        }

        

        public int numVertices()
        {
            return vertexList.Count;
        }

        public int findDistance(V a, V b)
        {
            var first = findVertex(a);
            var second = findVertex(b);
            return findVerticesDistance(first, second);
        }

        public int findVerticesDistance(Vertex<E, V> a, Vertex<E, V> b)
        {
            throw new Exception();
        }

        public Vertex<E, V> findVertex(V value)
        {
            foreach (var ver in vertexList)
            {
                if (ver.getValue().getElement().Equals(value))
                {
                    return ver.getValue();
                }
            }

            throw new InvalidDataException();
        }

        public  List<Edge<E, V>> incomingEdges(AMVertex<E, V> v)
        {
            return new List<Edge<E, V>>(v.getIncoming().Values);

        }

        
    }
}