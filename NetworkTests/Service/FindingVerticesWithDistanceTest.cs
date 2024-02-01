using FluentAssertions;
using SocialMedia.Graph;
using SocialMedia.Models.BusinessModels;
using SocialMedia.Service;
using Xunit;

namespace NetworkTests.Service;

public class FindingVerticesWithDistanceTest
{
    private readonly IFindingVerticesWithDistance<int, int> _sut;

    public FindingVerticesWithDistanceTest()
    {
        _sut = new FindingVerticesWithDistance<int, int>();
    }

    [Fact]
    public void FindVertices_SHOULD_ReturnRightNodeWithGivenDistanceIsOne_WHEN_Ever()
    {
        // Arrange
        var graph = new AdjacencyMapGraph<int, int>(false);
        var vertex1 = graph.insertVertex(1);
        var vertex2 = graph.insertVertex(2);
        var vertex3 = graph.insertVertex(2);
        graph.insertEdge(vertex1, vertex2, 1);
        graph.insertEdge(vertex1, vertex3, 1);

        // Act
        var actual = _sut.FindVertices(graph, vertex1, 1);

        // Assert
        actual.Should().Contain(vertex2).And.Contain(vertex3);
    }

    [Fact]
    public void FindVertices_SHOULD_ReturnEmptyList_WHEN_maxDistanceIsLessThanGivenDistance()
    {
        // Arrange
        var graph = new AdjacencyMapGraph<int, int>(false);
        var vertex1 = graph.insertVertex(1);
        var vertex2 = graph.insertVertex(2);
        var vertex3 = graph.insertVertex(3);
        graph.insertEdge(vertex1, vertex2, 1);
        graph.insertEdge(vertex2, vertex3, 1);
        graph.insertEdge(vertex3, vertex1, 1);

        // Act
        var actual = _sut.FindVertices(graph, vertex1, 2);

        // Assert
        actual.Should().BeEmpty();
    }
}