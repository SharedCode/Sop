﻿using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sop.Samples;

namespace SopClientTests
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class AcceptanceTests
    {
        [TestMethod]
        public void PeopleDirectoryWithUpdateDeleteScenarioTest()
        {
            var pd = new PeopleDirectoryWithUpdateDelete();
            // Populate will Insert, Update, Delete people directory records.
            pd.Run();
            // Read All records.
            pd.Run();
            // Delete SOP data folder now that we're done.
            pd.DeleteDataFolder(PeopleDirectoryWithUpdateDelete.ServerFilename);
        }
        [TestMethod]
        public void PeopleDirectoryXmlSerializableObjectScenarioTest()
        {
            var pd = new PeopleDirectoryXmlSerializableObject();
            // Populate will Insert, Update, Delete people directory records.
            pd.Run();
            // Read All records.
            pd.Run();
            // Delete SOP data folder now that we're done.
            pd.DeleteDataFolder(PeopleDirectoryXmlSerializableObject.ServerFilename);
        }
        [TestMethod]
        public void ManageMultipleFilesScenarioTest()
        {
            var pd = new ManageMultipleFiles();
            // Populate will Insert, Update, Delete people directory records.
            pd.Run();
            // Read All records.
            pd.Run();
            // Delete SOP data folder now that we're done.
            pd.DeleteDataFolder(ManageMultipleFiles.ServerFilename);
        }

        [TestMethod]
        public void Store400ScenarioTest()
        {
            var pd = new Store400();
            // Store 400 is a mixture of battery tests stressing SOP Store mgmt & Transaction cycling.
            pd.Run();
            // Delete SOP data folder now that we're done.
            pd.DeleteDataFolder(Store400.ServerFilename);
        }

        [TestMethod]
        public void PeopleDirectoryWithBlobDataUpdateScenarioTest()
        {
            // another sanity & stress tests combined, showcasing Blob updates.
            var pd = new PeopleDirectoryWithBlobDataUpdate();
            // reduce iterations to 50K as this is a build acceptance test.
            pd.MaxCount = 50000;
            // populate
            pd.Run();
            // read all
            pd.Run();
            // Delete SOP data folder now that we're done.
            pd.DeleteDataFolder(PeopleDirectoryWithBlobDataUpdate.ServerFilename);
        }
        [TestMethod]
        public void ManyClientScenarioTest()
        {
            //Sop.Log.Logger.Instance.LogLevel = Sop.Log.LogLevels.Verbose;
            // Multiple SOP client simulator.
            var pd = new ManyClientSimulator();
            pd.DeleteDataFolder(ManyClientSimulator.ServerFilename);
            // simulate numerous concurrent clients.
            pd.ThreadCount = 150;
            pd.DataInsertionThreadCount = 40;
            pd.Threaded = true;
            pd.Run();
            // Delete SOP data folder now that we're done.
            pd.DeleteDataFolder(ManyClientSimulator.ServerFilename);
        }
    }
}
