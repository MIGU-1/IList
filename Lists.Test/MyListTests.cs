using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Lists.Entity;
using Lists.ListLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lists.Test
{
    [TestClass()]
    public class MyListTests
    {
        [TestMethod()]
        public void Add_First_ShouldReturnIndexZero()
        {
            //Arrange
            MyList list = new MyList();
            //Act
            int index = list.Add("M�ller");
            //Assert
            Assert.AreEqual(0, index);
        }

        [TestMethod()]
        public void Add_Third_ShouldReturnIndexTwo()
        {
            //Arrange
            MyList list = new MyList();
            //Act
            list.Add("M�ller");
            list.Add("Maier");
            int index = list.Add("Huber");
            //Assert
            Assert.AreEqual(2, index);
        }

        [TestMethod()]
        public void IndexOf_OneOfOne_ShouldReturnIndexZero()
        {
            //Arrange
            MyList list = new MyList();
            list.Add("Maier");
            //Act
            int index = list.IndexOf("Maier");
            //Assert
            Assert.AreEqual(0, index);
        }

        [TestMethod()]
        public void IndexOf_Middle_ShouldReturnIndexOne()
        {
            //Arrange
            MyList list = new MyList();
            list.Add("Maier");
            list.Add("M�ller");
            list.Add("Huber");
            //Act
            int index = list.IndexOf("M�ller");
            //Assert
            Assert.AreEqual(1, index);
        }

        [TestMethod()]
        public void IndexOf_MiddleIntObject_ShouldReturnIndexOne()
        {
            //Arrange
            MyList list = new MyList();
            list.Add(3);
            list.Add(4);
            list.Add(5);
            //Act
            int index = list.IndexOf(4);
            //Assert
            Assert.AreEqual(1, index);
        }

        [TestMethod()]
        public void IndexOf_NotInList_ShouldReturnMinusOne()
        {
            //Arrange
            MyList list = new MyList();
            list.Add(3);
            list.Add(4);
            list.Add(5);
            //Act
            int index = list.IndexOf(6);
            //Assert
            Assert.AreEqual(-1, index);
        }

        [TestMethod()]
        public void GetEnumerator_ThreeElements_ShouldReturnValidData()
        {
            //Arrange
            MyList list = new MyList();
            list.Add(3);
            list.Add(4);
            list.Add(5);
            //IEnumerator enumerator = list.GetEnumerator();
            //Act
            StringBuilder text = new StringBuilder();
            //while (enumerator.MoveNext())
            //{
            //    text.Append(enumerator.Current.ToString());
            //}
            foreach (var item in list)
            {
                text.Append(item);
            }
            //Assert
            Assert.AreEqual("345", text.ToString());
        }

        [TestMethod()]
        public void Clear_EmptyList_ShouldBeEmpty()
        {
            //Arrange
            MyList list = new MyList();
            //Act
            list.Clear();
            //Assert
            Assert.AreEqual(0, list.Count);
        }

        [TestMethod()]
        public void Clear_ListWithSomeEntries_ShouldBeEmpty()
        {
            //Arrange
            MyList list = new MyList();
            list.Add(3);
            list.Add(4);
            list.Add(5);
            //Act
            list.Clear();
            //Assert
            Assert.AreEqual(0, list.Count);
        }

        [TestMethod()]
        public void TContains_EmptyList_ShouldReturnFalse()
        {
            //Arrange
            MyList list = new MyList();
            //Act
            bool found = list.Contains(5);
            //Assert
            Assert.IsFalse(found);
        }

        [TestMethod()]
        public void Contains_ItemIsNotInList_ShouldReturnFalse()
        {
            //Arrange
            MyList list = new MyList();
            list.Add(3);
            list.Add(4);
            list.Add(5);
            //Act
            bool found = list.Contains(6);
            //Assert
            Assert.IsFalse(found);
        }

        [TestMethod()]
        public void Contains_ItemInList_ShouldReturnTrue()
        {
            //Arrange
            MyList list = new MyList();
            list.Add(3);
            list.Add(4);
            list.Add(5);
            //Act
            bool found = list.Contains(5);
            //Assert
            Assert.IsTrue(found);
        }

        [TestMethod()]
        public void Insert_OnIndexOne_ShouldReturnIndexOne()
        {
            //Arrange
            MyList list = new MyList();
            list.Add(3);
            list.Add(4);
            list.Add(5);
            //Act
            list.Insert(1, 99);
            //Assert
            Assert.AreEqual(1, list.IndexOf(99));
        }

        [TestMethod()]
        public void Insert_Zero_ShouldReturnIndexZero()
        {
            //Arrange
            MyList list = new MyList();
            list.Add(3);
            list.Add(4);
            list.Add(5);
            //Act
            list.Insert(0, 99);
            //Assert
            Assert.AreEqual(0, list.IndexOf(99));
        }

        [TestMethod()]
        public void Insert_End_ShouldReturnIndexThree()
        {
            //Arrange
            MyList list = new MyList();
            list.Add(3);
            list.Add(4);
            list.Add(5);
            //Act
            list.Insert(3, 99);
            //Assert
            Assert.AreEqual(3, list.IndexOf(99));
        }

        [TestMethod()]
        public void Insert_IndexTooLarge_ShouldReturnMinusOne()
        {
            //Arrange
            MyList list = new MyList();
            list.Add(3);
            list.Add(4);
            list.Add(5);
            //Act
            list.Insert(4, 99);
            //Assert
            Assert.AreEqual(-1, list.IndexOf(99));
        }

        [TestMethod()]
        public void T19_Insert_IndexNegative_ShouldReturnMinusOne()
        {
            //Arrange
            MyList list = new MyList();
            list.Add(3);
            list.Add(4);
            list.Add(5);
            //Act
            list.Insert(-1, 99);
            //Assert
            Assert.AreEqual(-1, list.IndexOf(99));
        }

        [TestMethod()]
        public void Insert_EmptyList_ShouldReturnIndexZero()
        {
            //Arrange
            MyList list = new MyList();
            //Act
            list.Insert(0, 99);
            //Assert
            Assert.AreEqual(0, list.IndexOf(99));
        }

        [TestMethod()]
        public void Remove_MiddleElement_ShouldReturnCountTwo()
        {
            //Arrange
            MyList list = new MyList();
            list.Add(3);
            list.Add(4);
            list.Add(5);
            //Act
            list.Remove(4);
            //Assert
            Assert.AreEqual(2, list.Count);
            Assert.AreEqual(-1, list.IndexOf(4));
        }

        [TestMethod()]
        public void Remove_FirstElement_ShouldSetNewFirstElement()
        {
            //Arrange
            MyList list = new MyList();
            list.Add(3);
            list.Add(4);
            list.Add(5);
            //Act
            list.Remove(3);
            //Assert
            Assert.AreEqual(2, list.Count);
            Assert.AreEqual(-1, list.IndexOf(3));
            Assert.AreEqual(0, list.IndexOf(4));
        }

        [TestMethod()]
        public void Remove_LastElement_ShouldReturnCountTwo()
        {
            //Arrange
            MyList list = new MyList();
            list.Add(3);
            list.Add(4);
            list.Add(5);
            //Act
            list.Remove(5);
            //Assert
            Assert.AreEqual(2, list.Count);
            Assert.AreEqual(-1, list.IndexOf(5));
            Assert.AreEqual(1, list.IndexOf(4));
        }

        [TestMethod()]
        public void Remove_ElementNotInList_ShouldChangeNothing()
        {
            //Arrange
            MyList list = new MyList();
            list.Add(3);
            list.Add(4);
            list.Add(5);
            //Act
            list.Remove(6);
            //Assert
            Assert.AreEqual(3, list.Count);
        }

        [TestMethod()]
        public void Remove_EmptyList_ShouldChangeNothing()
        {
            //Arrange
            MyList list = new MyList();
            //Act
            list.Remove(6);
            //Assert
            Assert.AreEqual(0, list.Count);
        }


        [TestMethod()]
        public void RemoveAt_MiddleElement_ShouldReturnCountTwo()
        {
            //Arrange
            MyList list = new MyList();
            list.Add(3);
            list.Add(4);
            list.Add(5);
            //Act
            list.RemoveAt(1);
            //Assert
            Assert.AreEqual(2, list.Count);
            Assert.AreEqual(-1, list.IndexOf(4));
        }

        [TestMethod()]
        public void RemoveAt_FirstElement_ShouldSetNewFirstElement()
        {
            //Arrange
            MyList list = new MyList();
            list.Add(3);
            list.Add(4);
            list.Add(5);
            //Act
            list.RemoveAt(0);
            //Assert
            Assert.AreEqual(2, list.Count);
            Assert.AreEqual(-1, list.IndexOf(3));
            Assert.AreEqual(0, list.IndexOf(4));
        }

        [TestMethod()]
        public void RemoveAt_LastElement_ShouldReturnCountTwo()
        {
            //Arrange
            MyList list = new MyList();
            list.Add(3);
            list.Add(4);
            list.Add(5);
            //Act
            list.RemoveAt(2);
            //Assert
            Assert.AreEqual(2, list.Count);
            Assert.AreEqual(-1, list.IndexOf(5));
            Assert.AreEqual(1, list.IndexOf(4));
        }

        [TestMethod()]
        public void RemoveAt_ElementNotInList_ShouldChangeNothing()
        {
            //Arrange
            MyList list = new MyList();
            list.Add(3);
            list.Add(4);
            list.Add(5);
            //Act
            list.RemoveAt(3);
            //Assert
            Assert.AreEqual(3, list.Count);
        }

        [TestMethod()]
        public void RemoveAt_EmptyList_ShouldChangeNothing()
        {
            //Arrange
            MyList list = new MyList();
            //Act
            list.RemoveAt(0);
            //Assert
            Assert.AreEqual(0, list.Count);
        }


        [TestMethod()]
        public void CopyTo_FullList_ShouldReturnFilledArray()
        {
            //Arrange
            MyList list = new MyList();
            list.Add(3);
            list.Add(4);
            list.Add(5);
            int[] expected = { 3, 4, 5 };
            object[] targetArray = new object[3];
            //Act
            list.CopyTo(targetArray, 0);
            //Assert
            CollectionAssert.AreEqual(expected, targetArray);
        }

        [TestMethod()]
        public void CopyTo_PartList_ShouldReturnArrayWithNullAtEnd()
        {
            //Arrange
            MyList list = new MyList();
            list.Add(3);
            list.Add(4);
            list.Add(5);
            int?[] expected = { 4, 5, null };
            object[] targetArray = new object[3];
            //Act
            list.CopyTo(targetArray, 1);
            //Assert
            CollectionAssert.AreEqual(expected, targetArray);
        }

        [TestMethod()]
        public void CopyTo_LastElement_ShouldReturnArrayWithOneElement()
        {
            //Arrange
            MyList list = new MyList();
            list.Add(3);
            list.Add(4);
            list.Add(5);
            int?[] expected = { 5 };
            object[] targetArray = new object[1];
            //Act
            list.CopyTo(targetArray, 2);
            //Assert
            CollectionAssert.AreEqual(expected, targetArray);
        }
        [TestMethod()]
        public void CopyTo_TargetTooSmall_ShouldLeftArrayEmpty()
        {
            //Arrange
            MyList list = new MyList();
            list.Add(3);
            list.Add(4);
            list.Add(5);
            object[] expected = { null, null };
            object[] targetArray = new object[2];
            //Act
            list.CopyTo(targetArray, 0);
            //Assert
            CollectionAssert.AreEqual(expected, targetArray);
        }



        [TestMethod()]
        public void Indexer_InsertMiddle_ShouldIncreaseList()
        {
            //Arrange
            MyList list = new MyList();
            list.Add(3);
            list.Add(4);
            list.Add(5);
            //Act
            list[1] = 99;
            //Assert
            Assert.AreEqual(1, list.IndexOf(99));
        }

        [TestMethod()]
        public void Indexer_InsertFirst_ShouldReturnCorrectIndex()
        {
            //Arrange
            MyList list = new MyList();
            list.Add(3);
            list.Add(4);
            list.Add(5);
            //Act
            list[0] = 99;
            //Assert
            Assert.AreEqual(0, list.IndexOf(99));
        }

        [TestMethod()]
        public void Indexer_ReadMiddle_ShouldReturnCorrectValue()
        {
            //Arrange
            MyList list = new MyList();
            list.Add(3);
            list.Add(4);
            list.Add(5);
            //Act
            var value = list[0];
            //Assert
            Assert.AreEqual(3, value);
        }

        [TestMethod()]
        public void Sort_SortPeopleOnAge_ShouldReturnCorrectOrder()
        {
            //Arrange

            MyList myList = new MyList();
            Person person1 = new Person("Max1", "Mustermann", 10, 5270, 1234);
            Person person2 = new Person("Max2", "Mustermann", 12, 3380, 1235);
            Person person3 = new Person("Max3", "Mustermann", 11, 5634, 1236);
            Person person4 = new Person("Max4", "Mustermann", 14, 1234, 1237);
            Person person5 = new Person("Max5", "Mustermann", 13, 5270, 1238);
            Person person6 = new Person("Max6", "Mustermann", 15, 3380, 1239);
            Person person7 = new Person("Max7", "Mustermann", 16, 5634, 1240);
            Person person8 = new Person("Max8", "Mustermann", 17, 1234, 1241);

            myList.Add(person1);
            myList.Add(person2);
            myList.Add(person3);
            myList.Add(person4);
            myList.Add(person5);
            myList.Add(person6);
            myList.Add(person7);
            myList.Add(person8);

            //Act

            MyList.Sort(myList, Person.SortOnAgeDescending());

            //Assert

            Assert.AreEqual(myList[0], person8);
            Assert.AreEqual(myList[1], person7);
            Assert.AreEqual(myList[2], person6);
            Assert.AreEqual(myList[3], person4);
            Assert.AreEqual(myList[4], person5);
            Assert.AreEqual(myList[5], person2);
            Assert.AreEqual(myList[6], person3);
            Assert.AreEqual(myList[7], person1);
        }

        [TestMethod()]
        public void Sort_SortPeopleOnPostCode_ShouldReturnCorrectOrder()
        {
            //Arrange

            MyList myList = new MyList();
            Person person1 = new Person("Max1", "Mustermann", 10, 5270, 1234);
            Person person2 = new Person("Max2", "Mustermann", 11, 5271, 1235);
            Person person3 = new Person("Max3", "Mustermann", 12, 5272, 1236);
            Person person4 = new Person("Max4", "Mustermann", 13, 5273, 1237);
            Person person5 = new Person("Max5", "Mustermann", 14, 5274, 1238);
            Person person6 = new Person("Max6", "Mustermann", 15, 5275, 1239);
            Person person7 = new Person("Max7", "Mustermann", 16, 5276, 1240);
            Person person8 = new Person("Max8", "Mustermann", 17, 5277, 1241);

            myList.Add(person1);
            myList.Add(person2);
            myList.Add(person3);
            myList.Add(person4);
            myList.Add(person5);
            myList.Add(person6);
            myList.Add(person7);
            myList.Add(person8);

            //Act

            MyList.Sort(myList, Person.SortOnPostCodeDescending());

            //Assert

            Assert.AreEqual(myList[0], person8);
            Assert.AreEqual(myList[1], person7);
            Assert.AreEqual(myList[2], person6);
            Assert.AreEqual(myList[3], person5);
            Assert.AreEqual(myList[4], person4);
            Assert.AreEqual(myList[5], person3);
            Assert.AreEqual(myList[6], person2);
            Assert.AreEqual(myList[7], person1);

        }

        [TestMethod()]
        public void Sort_SortPeopleOnDefault_ShouldReturnCorrectOrder()
        {
            //Arrange

            MyList myList = new MyList();
            Person person1 = new Person("Max1", "Mustermann", 10, 5270, 1234);
            Person person2 = new Person("Max2", "Mustermann", 11, 3380, 1235);
            Person person3 = new Person("Max3", "Mustermann", 12, 5634, 1236);
            Person person4 = new Person("Max4", "Mustermann", 13, 1234, 1237);
            Person person5 = new Person("Max5", "Mustermann", 14, 5270, 1238);
            Person person6 = new Person("Max6", "Mustermann", 15, 3380, 1239);
            Person person7 = new Person("Max7", "Mustermann", 16, 5634, 1240);
            Person person8 = new Person("Max8", "Mustermann", 17, 1234, 1241);

            myList.Add(person1);
            myList.Add(person2);
            myList.Add(person3);
            myList.Add(person4);
            myList.Add(person5);
            myList.Add(person6);
            myList.Add(person7);
            myList.Add(person8);

            //Act

            MyList.Sort(myList);

            //Assert

            Assert.AreEqual(myList[0], person8);
            Assert.AreEqual(myList[1], person7);
            Assert.AreEqual(myList[2], person6);
            Assert.AreEqual(myList[3], person5);
            Assert.AreEqual(myList[4], person4);
            Assert.AreEqual(myList[5], person3);
            Assert.AreEqual(myList[6], person2);
            Assert.AreEqual(myList[7], person1);

        }

        [TestMethod()]
        public void Sort_SortPeopleOnSvnrNumber_ShouldReturnCorrectOrder()
        {
            //Arrange

            MyList myList = new MyList();
            Person person1 = new Person("Max1", "Mustermann", 10, 5270, 1234);
            Person person2 = new Person("Max2", "Mustermann", 11, 3380, 1235);
            Person person3 = new Person("Max3", "Mustermann", 12, 5634, 1236);
            Person person4 = new Person("Max4", "Mustermann", 13, 1234, 1237);
            Person person5 = new Person("Max5", "Mustermann", 14, 5270, 1238);
            Person person6 = new Person("Max6", "Mustermann", 15, 3380, 1239);
            Person person7 = new Person("Max7", "Mustermann", 16, 5634, 1240);
            Person person8 = new Person("Max8", "Mustermann", 17, 1234, 1241);

            myList.Add(person1);
            myList.Add(person2);
            myList.Add(person3);
            myList.Add(person4);
            myList.Add(person5);
            myList.Add(person6);
            myList.Add(person7);
            myList.Add(person8);

            //Act

            MyList.Sort(myList, Person.SortOnSvnrDescending());

            //Assert

            Assert.AreEqual(myList[0], person8);
            Assert.AreEqual(myList[1], person7);
            Assert.AreEqual(myList[2], person6);
            Assert.AreEqual(myList[3], person5);
            Assert.AreEqual(myList[4], person4);
            Assert.AreEqual(myList[5], person3);
            Assert.AreEqual(myList[6], person2);
            Assert.AreEqual(myList[7], person1);

        }
    }
}