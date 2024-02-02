using SocialMedia.Graph;

namespace SocialMedia.Service;

public class FindingVerticesWithDistance<E, V> : IFindingVerticesWithDistance<E, V>
{
    public List<AMVertex<E, V>> FindVertices(AdjacencyMapGraph<E, V> graph, AMVertex<E, V> v, int distance)
    {
        var known = new List<AMVertex<E, V>>();
        var level = new List<AMVertex<E, V>>();
        known.Add(v);
        level.Add(v);
        while (distance > 0)
        {
            var nexLevel = new List<AMVertex<E, V>>();
            foreach (var ver in level)
            {
                foreach (var edge in graph.outgoingEdges(v))
                {
                    var tempVertex = graph.opposite(ver, edge);
                    if (!known.Contains(tempVertex))
                    {
                        known.Add(tempVertex);
                        nexLevel.Add(tempVertex);
                    }
                }
            }

            level = nexLevel;
            distance--;
        }

        return level;
    }
}