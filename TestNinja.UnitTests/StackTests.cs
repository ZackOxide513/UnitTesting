using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class StackTests
    {
        private Stack<string> _testStack;

        [SetUp]
        public void SetUp()
        {
            _testStack = new Stack<string>();
        }

        [Test]
        public void Push_ValidObject_ListCountIs1()
        {
            _testStack.Push("testString");
            Assert.That(_testStack.Count, Is.EqualTo(1));
        }

        [Test]
        public void Push_NullObject_ThrowsArgumentNullException()
        {
            Assert.That(() => _testStack.Push(null), Throws.ArgumentNullException);
        }


        [Test]
        public void Pop_StackNotEmpty_ReturnsObjectOnTop()
        {
            _testStack.Push("test1");
            _testStack.Push("test2");

            var result = _testStack.Pop();
            Assert.That(result, Is.EqualTo("test2"));
        }

        [Test]
        public void Pop_StackNotEmpty_RemovesObjectOnTop()
        {
            _testStack.Push("test1");
            _testStack.Push("test2");

            _testStack.Pop();
            Assert.That(_testStack.Count, Is.EqualTo(1));
        }

        [Test]
        public void Pop_StackEmpty_ThrowsInvalidOperationException()
        {
            Assert.That(() => _testStack.Pop(), Throws.InvalidOperationException);
        }

        [Test]
        public void Peek_StackNotEmpty_ReturnsLastItemOfStack()
        {
            _testStack.Push("test1");
            _testStack.Push("test2");

            var result = _testStack.Peek();
            Assert.That(result, Is.EqualTo("test2"));
        }

        [Test]
        public void Peek_StackNotEmpty_DoesNotRemoveTopObject()
        {
            _testStack.Push("test1");
            _testStack.Push("test2");

            _testStack.Peek();
            Assert.That(_testStack.Count, Is.EqualTo(2));
        }

        [Test]
        public void Peek_StackEmpty_ThrowsInvalidOperationException()
        {
            Assert.That(() => _testStack.Peek(), Throws.InvalidOperationException);
        }

        [Test]
        public void Count_EmptyStack_ReturnsZero()
        {
            Assert.That(_testStack.Count, Is.EqualTo(0));
        }
    }
}
