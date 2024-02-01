using System.Security.Cryptography.Xml;

namespace SocialMedia.Graph
{
    public class EdgeListGraph<E,V> : IGraph<E, V>
    {

        bool isDirected;
        private List<Position<Edge<E, V>>> edgeList;
        private List<Position<Vertex<E, V>>> vertexList;
        public EdgeListGraph(bool isDirec)
        {
            isDirected = isDirec;
            edgeList = new List<Position<Edge<E, V>>>();
            vertexList = new List<Position<Vertex<E, V>>>();
        }

        public Vertex<E, V>[] endVertices(Edge<E, V> e)
        {
            Vertex<E, V>[] arr = new Vertex<E, V>[2];
            foreach (var end in e.getEndpoints()) arr.Append(end);
            return arr;
        }

        public Edge<E, V> getEdge(Vertex<E, V> u, Vertex<E, V> v)
        {

            foreach (var edge in this.edges())
            {
                var ends = edge.getEndpoints();
                if (ends.Contains(v) && ends.Contains(u)) return edge;
            }
            throw new InvalidDataException();
        }

        public List<Edge<E, V>> incomingEdges(Vertex<E, V> v)
        {
            List<Edge<E, V>> edges;
            return  new List<Edge<E,V>>(v.getIncoming().Values);
        }

        public int inDegreee(Vertex<E, V> v)
        {
            return v.getIncoming().Count;
        }

        public Edge<E, V> insertEdge(Vertex<E, V> u, Vertex<E, V> v, E element)
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

        public Vertex<E, V> insertVertex(V element)
        {
            Vertex<E, V> newVertex = new Vertex<E, V>(element, isDirected);
            Position<Vertex<E, V>> pos = new Position<Vertex<E, V>>(newVertex);
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

        public Vertex<E, V> opposite(Vertex<E, V> v, Edge<E, V> e)
        {
            return e.getEndpoints()[0] == v ? e.getEndpoints()[1] : e.getEndpoints()[0];
        }

        public int outDegreee(Vertex<E, V> v)
        {
            return outgoingEdges(v).Count;
        }

        public List<Edge<E, V>> outgoingEdges(Vertex<E, V> v)
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

        public void removeVertex(Vertex<E, V> v)
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

        public List<Vertex<E, V>> vertices()
        {
            var tempVertexList = new List<Vertex<E, V>>();
            foreach (var ver in vertexList) tempVertexList.Add(ver.getValue());
            return tempVertexList;
        }  
    }
}
