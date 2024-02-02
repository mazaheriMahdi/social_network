using System.Security.Cryptography.Xml;
using SocialMedia.Graph.Edge;
using SocialMedia.Graph.Vertex;

namespace SocialMedia.Graph
{
    public class EdgeListGraph<E,V> 
    {

        bool isDirected;
        private List<Position<Edge<E, V>>> edgeList;
        private List<Position<AMVertex<E, V>>> vertexList;
        public EdgeListGraph(bool isDirec)
        {
            isDirected = isDirec;
            edgeList = new List<Position<Edge<E, V>>>();
            vertexList = new List<Position<AMVertex<E, V>>>();
        }

        public AMVertex<E, V>[] endVertices(Edge<E, V> e)
        {
            AMVertex<E, V>[] arr = new AMVertex<E, V>[2];
            foreach (var end in e.getEndpoints()) arr.Append(end);
            return arr;
        }

        public Edge<E, V> getEdge(AMVertex<E, V> u, AMVertex<E, V> v)
        {

            foreach (var edge in this.edges())
            {
                var ends = edge.getEndpoints();
                if (ends.Contains(v) && ends.Contains(u)) return edge;
            }
            throw new InvalidDataException();
        }

        public List<Edge<E, V>> incomingEdges(AMVertex<E, V> v)
        {
            List<Edge<E, V>> edges;
            return  new List<Edge<E,V>>(v.getIncoming().Values);
        }

        public int inDegreee(AMVertex<E, V> v)
        {
            return v.getIncoming().Count;
        }

        public Edge<E, V> insertEdge(AMVertex<E, V> u, AMVertex<E, V> v, E element)
        {
            if (getEdge(u, v) == null)
            {
                Edge<E, V> newEdge = new Edge<E, V>(u, v, element);
                Position<Edge<E, V>> newPos = new Position<Edge<E, V>>(newEdge);
                edgeList.Add(newPos);
                newPos.position = edgeList.Last();
                return newEdge;
            }
            throw new ArgumentException();
        }

        public AMVertex<E, V> insertVertex(V element)
        {
            AMVertex<E, V> newVertex = new AMVertex<E, V>(element, isDirected);
            Position<AMVertex<E, V>> pos = new Position<AMVertex<E, V>>(newVertex);
            pos.position = vertexList.Last();
            vertexList.Add(pos);
            newVertex.setPosition(vertexList.Last());
            return newVertex;
        }

        public int numEdges()
        {
            return edgeList.Count;
        }

        public int numVertices()
        {
            return vertexList.Count;
        }

        public AMVertex<E, V> opposite(AMVertex<E, V> v, Edge<E, V> e)
        {
            return e.getEndpoints()[0] == v ? e.getEndpoints()[1] : e.getEndpoints()[0];
        }

        public int outDegreee(AMVertex<E, V> v)
        {
            return outgoingEdges(v).Count;
        }

        public List<Edge<E, V>> outgoingEdges(AMVertex<E, V> v)
        {
            var edges = new List<Edge<E, V>>();
            foreach (var e in this.edges())
            {
                if (e.getEndpoints().Contains(v)) edges.Add(e);
            }
            return edges;
        }

        public void removeEdge(Edge<E, V> e)
        {
            edgeList.Remove(e.getPosition());
        }

        public void removeVertex(AMVertex<E, V> v)
        {
            foreach (var e in this.edges())
            {
                if (e.getEndpoints().Contains(v)) removeEdge(e);
            }
            vertexList.Remove(v.getPosition());
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
    }
}
