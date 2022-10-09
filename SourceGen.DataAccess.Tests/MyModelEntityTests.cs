//namespace SourceGen.DataAccess.Tests
//{
//    public class MyModelEntityTests
//    {
//        private readonly MyModelEntityBuilder _builder;

//        public MyModelEntityTests()
//        {
//            _builder = new();
//        }

//        [Fact]
//        public void MyModelEntity_DoesItBehaveAsExpected()
//        {
//            MyModelEntity entity = _builder.WithName("Cain")
//                                           .WithDescription("The most clever")
//                                           .WithTotalWealth(500m)
//                                           .Build();

//            Assert.Equal("Cain", entity.Name);
//        }
//    }
//}