using System;
using UIKit;
using TrainingRooms;
using Foundation;
using System.Collections.Generic;
using System.Linq;

namespace trainingrooms.ios
{
    public class RoomsDatasource : UITableViewSource
    {
        private List<TrainingRoom> _rooms;

        public RoomsDatasource(List<TrainingRoom> rooms)
        {
            this._rooms = rooms;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell("roomCell");
            var room = this._rooms.ElementAtOrDefault(indexPath.Row);

            if (room != null)
            {
                cell.TextLabel.Text = room.Name;
                cell.DetailTextLabel.Text = room.Location;
            }
            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return this._rooms.Count;
        }

        public TrainingRoom GetItem(int row)
        {
            return this._rooms.ElementAtOrDefault(row);
        }
    }
}
