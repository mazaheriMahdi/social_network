using SocialMedia.Graph;
using SocialMedia.Graph.Vertex;

namespace SocialMedia.Service;

public interface IFindingVerticesWithDistance<E, V>
{
    public List<AMVertex<E, V>> FindVertices(AdjacencyMapGraph<E, V> graph, AMVertex<E, V> v, int distance);
}