using Aspose.Gis;
using Aspose.Gis.Common.Formats.MapInfo.GraphicalObjects;
using Aspose.Gis.Geometries;
using System.Numerics;

var layer = Drivers.Gpx.OpenLayer(@"C:\Users\pd51pyb\Documents\GitHub\323-Programmation_fonctionnelle\exos\rando\gpx\Running.gpx");

List<Trackpoint> points = new List<Trackpoint>();

// Lis le fichier et le met dans une liste
foreach (var feature in layer)
{
    // Vérifier la géométrie MultiLineString
    if (feature.Geometry.GeometryType == GeometryType.MultiLineString)
    {
        int index = 0;
        // Lire la piste
        var lines = (MultiLineString)feature.Geometry;
        foreach (var line in lines)
        {
            LineString ls = (LineString)line;

            foreach (var point in ls)
            {
                //Console.WriteLine(" X: " + point.X + " Y: " + point.Y + " Z: " + point.Z);
                Trackpoint trackpoint = new Trackpoint(index, point.Y,  point.X, point.Z );
                points.Add(trackpoint);
                index++;
            }
        }
    }
}

//////////////////////////////////////////////////////////////////// Exo 1.1 //////////////////////////////////////
// on veut seulement 1 point sur 5
List<Trackpoint> pointesOneInFive = points.Where(point => point.Id % 5 == 0).ToList();

//////////////////////////////////////////////////////////////////// Exo 1.1 //////////////////////////////////////
// Calculer la longueur du tracé, son dénivelé 

float longeur = points.Zip(points.Skip(1), (current, next) => Distance(current, next)).Sum();
float denivle = points.Zip(points.Skip(1), (current, next) => CalculDenivler(current, next)).Sum();

float Distance(Trackpoint current, Trackpoint next)
{
    return new Vector3((float)(next.Longitude - current.Longitude), (float)(next.Latitude - current.Latitude), (float)(next.Elevation - current.Elevation)).Length();
}

float CalculDenivler(Trackpoint current, Trackpoint next)
{
    return (float)(next.Elevation - current.Elevation);
}

Console.ReadLine();
internal class Trackpoint
{
    private int _id;
    private double _latitude;
    private double _longitude;
    private double _elevation;

    public Trackpoint(int id, double latitude, double longitude, double elevation)
    {
        _id = id;
        _latitude = latitude;
        _longitude = longitude;
        _elevation = elevation;
    }

    public double Latitude { get => _latitude; set => _latitude = value; }
    public double Longitude { get => _longitude; set => _longitude = value; }
    public double Elevation { get => _elevation; set => _elevation = value; }
    public int Id { get => _id; set => _id = value; }
}