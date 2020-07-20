using Foundation;
using System;
using UIKit;
using TrainingRooms;

namespace trainingrooms.ios
{
    public partial class ViewController : UITableViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            //var repo = new RoomRepository();
            //var rooms = repo.GetRooms();
            //var dataSource = new RoomsDatasource(rooms);
            //this.TableView.Source = dataSource;
            this.TableView.Source = new RoomsDatasource(
                    (new RoomRepository()).GetRooms()
                );
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);

            if (segue.Identifier == "detailSegue")
            {
                RoomsDatasource source = this.TableView.Source as RoomsDatasource;
                var room = source.GetItem(this.TableView.IndexPathForSelectedRow.Row);
                var target = segue.DestinationViewController as RoomDetailViewController;
                target.SetTrainingRoom(room);

            }
        }
    }
}