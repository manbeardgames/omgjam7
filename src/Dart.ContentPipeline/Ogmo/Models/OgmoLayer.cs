using System.Runtime.Serialization;

namespace Dart.ContentPipeline.Ogmo.Models
{
    [DataContract]
    public class OgmoLayer
    {
        //  -------------------------------------------------------------------
        //  These properties are used by Tile, Grid, Decal, and Entity layers
        //  -------------------------------------------------------------------
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "_eid")]
        public string EID { get; set; }

        [DataMember(Name = "offsetX")]
        public int OffsetX { get; set; }

        [DataMember(Name = "offsetY")]
        public int OffsetY { get; set; }

        [DataMember(Name = "gridCellWidth")]
        public int GridCellWidth { get; set; }

        [DataMember(Name = "gridCellHeight")]
        public int GridCellHeight { get; set; }

        [DataMember(Name = "gridCellsX")]
        public int GridCellsX { get; set; }

        [DataMember(Name = "gridCellsY")]
        public int GridCellsY { get; set; }

        //  -------------------------------------------------------------------
        //  Used by Tile Layer Only
        //  -------------------------------------------------------------------
        [DataMember(Name = "tileset")]
        public string Tileset { get; set; }

        [DataMember(Name = "data")]
        public int[] Data { get; set; }

        [DataMember(Name = "data2D")]
        public int[][] Data2D { get; set; }

        [DataMember(Name = "exportMode")]
        public int ExportMode { get; set; }

        //  -------------------------------------------------------------------
        //  Used by Tile and Grid Layer
        //  -------------------------------------------------------------------
        [DataMember(Name = "arrayMode")]
        public int ArrayMode { get; set; }

        //  -------------------------------------------------------------------
        //  Used by Grid Layer Only
        //  -------------------------------------------------------------------
        [DataMember(Name = "grid")]
        public string[] Grid { get; set; }

        [DataMember(Name = "grid2D")]
        public string[][] Grid2D { get; set; }

        //  -------------------------------------------------------------------
        //  Used by Decal Layer Only
        //  -------------------------------------------------------------------
        //public string[] Decals { get; set; }

        [DataMember(Name = "folder")]
        public string Folder { get; set; }

        //  -------------------------------------------------------------------
        //  Used by Entity Layer Only
        //  -------------------------------------------------------------------
        //public string[] Entities { get; set; }






    }
}
