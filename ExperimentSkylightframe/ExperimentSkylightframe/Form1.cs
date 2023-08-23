using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static Tekla.Structures.Model.Position;
using Tekla.Structures.Model;
using Tekla.Structures.Geometry3d;
using Tekla.Structures.Model.UI;




namespace ExperimentSkylightframe
{
    public partial class Form1 : Form
    {
        private Model myModel = new Model();
        private Position.PlaneEnum planeEnum;
        private Position.DepthEnum depthEnum;
        private Position.RotationEnum rotationEnum;

        public Form1()
        {
            InitializeComponent();            

        }
        private void buttonInsertSkylightFrame_Click(object sender, EventArgs e)
        {
            if (myModel.GetConnectionStatus())
            {
                Tekla.Structures.Model.UI.Picker _picker = new Tekla.Structures.Model.UI.Picker();

                // Create the two points that will be used as the start and end point for the first beam from user input.
                Point startPoint1 = _picker.PickPoint("Pick the startpoint for SkylightFrame");
                Point endPoint1 = _picker.PickPoint("Pick the endpoint for SkylightFrame");

                // Calculate the direction vector between the two input points.
                Vector directionVector = new Vector(endPoint1 - startPoint1);
                directionVector.Normalize();

                // Define the distance between the beams (1000mm).
                double distance = double.TryParse(textBoxFrameWidth.Text.Trim(), out double result) ? result : 0.0; // In millimeters

                // Calculate the offset vector perpendicular to the direction vector.
                Vector offsetVector = new Vector(-directionVector.Y, directionVector.X, 0) * (distance / 2);

                // Calculate the start and end points for the first beam based on the offset vector.
                Point startPointBeam1 = startPoint1 + offsetVector;
                Point endPointBeam1 = endPoint1 + offsetVector;

                // Calculate the start and end points for the second beam based on the offset vector.
                Point startPointBeam2 = startPoint1 - offsetVector;
                Point endPointBeam2 = endPoint1 - offsetVector;

                // Create a new instance of the Beam class for the first beam based on the calculated points.
                Beam myBeam1 = new Beam(startPointBeam1, endPointBeam1);
                // Set the Beam's properties.
                myBeam1.Profile.ProfileString = "GVZ530.3";
                myBeam1.Material.MaterialString = textBoxMaterial.Text.Trim();
                myBeam1.Class = "0";
                myBeam1.Position.Plane = Position.PlaneEnum.LEFT;
                myBeam1.Position.Depth = Position.DepthEnum.FRONT;
                myBeam1.Position.Rotation = Position.RotationEnum.TOP;
                myBeam1.Insert();

                // Create a new instance of the Beam class for the second beam based on the calculated points.
                Beam myBeam2 = new Beam(endPointBeam2, startPointBeam2);
                // Set the Beam's properties.
                myBeam2.Profile.ProfileString = "GVZ530.3";
                myBeam2.Material.MaterialString = textBoxMaterial.Text.Trim();
                myBeam2.Class = "0";
                myBeam2.Position.Plane = Position.PlaneEnum.LEFT;
                myBeam2.Position.Depth = Position.DepthEnum.FRONT;
                myBeam2.Position.Rotation = Position.RotationEnum.TOP;
                myBeam2.Insert();
                // NEW PART:
                // Calculate perpendicular vectors to the original direction vector.
                Vector perpendicularVector1 = new Vector(directionVector.Y, -directionVector.X, 0);
                Vector perpendicularVector2 = new Vector(-directionVector.Y, directionVector.X, 0);

                // Calculate the start and end points for the perpendicular beams.
                Point startPointPerpendicular1 = startPoint1 - perpendicularVector1 * (distance / 2);
                Point endPointPerpendicular1 = startPoint1 + perpendicularVector1 * (distance / 2);

                Point startPointPerpendicular2 = endPoint1 - perpendicularVector2 * (distance / 2);
                Point endPointPerpendicular2 =  endPoint1 + perpendicularVector2 * (distance / 2);

                // Create a new instance of the Beam class for the perpendicular beams.
                Beam perpendicularBeam1 = new Beam(startPointPerpendicular1, endPointPerpendicular1);
                Beam perpendicularBeam2 = new Beam(startPointPerpendicular2,endPointPerpendicular2);

                // Set the properties for the perpendicular beams.
                perpendicularBeam1.Profile.ProfileString = "GVZ532.2";
                perpendicularBeam1.Material.MaterialString = textBoxMaterial.Text.Trim();
                perpendicularBeam1.Class = "0";
                perpendicularBeam1.Position.Plane = Position.PlaneEnum.MIDDLE;
                perpendicularBeam1.Position.Depth = Position.DepthEnum.FRONT;
                perpendicularBeam1.Position.Rotation = Position.RotationEnum.TOP;
                perpendicularBeam1.Insert();

                perpendicularBeam2.Profile.ProfileString = "GVZ532.2";
                perpendicularBeam2.Material.MaterialString = textBoxMaterial.Text.Trim();
                perpendicularBeam2.Class = "0";
                perpendicularBeam2.Position.Plane = Position.PlaneEnum.MIDDLE;
                perpendicularBeam2.Position.Depth = Position.DepthEnum.FRONT;
                perpendicularBeam2.Position.Rotation = Position.RotationEnum.TOP;
                perpendicularBeam2.Insert();
                // END OF NEW PART

                // Commit changes to the model.
                myModel.CommitChanges();
            }
            
        }
             

        
    }
}
