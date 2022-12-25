using HideAndSeek;

namespace HideAndSeekTests
{
    [TestClass]
    public class LocationTests
    {
        private Location center;
        /// <summary>
        /// Initializes each unit test by setting creating a new the center location
        /// and adding a room in each direction before the test
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            // You'll use this to create a bunch of locations before each test
            center = new Location("Center room");
            Assert.AreSame("Center room", center.ToString());
            Assert.AreEqual(0, center.ExitList.Count());

            center.AddExit(Direction.North, new Location("North Room"));
            Assert.AreEqual(1, center.ExitList.Count());

            center.AddExit(Direction.South, new Location("South Room"));
            center.AddExit(Direction.East, new Location("East Room"));
            center.AddExit(Direction.West, new Location("West Room"));
            center.AddExit(Direction.Northeast, new Location("Northeast Room"));
            center.AddExit(Direction.Northwest, new Location("Northwest Room"));
            center.AddExit(Direction.Southwest, new Location("Southwest Room"));
            center.AddExit(Direction.Southeast, new Location("Southeast Room"));
            center.AddExit(Direction.Up, new Location("Up Room"));
            center.AddExit(Direction.Down, new Location("Down Room"));
            center.AddExit(Direction.In, new Location("In Room"));
            center.AddExit(Direction.Out, new Location("Out Room"));

            Assert.AreEqual(12, center.ExitList.Count());

        }
        /// <summary>
        /// Make sure GetExit returns the location in a direction only if it exists
        /// </summary>
        [TestMethod]
        public void TestGetExit()
        {
            // This test will make sure the GetExit method works
        }
        /// <summary>
        /// Validates that the exit lists are working
        /// </summary>
        [TestMethod]
        public void TestExitList()
        {
            // This test will make sure the ExitList property works
        }
        /// <summary>
        /// Validates that each room’s name and return exit is created correctly
        /// </summary>
        [TestMethod]
        public void TestReturnExits()
        {
            // This test will test navigating through the center Location
        }
        /// <summary>
        /// Add a hall to one of the rooms and make sure the hall room’s names
        /// and return exits are created correctly
        /// </summary>
        [TestMethod]
        public void TestAddHall()
        {
            // This test will add a hallway with two locations and make sure they work
        }
    }
}