namespace HideAndSeek
{
    public static class House
    {
        public static readonly Location Entry;

        static House()
        {
            Entry = new Location("Entry");
            var garage = new Location("Garage");
            var hallway = new Location("Hallway");
            var livingRoom = new Location("Living Room");
            var bathroom = new Location("Bathroom");
            var kitchen = new Location("Kitchen");
            var landing = new Location("Landing");
            var kidsRoom = new Location("Kids Room");
            var pantry = new Location("Pantry");
            var nursery = new Location("Nursery");
            var secondBathroom = new Location("Second Bathroom");
            var masterBedroom = new Location("Master Bedroom");
            var masterBath = new Location("Master Bath");
            var attic = new Location("Attic");

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
        }
    }
}
