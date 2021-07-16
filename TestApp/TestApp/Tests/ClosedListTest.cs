using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Application;
using Xunit;

namespace TestApp.Tests
{
    public class ClosedListTest
    {
        [Fact]
        public void ClosedList_Init_RightFieldsValues()
        {
            // Arrange
            ClosedList<int> list = new ClosedList<int>() { 1, 2, 3, 4, 5 };

            // Assert
            Assert.Equal(1, list.Head);
            Assert.Equal(1, list.Current);
            Assert.Equal(2, list.Next);
            Assert.Equal(5, list.Previous);
        }

        [Fact]
        public void ClosedList_MoveNext_RightFieldValues()
        {
            // Arrange
            ClosedList<string> list = new ClosedList<string>() { "one", "two", "three", "four", "five" };

            // Act
            list.MoveNext(3);

            // Assert
            Assert.Equal("one", list.Head);
            Assert.Equal("four", list.Current);
            Assert.Equal("five", list.Next);
            Assert.Equal("three", list.Previous);
        }

        [Fact]
        public void ClosedList_MoveNextWithCycle_RightFieldValues()
        {
            // Arrange
            ClosedList<string> list = new ClosedList<string>() { "one", "two", "three", "four", "five" };

            // Act
            list.MoveNext(27);

            // Assert
            Assert.Equal("one", list.Head);
            Assert.Equal("three", list.Current);
            Assert.Equal("four", list.Next);
            Assert.Equal("two", list.Previous);
        }

        [Fact]
        public void ClosedList_MoveBack_RightFieldsValues()
        {
            // Arrange
            ClosedList<int> list = new ClosedList<int>() { 1, 2, 3, 4, 5 };

            // Act
            list.MoveBack(3);

            // Assert
            Assert.Equal(1, list.Head);
            Assert.Equal(3, list.Current);
            Assert.Equal(4, list.Next);
            Assert.Equal(2, list.Previous);
        }

        [Fact]
        public void ClosedList_NegativeMoveNext_RightFieldsValues()
        {
            // Arrange
            ClosedList<int> list = new ClosedList<int>() { 1, 2, 3, 4, 5 };

            // Act
            list.MoveNext(-12);

            // Assert
            Assert.Equal(1, list.Head);
            Assert.Equal(4, list.Current);
            Assert.Equal(5, list.Next);
            Assert.Equal(3, list.Previous);
        }

        [Fact]
        public void ClosedList_NegativeMoveBack_RightFieldsValues()
        {
            // Arrange
            ClosedList<int> list = new ClosedList<int>() { 1, 2, 3, 4, 5 };

            // Act
            list.MoveBack(-9);

            // Assert
            Assert.Equal(1, list.Head);
            Assert.Equal(5, list.Current);
            Assert.Equal(1, list.Next);
            Assert.Equal(4, list.Previous);
        }

        [Fact]
        public void ClosedList_DiferentMoves_RightFieldsValues()
        {
            // Arrange
            ClosedList<int> list = new ClosedList<int>() { 1, 2, 3, 4, 5 };

            // Act
            list.MoveNext(23);
            list.MoveBack(15);
            list.MoveNext(-8);
            list.MoveBack(-12);
            list.MoveNext(0);

            // Assert
            Assert.Equal(1, list.Head);
            Assert.Equal(3, list.Current);
            Assert.Equal(4, list.Next);
            Assert.Equal(2, list.Previous);
        }
    }
}
