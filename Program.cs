/// This program calculates the number of litres of paint required to paint a room
/// based on the dimensions of its walls and unpaintable areas,
/// and the number of coats that will have to be applied
namespace AmountOfPaintCalculator
{
    /// <summary>
    /// Represents a surface within a room where the lengths are in metres
    /// </summary>
    struct Surface(double Width, double Height)
    {
        public double Width = Width;
        public double Height = Height;
    }

    class Program
    {
        /// <summary>
        /// The area that one litre of paint can cover (1 litre = 11 square meters)
        /// </summary>
        const int PaintVolumeToSurfaceArea = 11;

        /// <summary>
        /// Calculates the amount of paint required to paint a room based on the dimensions of its walls and unpaintable areas,
        /// and the number of coats that will have to be applied
        /// </summary>
        /// <param name="Walls">The surfaces that will be painted</param>
        /// <param name="UnpaintableSurfaces">The surfaces within walls that should not be painted such as doors and windows</param>
        /// <param name="CoatsOfPaint">Number of coats to paint the walls with</param>
        /// <returns>Number of litres to paint the entire room</returns>
        static double RequiredAmountOfPaint(
            Surface[] Walls,
            Surface[] UnpaintableSurfaces,
            uint CoatsOfPaint
        )
        {
            // Calculate total wall area
            double WallArea = 0;
            foreach (Surface Wall in Walls)
            {
                WallArea += Wall.Width * Wall.Height;
            }

            // Cut out unpaintable areas
            double UnpaintableArea = 0;
            foreach (Surface UnpaintableSurface in UnpaintableSurfaces)
            {
                UnpaintableArea += UnpaintableSurface.Width * UnpaintableSurface.Height;
            }

            // Get the total area of all surfaces
            double TotalArea = WallArea - UnpaintableArea;

            // Make sure the area greater than 0
            if (TotalArea < 0)
            {
                TotalArea = 0;
            }

            // Apply area to paint ratio to find out how much paint is required for one layer
            double LitresOfOneLayerPaint = TotalArea * PaintVolumeToSurfaceArea;

            // Calculate the total number of litres to paint the room with a set number of coats
            double TotalAmountOfPaint = LitresOfOneLayerPaint * CoatsOfPaint;

            return TotalAmountOfPaint;
        }

        static void Main()
        {
            Surface[] Walls =
            [
                new Surface(10, 10),
                new Surface(10, 10),
                new Surface(20, 50),
                new Surface(10, 10),
                new Surface(10, 10),
                new Surface(10, 10),
            ];

            Surface[] Unpaintable = [new Surface(10, 50), new Surface(10, 50)];

            Console.WriteLine(RequiredAmountOfPaint(Walls, Unpaintable, 3));
        }
    }
}
