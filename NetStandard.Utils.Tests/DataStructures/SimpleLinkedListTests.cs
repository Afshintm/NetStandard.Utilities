
using System;
using NetStandard.Utils.DataStructures;
using Xunit;

namespace NetStandard.Utils.Tests.DataStructures
{
    public class SimpleLinkedListTests
    {
        [Fact]
        public void InsertFirst_Should_Insert_Item_At_First()
        {
            var simpleLinkedList = new SimpleLinkedList<int>(1);
            var secondLinkedList = simpleLinkedList.InsertLast(2);
            simpleLinkedList.InsertLast(3);
            var list = simpleLinkedList.ToList();
            Assert.Collection(list,
                i=>Assert.Equal(1,i) ,
                i=>Assert.Equal(2,i),i=>Assert.Equal(3,i));
        }

        [Fact]
        public void SimpleLinkedList_Should_Be_Iterator()
        {
            var a = new Func<SimpleLinkedList<int>>(()=>new SimpleLinkedList<int>(1));
            var intArray = new int[] {1, 2, 3};
            var simpleLinkedList =  CreateSystemUnderTest<int>(intArray);
            var index = -1;
            foreach (var item in simpleLinkedList)
            {
                Assert.Equal(intArray[++index], item);
            }
        }

        private SimpleLinkedList<T> CreateSystemUnderTest<T>(params T[] input)
        {
            if(input==null) return null;
            var simpleLinkedList = new SimpleLinkedList<T>(input[0]);
            for (var i = 1; i < input.Length; i++)
            {
                simpleLinkedList.InsertLast(input[i]);
            }
            return simpleLinkedList;
        }
    }
}