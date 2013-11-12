using LabelPrinter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Collections.Generic;

namespace LabelPrinter.Test
{
    [TestClass()]
    public class LabelStorageTest
    {
        [TestMethod()]
        public void ReadSaveTest()
        {
            var labels = new[] { 
                new Label("Addressee 1", 124323, "Address 1", "City 1"),
                new Label("Addressee 2", 324536, "Address 2", "City 2"),
                new Label("Addressee 3", 676775, "Address 3", "City 3")
            };
            var file = "test1.labels";
            LabelStorage.Save(file, labels);

            var labels1 = LabelStorage.Read(file);
            Assert.IsTrue(labels1
                .Zip(labels, (l1, l) => l1.Address == l.Address
                                     && l1.Addressee == l.Addressee
                                     && l1.PostalCode == l.PostalCode
                                     && l1.City == l.City)
                .All(it => it));
        }
    }
}
