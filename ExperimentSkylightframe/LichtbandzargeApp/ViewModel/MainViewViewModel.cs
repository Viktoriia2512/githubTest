using LichtbandzargeApp.Commands;
using LichtbandzargeApp.ViewModel;
using LichtbandzargeApp.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using Tekla.Structures.Model;
using static Tekla.Structures.Model.Position;
using TSG = Tekla.Structures.Geometry3d;
using Tekla.Structures.Model.UI;

using Microsoft.Win32;
using System.Windows.Media.TextFormatting;

namespace LichtbandzargeApp.ViewModel
{
    public class MainViewViewModel : ViewModelBase
    {
        private Model myModel;        
        private string _frameWidth;
        ////NEW PROPERTY to control the transparency state:
        //private bool _isSkylightFrameHighlighted;

        //public bool IsSkylightFrameHighlighted
        //{
        //    get { return _isSkylightFrameHighlighted; }
        //    set { _isSkylightFrameHighlighted = value; OnPropertyChanged(nameof(IsSkylightFrameHighlighted)); }
        //}
        //NEW:
        private List<Beam> newlyInsertedBeams = new List<Beam>();
        public string FrameWidth
        {
            get { return _frameWidth; }
            set { _frameWidth = value; OnPropertyChanged(nameof(FrameWidth)); }
        }

        private string _material;
        public string Material
        {
            get { return _material; }
            set { _material = value; OnPropertyChanged(nameof(Material)); }
        }
        public MainViewViewModel()
        {
            this.myModel = new Model();
            
        }

        private ICommand insertFrameCommand;
        public ICommand InsertFrameCommand => new CustomCommandImplementation(InsertFrameByPickingTwoPoints);
        private void InsertFrameByPickingTwoPoints(object parameter)
        {
            
            if (myModel.GetConnectionStatus())
            {
                Tekla.Structures.Model.UI.Picker _picker = new Tekla.Structures.Model.UI.Picker();

                // Create the two points that will be used as the start and end point for the first beam from user input.
                TSG.Point startPoint1 = _picker.PickPoint("Pick the startpoint for SkylightFrame");
                TSG.Point endPoint1 = _picker.PickPoint("Pick the endpoint for SkylightFrame");

                // Calculate the direction vector between the two input points.
                TSG.Vector directionVector = new TSG.Vector(endPoint1 - startPoint1);
                directionVector.Normalize();

                // Define the distance between the beams (1000mm).
                //double distance = double.TryParse(textBoxFrameWidth.Text.Trim(), out double result) ? result : 0.0; // In millimeters
                double distance = double.TryParse(FrameWidth, out double result) ? result : 0.0; // In millimeters
                // Calculate the offset vector perpendicular to the direction vector.
                TSG.Vector offsetVector = new TSG.Vector(-directionVector.Y, directionVector.X, 0) * (distance / 2);

                // Calculate the start and end points for the first beam based on the offset vector.
                TSG.Point startPointBeam1 = startPoint1 + offsetVector;
                TSG.Point endPointBeam1 = endPoint1 + offsetVector;

                // Calculate the start and end points for the second beam based on the offset vector.
                TSG.Point startPointBeam2 = startPoint1 - offsetVector;
                TSG.Point endPointBeam2 = endPoint1 - offsetVector;

                // Create a new instance of the Beam class for the first beam based on the calculated points.
                Beam myBeam1 = new Beam(startPointBeam1, endPointBeam1);
                // Set the Beam's properties.
                myBeam1.Profile.ProfileString = "GVZ530.3";
                myBeam1.Material.MaterialString = Material;//"S235";//textBoxMaterial.Text.Trim();
                myBeam1.Class = "0";
                myBeam1.Position.Plane = Position.PlaneEnum.LEFT;
                myBeam1.Position.Depth = Position.DepthEnum.FRONT;
                myBeam1.Position.Rotation = Position.RotationEnum.TOP;
                myBeam1.Insert();

                // Create a new instance of the Beam class for the second beam based on the calculated points.
                Beam myBeam2 = new Beam(endPointBeam2, startPointBeam2);
                // Set the Beam's properties.
                myBeam2.Profile.ProfileString = "GVZ530.3";
                myBeam2.Material.MaterialString = Material; //"S235";//textBoxMaterial.Text.Trim();
                myBeam2.Class = "0";
                myBeam2.Position.Plane = Position.PlaneEnum.LEFT;
                myBeam2.Position.Depth = Position.DepthEnum.FRONT;
                myBeam2.Position.Rotation = Position.RotationEnum.TOP;
                myBeam2.Insert();                
                // Calculate perpendicular vectors to the original direction vector.
                TSG.Vector perpendicularVector1 = new TSG.Vector(directionVector.Y, -directionVector.X, 0);
                TSG.Vector perpendicularVector2 = new TSG.Vector(-directionVector.Y, directionVector.X, 0);

                // Calculate the start and end points for the perpendicular beams.
                TSG.Point startPointPerpendicular1 = startPoint1 - perpendicularVector1 * (distance / 2);
                TSG.Point endPointPerpendicular1 = startPoint1 + perpendicularVector1 * (distance / 2);

                TSG.Point startPointPerpendicular2 = endPoint1 - perpendicularVector2 * (distance / 2);
                TSG.Point endPointPerpendicular2 = endPoint1 + perpendicularVector2 * (distance / 2);

                // Create a new instance of the Beam class for the perpendicular beams.
                Beam perpendicularBeam1 = new Beam(startPointPerpendicular1, endPointPerpendicular1);
                Beam perpendicularBeam2 = new Beam(startPointPerpendicular2, endPointPerpendicular2);

                // Set the properties for the perpendicular beams.
                perpendicularBeam1.Profile.ProfileString = "GVZ532.2";
                perpendicularBeam1.Material.MaterialString = Material;
                perpendicularBeam1.Class = "0";
                perpendicularBeam1.Position.Plane = Position.PlaneEnum.MIDDLE;
                perpendicularBeam1.Position.Depth = Position.DepthEnum.FRONT;
                perpendicularBeam1.Position.Rotation = Position.RotationEnum.TOP;
                perpendicularBeam1.Insert();

                perpendicularBeam2.Profile.ProfileString = "GVZ532.2";
                perpendicularBeam2.Material.MaterialString = Material;
                perpendicularBeam2.Class = "0";
                perpendicularBeam2.Position.Plane = Position.PlaneEnum.MIDDLE;
                perpendicularBeam2.Position.Depth = Position.DepthEnum.FRONT;
                perpendicularBeam2.Position.Rotation = Position.RotationEnum.TOP;
                perpendicularBeam2.Insert();
                //////NEW PART.TRANSPARANCY:
                //if (IsSkylightFrameHighlighted)
                //{
                //    myBeam1.SetRenderMode(BeamRenderModeEnum.Transparent);
                //    myBeam2.SetRenderMode(BeamRenderModeEnum.Transparent);
                //    perpendicularBeam1.SetRenderMode(BeamRenderModeEnum.Transparent);
                //    perpendicularBeam2.SetRenderMode(BeamRenderModeEnum.Transparent);
                //}
                ////// END OF NEW PART
                /////NEW
                newlyInsertedBeams.Add(myBeam1);
                newlyInsertedBeams.Add(myBeam2);
                newlyInsertedBeams.Add(perpendicularBeam1);
                newlyInsertedBeams.Add(perpendicularBeam2);

                // Commit changes to the model.
                myModel.CommitChanges();
            }

        }
        private ICommand _highlightSkylightFrameCommand;
        public ICommand HighlightSkylightFrameCommand
        {
            get
            {
                if (_highlightSkylightFrameCommand == null)
                {
                    _highlightSkylightFrameCommand = new CustomCommandImplementation(HighlightSkylightFrame);
                }
                return _highlightSkylightFrameCommand;
            }
        }

        private void HighlightSkylightFrame(object parameter)
        {
            // Iterate through the inserted elements and change their property(color).
            var modelObjects = new Model().GetModelObjectSelector().GetAllObjectsWithType(ModelObject.ModelObjectEnum.BEAM);

            foreach (var beam in newlyInsertedBeams)
            {               
                    // Change the property(color) of the beam:
                    beam.Class = "1"; // Red color
                    beam.Modify();
                
            }

            // Commit changes to the model.
            new Model().CommitChanges();
        }
        //////NEW COMMAND: to toggle the transparency state when the  button is clicked.
        //private ICommand _toggleTransparencyCommand;

        //public ICommand ToggleTransparencyCommand
        //{
        //    get
        //    {
        //        if (_toggleTransparencyCommand == null)
        //        {
        //            _toggleTransparencyCommand = new CustomCommandImplementation(ToggleTransparency);
        //        }
        //        return _toggleTransparencyCommand;
        //    }
        //}

        //private void ToggleTransparency(object parameter)
        //{
        //    IsSkylightFrameHighlighted = !IsSkylightFrameHighlighted;
        //}

    }



}
