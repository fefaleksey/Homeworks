using BinarySearchTree;
using Xunit;


namespace Test
{
    public class BinaryTreeTests
    {
        [Fact]
        public void Test_ElementIsExist()
        {
            var tree = new BinaryTree<int>(5);
            tree.Add(3);
            tree.Add(4);
            Assert.True(tree.ElementIsExist(3));
        }

        [Fact]
        public void Test_Add()
        {
            var tree = new BinaryTree<int>(5);
            tree.Add(3);
            Assert.True(tree.ElementIsExist(3));
        }

        [Fact]
        public void Test_AddSeveralElements()
        {
            var tree = new BinaryTree<int>(5);
            tree.Add(3);
            tree.Add(6);
            tree.Add(8);
            tree.Add(4);
            tree.Add(1);
            Assert.True(tree.ElementIsExist(3));
            Assert.True(tree.ElementIsExist(6));
            Assert.True(tree.ElementIsExist(8));
            Assert.True(tree.ElementIsExist(4));
            Assert.True(tree.ElementIsExist(1));
            Assert.True(tree.ElementIsExist(5));
        }

        [Fact]
        public void Test_Delete()
        {
            var tree = new BinaryTree<int>(5);
            tree.Add(3);
            tree.Add(4);
            tree.Delete(3);
            Assert.True(tree.ElementIsExist(4));
        }

        [Fact]
        public void Test_DeleteSeveralElements()
        {
            var tree = new BinaryTree<int>(5);
            tree.Add(3);
            tree.Add(4);

            tree.Delete(3);
            Assert.True(tree.ElementIsExist(4));
        }

        [Fact]
        public void Test_Foreach()
        {
            var tree = new BinaryTree<int>(5);
            tree.Add(3);
            tree.Add(4);
            tree.Add(6);
            tree.Add(7);
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
