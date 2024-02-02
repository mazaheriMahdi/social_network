using SocialMedia.Graph;

namespace SocialMedia.Service;

public interface IFindingVerticesWithDistance<E, V>
{
    public List<Vertex<E, V>> FindVertices(IGraph<E, V> graph, Vertex<E, V> v, int distance);
}