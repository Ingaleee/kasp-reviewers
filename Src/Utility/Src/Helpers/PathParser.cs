using Kasp1_Review.Src.Objects;

namespace Kasp1_Review.Src.Helpers
{
    public class PathParser
    {
        // TODO: make string extension
        public static FilePath FromString(string input)
        {
            var path = new FilePath();

            var pathSlices = input.Split(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar).ToList();
            if (pathSlices == null)
            {
                return null;
            }

            var file = pathSlices.LastOrDefault();
            path.Extension = Path.GetExtension(file);
            path.Name = Path.GetFileName(file);

            pathSlices.RemoveAt(pathSlices.Count - 1);
            path.Folders = pathSlices;

            return path;
        }
    }
}
