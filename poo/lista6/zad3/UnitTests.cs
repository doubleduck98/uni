using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace zad3
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void RootOnly()
        {
            var root = new TreeLeaf();
            var visitor = new TreeDepthVisitor();
            visitor.Visit(root);
            Assert.AreEqual(0, visitor.Depth);
        }

        [TestMethod]
        public void SampleTree()
        {
            var root = new TreeNode()
            {
                Left = new TreeNode()
                {
                    Left = new TreeLeaf(),
                    Right = new TreeLeaf()
                },
                Right = new TreeLeaf()
            };
            var visitor = new TreeDepthVisitor();
            visitor.Visit(root);
            Assert.AreEqual(2, visitor.Depth);
        }
    }
}