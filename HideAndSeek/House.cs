namespace HideAndSeek
{
    public static class House
    {
        public static Random Random = new();

        public static readonly Location Entry;

        private static readonly IEnumerable<Location> locations;

        /// <summary>
        /// Gets a location by name
        /// </summary>
        /// <param name="name">The name of the location to find</param>
        /// <returns>The location, or Entry if no location by that name was found</returns>
        public static Location GetLocationByName(string name)
        {
            var found = locations.Where(l => l.Name == name);
            return found.Count() > 0 ? found.First() : Entry;
        }

        /// <summary>
        /// Gets a random exit from the location
        /// </summary>
        /// <param name="location">Location to get the random exit from</param>
        /// <returns>One of the locatin's exits selected randomly</returns>
        public static Location RandomExit(Location location) =>
            GetLocationByName(
                location
                    .Exits
                    .OrderBy(exit => exit.Value.Name)
                    .Select(exit => exit.Value.Name)
                    .Skip(Random.Next(0, location.ExitList.Count()))
                    .First());

        static House()
        {
            Entry = new Location("Entry");
            var hallway = new Location("Hallway");
            var livingRoom = new LocationWithHidingPlace("Living Room", "behind the sofa");
            var kitchen = new LocationWithHidingPlace("Kitchen", "next to the stove");
            var bathroom = new LocationWithHidingPlace("Bathroom", "behind the door");
            var landing = new Location("Landing");
            var masterBedroom = new LocationWithHidingPlace("Master Bedroom", "in the closet");
            var masterBath = new LocationWithHidingPlace("Master Bath", "in the bathtub");
            var secondBathroom = new LocationWithHidingPlace("Second Bathroom", "in the shower");
            var kidsRoom = new LocationWithHidingPlace("Kids Room", "under the bed");
            var nursery = new LocationWithHidingPlace("Nursery", "under the crib");
            var pantry = new LocationWithHidingPlace("Pantry", "inside a cabinet");
            var attic = new LocationWithHidingPlace("Attic", "in a trunk");
            var garage = new LocationWithHidingPlace("Garage", "behind the car");

            // entry 2 exits
            Entry.AddExit(Direction.Out, garage);
            Entry.AddExit(Direction.East, hallway);

            // hallway 4 exits( +1 back to entry)
            hallway.AddExit(Direction.South, livingRoom);
            hallway.AddExit(Direction.North, bathroom);
            hallway.AddExit(Direction.Northwest, kitchen);
            hallway.AddExit(Direction.Up, landing);

            // landing 6 exits( +1 back to hallway)
            landing.AddExit(Direction.South, pantry);
            landing.AddExit(Direction.West, secondBathroom);
            landing.AddExit(Direction.Southwest, nursery);
            landing.AddExit(Direction.Southeast, kidsRoom);
            landing.AddExit(Direction.Northwest, masterBedroom);
            landing.AddExit(Direction.Up, attic);

            masterBedroom.AddExit(Direction.East, masterBath);

            // Add all of the locations to the private locations collection
            locations = new List<Location>() {
                Entry,
                hallway,
                kitchen,
                bathroom,
                livingRoom,
                landing,
                masterBedroom,
                secondBathroom,
                kidsRoom,
                nursery,
                pantry,
                attic,
                garage,
                attic,
                masterBath,
            };
        }

        /// <summary>
        /// Check each hiding place to make sure no opponents are still hiding
        /// to reset the house between rounds (or tests)
        /// </summary>
        public static void ClearHidingPlaces()
        {
            foreach (var location in locations)
                if (location is LocationWithHidingPlace hidingPlace)
                    hidingPlace.CheckHidingPlace();
        }
    }
}
