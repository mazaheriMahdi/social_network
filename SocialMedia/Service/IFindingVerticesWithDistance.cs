using SocialMedia.Graph;

namespace SocialMedia.Service;

public interface IFindingVerticesWithDistance<E, V>
{
    public List<AMVertex<E, V>> FindVertices(AdjacencyMapGraph<E, V> graph, AMVertex<E, V> v, int distance);
}