using System;
using Codetox.Pooling;
using NUnit.Framework;

namespace Codetox.Editor.Tests.Pooling
{
    public class LifoPoolTest
    {
        private class TestClass
        {
            public int Number;
            public string Text;

            public TestClass(int number, string text)
            {
                Number = number;
                Text = text;
            }
        }

        private Func<TestClass> _createObject;

        [SetUp]
        public void Setup()
        {
            _createObject = () => new TestClass(10, "Hello");
        }

        [Test]
        public void InitializePool_WithCreateObjectArgumentAsNull_ThrowsArgumentNullException()
        {
            Assert.That(() => new LifoPool<TestClass>(null), Throws.ArgumentNullException);
        }    
    
        [Test]
        public void InitializePool_WithCapacityArgumentAsLessThanZero_ThrowsArgumentOutOfRangeException()
        {
            Assert.That(() => new LifoPool<TestClass>(_createObject, capacity: -1), Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
        }      
    
        [Test]
        public void InitializePool_WithCapacityArgumentAsZero_ThrowsArgumentOutOfRangeException()
        {
            Assert.That(() => new LifoPool<TestClass>(_createObject, capacity: 0), Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
        }  
    
        [Test]
        public void InitializePool_WithCreateObjectArgumentAsValid_DoesNotThrowException()
        {
            Assert.That(() => new LifoPool<TestClass>(_createObject), Throws.Nothing);
        } 
    
        [Test]
        public void InitializePool_WithDefaultArguments_PoolCapacityIsEqualTo10()
        {
            Assert.That(new LifoPool<TestClass>(_createObject).Capacity, Is.EqualTo(10));
        }
    
        [Test]
        public void InitializePool_WithCapacityArgumentAsCustomValue_PoolCapacityIsEqualToCustomValue()
        {
            Assert.That(new LifoPool<TestClass>(_createObject, capacity: 5).Capacity, Is.EqualTo(5));
        }
    
        [Test]
        public void InitializePool_WithDefaultArguments_PoolCountIsEqualToCapacity()
        {
            Assert.That(new LifoPool<TestClass>(_createObject).Count, Is.EqualTo(10));
        }
        
        [Test]
        public void InitializePool_WithCapacityArgumentAsCustomValue_PoolCountIsEqualToCapacity()
        {
            Assert.That(new LifoPool<TestClass>(_createObject, capacity: 5).Count, Is.EqualTo(5));
        }
        
        [Test]
        public void InitializePool_WithDefaultArguments_PoolIsFull()
        {
            Assert.That(new LifoPool<TestClass>(_createObject).IsFull, Is.True);
        }
        
        [Test]
        public void InitializePool_DefaultArguments_PoolIsNotEmpty()
        {
            Assert.That(new LifoPool<TestClass>(_createObject).IsEmpty, Is.False);
        }
        
        [Test]
        public void IsEmptyProperty_WithCountPropertyAsZero_ReturnsTrue()
        {
            var pool = new LifoPool<TestClass>(_createObject, capacity: 1);
            pool.Get();
            Assert.That(pool.Count == 0, Is.True);
            Assert.That(pool.IsEmpty, Is.True);
        }    
    
        [Test]
        public void IsEmptyProperty_WithCountPropertyAsBiggerThanZero_ReturnsFalse()
        {
            var pool = new LifoPool<TestClass>(_createObject, capacity: 1);
            Assert.That(pool.Count > 0, Is.True);
            Assert.That(pool.IsEmpty, Is.False);
        }
    
        [Test]
        public void IsFullProperty_WithCountPropertyEqualToCapacityProperty_ReturnsTrue()
        {
            var pool = new LifoPool<TestClass>(_createObject, capacity: 1);
            Assert.That(pool.Count == pool.Capacity, Is.True);
            Assert.That(pool.IsFull, Is.True);
        }    
    
        [Test]
        public void IsFullProperty_WithCountPropertyAsLessThanCapacityProperty_ReturnsFalse()
        {
            var pool = new LifoPool<TestClass>(_createObject, capacity: 1);
            pool.Get();
            Assert.That(pool.Count < pool.Capacity, Is.True);
            Assert.That(pool.IsFull, Is.False);
        }
        
        [Test]
        public void GetPoolObject_WithNonEmptyPool_ReturnsNotNull()
        {
            var pool = new LifoPool<TestClass>(_createObject);
            Assert.That(pool.Get(), Is.Not.Null);
        }
        
        [Test]
        public void GetPoolObject_WithNonEmptyPool_CountPropertyIsDecrementedByOne()
        {
            var pool = new LifoPool<TestClass>(_createObject);
            var count = pool.Count;
            pool.Get();
            Assert.That(pool.Count, Is.EqualTo(count - 1));
        }
        
        [Test]
        public void GetPoolObject_WithNonEmptyPool_OnGetObjectActionIsPerformed()
        {
            var pool = new LifoPool<TestClass>(_createObject, onGetObject: obj => obj.Number = 20);
            var obj = pool.Get();
            Assert.That(obj.Number, Is.EqualTo(20));
        }
        
        [Test]
        public void GetPoolObject_WithEmptyPool_ReturnsNotNull()
        {
            var pool = new LifoPool<TestClass>(_createObject, capacity: 1);
            pool.Get();
            Assert.That(pool.IsEmpty, Is.True);
            Assert.That(pool.Get(), Is.Not.Null);
        }
            
        [Test]
        public void GetPoolObject_WithEmptyPool_PoolRemainsEmpty()
        {
            var pool = new LifoPool<TestClass>(_createObject, capacity: 1);
            Assert.That(pool.Get(), Is.Not.Null);
            Assert.That(pool.IsEmpty, Is.True);
            Assert.That(pool.Count == 0, Is.True);
        }
    
        [Test]
        public void GetPoolObject_WithEmptyPool_OnGetObjectActionIsPerformedOnCreatedObject()
        {
            var pool = new LifoPool<TestClass>(_createObject, onGetObject: obj => obj.Number = 20, capacity: 1);
            pool.Get();
            Assert.That(pool.IsEmpty, Is.True);
            var obj = pool.Get();
            Assert.That(obj.Number, Is.EqualTo(20));
        }
            
        [Test]
        public void GetPoolObject_WithFullPool_PoolIsNoLongerFull()
        {
            var pool = new LifoPool<TestClass>(_createObject);
            var isFull = pool.IsFull;
            pool.Get();
            Assert.That(isFull, Is.True);
            Assert.That(pool.IsFull, Is.False);
        }
    
        [Test]
        public void PoolContainsObject_WithNullArgument_ThrowsArgumentNullException()
        {
            var pool = new LifoPool<TestClass>(_createObject);
            Assert.That(() => pool.Contains(null), Throws.ArgumentNullException);
        }
            
        [Test]
        public void PoolContainsObject_WithObjectNotInPool_ReturnsFalse()
        {
            var pool = new LifoPool<TestClass>(_createObject);
            var obj = _createObject();
            Assert.That(pool.Contains(obj), Is.False);
        }
            
        [Test]
        public void PoolContainsObject_WithObjectRetrievedFromPool_ReturnsFalse()
        {
            var pool = new LifoPool<TestClass>(_createObject);
            var obj = pool.Get();
            Assert.That(pool.Contains(obj), Is.False);
        }
        
        [Test]
        public void ReturnPoolObject_WithNullArgument_ThrowsArgumentNullException()
        {
            var pool = new LifoPool<TestClass>(_createObject);
            Assert.That(() => pool.Return(null), Throws.ArgumentNullException);
        }
        
        [Test]
        public void ReturnPoolObject_WithNonFullPool_CountPropertyIsIncrementedByOne()
        {
            var pool = new LifoPool<TestClass>(_createObject);
            var obj = pool.Get();
            var count = pool.Count;
            pool.Return(obj);
            Assert.That(pool.Count, Is.EqualTo(count + 1));
        }
        
        [Test]
        public void ReturnPoolObject_WithNonFullPool_PoolContainsReturnedObject()
        {
            var pool = new LifoPool<TestClass>(_createObject);
            var obj = pool.Get();
            pool.Return(obj);
            Assert.That(pool.Contains(obj), Is.True);
        }
        
        [Test]
        public void ReturnPoolObject_WithNonFullPool_OnReturnObjectActionIsPerformed()
        {
            var pool = new LifoPool<TestClass>(_createObject, onReturnObject: obj => obj.Number = 20);
            var obj = pool.Get();
            pool.Return(obj);
            Assert.That(obj.Number, Is.EqualTo(20));
        }

        [Test]
        public void ReturnPoolObject_WithFullPool_CountPropertyIsNotModified()
        {
            var pool = new LifoPool<TestClass>(_createObject);
            var obj = _createObject();
            var count = pool.Count;
            pool.Return(obj);
            Assert.That(pool.Count, Is.EqualTo(count));
        }

        [Test]
        public void ReturnPoolObject_WithFullPool_PoolNotContainsReturnedObject()
        {
            var pool = new LifoPool<TestClass>(_createObject);
            var obj = _createObject();
            pool.Return(obj);
            Assert.That(pool.Contains(obj), Is.False);
        }
            
        [Test]
        public void ReturnPoolObject_WithFullPool_OnReturnObjectActionIsNotPerformed()
        {
            var pool = new LifoPool<TestClass>(_createObject, onReturnObject: obj => obj.Number = 20);
            var obj = _createObject();
            pool.Return(obj);
            Assert.That(obj.Number, Is.EqualTo(10));
        }

        [Test]
        public void ClearPool_PoolIsEmpty()
        {
            var pool = new LifoPool<TestClass>(_createObject);
            pool.Clear();
            Assert.That(pool.IsEmpty, Is.True);
        }

        [Test]
        public void ClearPool_OnRemoveObjectActionIsPerformedInAllPoolObjects()
        {
            var pool = new LifoPool<TestClass>(_createObject, onRemoveObject: obj => obj.Number = 20, capacity: 3);
            var first = pool.Get();
            var second = pool.Get();
            var third = pool.Get();
        
            pool.Return(first);
            pool.Return(second);
        
            pool.Clear();
        
            Assert.That(first.Number, Is.EqualTo(20));
            Assert.That(second.Number, Is.EqualTo(20));
            Assert.That(third.Number, Is.EqualTo(10));
        }

        [Test]
        public void ClearPool_WithReturnedObject_PoolNotContainsReturnedObject()
        {
            var pool = new LifoPool<TestClass>(_createObject);
            var obj = pool.Get();
            pool.Return(obj);
            pool.Clear();
            Assert.That(pool.Contains(obj), Is.False);
        }
    
        [Test]
        public void IteratePool_WithNullArgument_ThrowsArgumentNullException()
        {
            var pool = new LifoPool<TestClass>(_createObject);
            Assert.That(() => pool.ForEach(null), Throws.ArgumentNullException);
        }

        [Test]
        public void _ActionIsPerformedOnEachPoolObject()
        {
            var pool = new LifoPool<TestClass>(_createObject, capacity: 3);

            pool.ForEach(obj => obj.Number = 20);
        
            Assert.That(pool.Get().Number, Is.EqualTo(20));
            Assert.That(pool.Get().Number, Is.EqualTo(20));
            Assert.That(pool.Get().Number, Is.EqualTo(20));
        }
    
        [Test]
        public void GetAndReturnPoolObjects_OrderIsLIFO()
        {
            var pool = new LifoPool<TestClass>(_createObject, capacity: 3);
        
            var first = pool.Get();
            var second = pool.Get();
            var third = pool.Get();
        
            pool.Return(first);
            pool.Return(second);
            pool.Return(third);
        
            Assert.That(pool.Get(), Is.EqualTo(third));
            Assert.That(pool.Get(), Is.EqualTo(second));
            Assert.That(pool.Get(), Is.EqualTo(first));
        }
    }
}
