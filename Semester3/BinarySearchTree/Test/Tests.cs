using BinarySearchTree;
using Xunit;


namespace Test
{
    public class BinaryTreeTests
    {
        [Fact]
        public void Test_IsExist()
        {
            var tree = new BinaryTree<int>(5);
            tree.Add(3);
            tree.Add(4);
            Assert.True(tree.IsExist(3));
        }

        [Fact]
        public void Test_Add()
        {
            var tree = new BinaryTree<int>(5);
            tree.Add(3);
            Assert.True(tree.IsExist(3));
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
            Assert.True(tree.IsExist(3));
            Assert.True(tree.IsExist(6));
            Assert.True(tree.IsExist(8));
            Assert.True(tree.IsExist(4));
            Assert.True(tree.IsExist(1));
            Assert.True(tree.IsExist(5));
        }

        [Fact]
        public void Test_Delete()
        {
            var tree = new BinaryTree<int>(5);
            tree.Add(3);
            tree.Add(4);
            tree.Delete(3);
            Assert.True(tree.IsExist(4));
        }

        [Fact]
        public void Test_DeleteSeveralElements()
        {
            var tree = new BinaryTree<int>(5);
            tree.Add(3);
            tree.Add(4);

            tree.Delete(3);
            Assert.True(tree.IsExist(4));
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
            var aclualValues = new int[5] {3, 4, 5, 6, 7};
            Assert.Equal(treeValue, aclualValues);
        }
        
        [Fact]
        public void Test_DeleteNonTrivial()
        {
            var tree = new BinaryTree<int>(2);
            tree.Add(1);
            tree.Add(6);
            tree.Add(3);
            tree.Add(5);
            tree.Add(4);
            tree.Add(7);
            tree.Delete(6);
            Assert.True(tree.IsExist(4));
        }
    }
}
