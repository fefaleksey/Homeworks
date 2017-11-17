using BinarySearchTree;
using Xunit;

namespace Test
{
    namespace Test
    {
        public class BinaryTreeTests
        {
            [Fact]
            public void Test_Add()
            {
                var tree = new BinaryTree<int>(5);
                tree.Add(tree.Root, 3);
                Assert.True(tree.Root.Left.Value == 3);
            }

            [Fact]
            public void Test_Delete()
            {
                var tree = new BinaryTree<int>(5);
                tree.Add(tree.Root, 3);
                tree.Add(tree.Root, 4);
                tree.Root = BinaryTree<int>.Delete(tree.Root.Left);
                Assert.True(tree.Root.Left.Value == 4);
            }

            [Fact]
            public void Test_Foreach()
            {
                var tree = new BinaryTree<int>(5);
                tree.Add(tree.Root, 3);
                tree.Add(tree.Root, 4);
                tree.Add(tree.Root, 6);
                tree.Add(tree.Root, 7);
                var treeValue = new int[5];
                var i = 0;
                foreach (int value in tree)
                {
                    treeValue[i] = value;
                    i++;
                }
                Assert.True(treeValue[0] == 3);
                Assert.True(treeValue[1] == 4);
                Assert.True(treeValue[2] == 5);
                Assert.True(treeValue[3] == 6);
                Assert.True(treeValue[4] == 7);
            }
        }
    }
}