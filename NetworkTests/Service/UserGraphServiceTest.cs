// using NSubstitute;
// using SocialMedia.Abstraction;
// using SocialMedia.Graph;
// using SocialMedia.Models.BusinessModels;
// using SocialMedia.Service;
// using Xunit;
//
// namespace NetworkTests.Service;
//
// public class UserGraphServiceTest
// {
//     private readonly IUserGraphService sut;
//     private readonly IStorageService _storageService;
//     private readonly IScoringAlgorithm _scoringAlgorithm;
//
//     public UserGraphServiceTest()
//     {
//         _storageService = Substitute.For<IStorageService>();
//         _scoringAlgorithm = Substitute.For<IScoringAlgorithm>();
//         // this.sut = new UserGraphService(_storageService, _scoringAlgorithm);
//     }
//
//     [Fact]
//     public void Generate_SHOULD_generateGraphForUsers_WhenEver()
//     {
//         // Arrange
//         var userList = new User[]
//         {
//             new()
//             {
//                 Id = 1,
//                 ConnectionId = new[] { 2L, 3L }
//             },
//             new()
//             {
//                 Id = 2,
//                 ConnectionId = new long[] { }
//             },
//             new()
//             {
//                 Id = 3,
//                 ConnectionId = new long[] { }
//             }
//         };
//         _storageService.GetAllUsers().Returns(userList);
//         _scoringAlgorithm.Score(Arg.Any<User>(), Arg.Any<User>(), Arg.Any<int>()).Returns(1);
//
//         var expected = new AdjacencyMapGraph<int, User>(false);
//         var vertex1 = expected.insertVertex(userList[0]);
//         var vertex2 = expected.insertVertex(userList[1]);
//         var vertex3 = expected.insertVertex(userList[2]);
//         expected.insertEdge(vertex1, vertex2, 1);
//         expected.insertEdge(vertex1, vertex3, 1);
//
//         // Act
//         sut.GenerateGraph();
//
//         // Assert
//         _storageService.Received().SaveGraph(Arg.Any<IGraph<int, User>>());
//     }
// }