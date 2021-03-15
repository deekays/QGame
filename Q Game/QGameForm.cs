/* Program ID: Q Game
 * 
 * Purpose: Creating the first part of a Q Game to prove programming knowledge and get 100%
 * 
 * History:
 *      created October 2020 by Stephen Draper
 */

using Q_Game.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Q_Game
{
    /// <summary>
    /// Level creation form. Allows the user to create levels that they can save and load in the play area.
    /// </summary>
    public partial class QGameForm : Form
    {
        int rows = 0;
        int cols = 0;
        MyObject active; // creates an active object to keep track of which class has been selected, via the buttons
        string fileLocation = "";
        public bool MyClose = true; // we send this to the launcher
        
        /// <summary>
        /// Initialize
        /// </summary>
        public QGameForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Creates all the buttons down the left side. Created here because I was thinking it was the right way to make fancy
        /// pictures, and only learned later that I could have easily done them in the UI. Live and learn!
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QGameForm_Load(object sender, EventArgs e)
        {
            Size btnSize = new Size(150, 75);
            int top = 50;
            int increment = 75;
            
            // Creates the "None" button
            Button btnNone = new Button();
            btnNone.Image = Resources.none;
            btnNone.ImageAlign = ContentAlignment.MiddleLeft;
            btnNone.TextAlign = ContentAlignment.MiddleRight;
            btnNone.Text = "None";
            btnNone.Size = btnSize;
            btnNone.Location = new Point(0, top);
            top += increment;
            btnNone.Click += new EventHandler(btnNone_Click);
            pnlButtons.Controls.Add(btnNone);
            
            // Creates the "Wall" button
            Button btnWall = new Button();
            btnWall.Image = Resources.wall;
            btnWall.ImageAlign = ContentAlignment.MiddleLeft;
            btnWall.TextAlign = ContentAlignment.MiddleRight;
            btnWall.Text = "Wall";
            btnWall.Size = btnSize;
            btnWall.Location = new Point(0, top);
            top += increment;
            btnWall.Click += new EventHandler(btnWall_Click);
            pnlButtons.Controls.Add(btnWall);

            // Creates the "Red Door" button
            Button btnRedDoor = new Button();
            btnRedDoor.Image = Resources.redDoorSmall;
            btnRedDoor.ImageAlign = ContentAlignment.MiddleLeft;
            btnRedDoor.TextAlign = ContentAlignment.MiddleRight;
            btnRedDoor.Text = "Red Door";
            btnRedDoor.Size = btnSize;
            btnRedDoor.Location = new Point(0, top);
            top += increment;
            btnRedDoor.Click += new EventHandler(buttonRedDoor_Click);
            pnlButtons.Controls.Add(btnRedDoor);

            // Creates the "Green Door" button
            Button btnGreenDoor = new Button();
            btnGreenDoor.Image = Resources.greenDoorSmall;
            btnGreenDoor.ImageAlign = ContentAlignment.MiddleLeft;
            btnGreenDoor.TextAlign = ContentAlignment.MiddleRight;
            btnGreenDoor.Text = "Green Door";
            btnGreenDoor.Size = btnSize;
            btnGreenDoor.Location = new Point(0, top);
            top += increment;
            btnGreenDoor.Click += new EventHandler(buttonGreenDoor_Click);
            pnlButtons.Controls.Add(btnGreenDoor);

            // Creates the "Red Box" button
            Button btnRedBox = new Button();
            btnRedBox.Image = Resources.redBoxSmall;
            btnRedBox.ImageAlign = ContentAlignment.MiddleLeft;
            btnRedBox.TextAlign = ContentAlignment.MiddleRight;
            btnRedBox.Text = "Red Box";
            btnRedBox.Size = btnSize;
            btnRedBox.Location = new Point(0, top);
            top += increment;
            btnRedBox.Click += new EventHandler(buttonRedBox_Click);
            pnlButtons.Controls.Add(btnRedBox);

            // Creates the "Green Box" button
            Button btnGreenBox = new Button();
            btnGreenBox.Image = Resources.greenBoxSmall;
            btnGreenBox.ImageAlign = ContentAlignment.MiddleLeft;
            btnGreenBox.TextAlign = ContentAlignment.MiddleRight;
            btnGreenBox.Text = "Green Box";
            btnGreenBox.Size = btnSize;
            btnGreenBox.Location = new Point(0, top);
            top += increment;
            btnGreenBox.Click += new EventHandler(buttonGreenBox_Click);
            pnlButtons.Controls.Add(btnGreenBox);
        }

        /// <summary>
        /// Sets the active class for instantiation purposes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWall_Click(object sender, EventArgs e)
        {
            active = new Wall();
        }

        /// <summary>
        /// Sets the active class for instantiation purposes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNone_Click(object sender, EventArgs e)
        {
            active = new None();
        }

        /// <summary>
        /// Sets the active class for instantiation purposes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRedBox_Click(object sender, EventArgs e)
        {
            active = new Box(MyObject.ObjColor.Red);
        }

        /// <summary>
        /// Sets the active class for instantiation purposes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonGreenBox_Click(object sender, EventArgs e)
        {
            active = new Box(MyObject.ObjColor.Green);
        }

        /// <summary>
        /// Sets the active class for instantiation purposes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRedDoor_Click(object sender, EventArgs e)
        {
            active = new Door(MyObject.ObjColor.Red);
        }

        /// <summary>
        /// Sets the active class for instantiation purposes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonGreenDoor_Click(object sender, EventArgs e)
        {
            active = new Door(MyObject.ObjColor.Green);
        }

        /// <summary>
        /// Generates the grid of picture boxes based on their entries. If a grid already exists, double checks that they want to write over it.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            bool goForward = true;
            
            if(rows != 0) // Checks if there's an existing grid, and verifies the user leaving
            {
                if(MessageBox.Show("Do you want to overwrite the current board?", "Delete?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning) != DialogResult.Yes)
                {
                    goForward = false;
                }
                else
                {
                    pnlBoard.Controls.Clear();
                }
            }
            
            if(goForward)
            {
                // general error handling
                if (!int.TryParse(txtRows.Text, out rows)) // ensures row is an int
                {
                    MessageBox.Show("Please enter a 1-9 number in the rows box.");
                    txtRows.Text = "";
                    txtRows.Focus();
                }
                else if (!int.TryParse(txtCols.Text, out cols)) // ensures cols is an int
                {
                    MessageBox.Show("Please enter a 1-9 number in the columns box.");
                    txtCols.Text = "";
                    txtCols.Focus();
                }
                else if (rows == 0) // ensures rows > 0
                {
                    MessageBox.Show("Please enter a 1-9 number in the rows box.");
                    txtRows.Text = "";
                    txtRows.Focus();
                }
                else if (cols == 0) // ensures cols > 0
                {
                    MessageBox.Show("Please enter a 1-9 number in the columns box.");
                    txtCols.Text = "";
                    txtCols.Focus();
                }
                else // if it passes all checks, generate the board
                {
                    int sizeBetween = 1;
                    int boxSize = 75;
                    int left = sizeBetween;
                    int top = sizeBetween;
                    for (int i = 0; i < cols; i++)
                    {
                        for (int j = 0; j < rows; j++)
                        {
                            // generate picture boxes in a row*col grid
                            PictureBox box = new PictureBox();
                            box.Location = new Point(left, top);
                            box.Size = new Size(boxSize, boxSize);
                            box.BorderStyle = BorderStyle.Fixed3D;
                            box.Click += new EventHandler(pictureBox_Click);
                            box.SizeMode = PictureBoxSizeMode.StretchImage;
                            box.Tag = 0; // important for saving purposes
                            pnlBoard.Controls.Add(box);
                            top += boxSize + sizeBetween;
                        }
                        left += boxSize + sizeBetween;
                        top = sizeBetween;
                    }
                }
            }
        }

        /// <summary>
        /// Applies the active Object to whichever picture box is clicked. If active was None, deletes the image from the picture box. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox_Click(object sender, EventArgs e)
        {
            PictureBox clicked = sender as PictureBox;
            if (active != null) // if they haven't selected a class, doesn't run (error avoidance)
            {
                if(active.Index == 0) // if they selected None, deletes the image
                {
                    clicked.Image = null;
                }
                else // otherwise, sets it to whatever the active class's image is
                {
                    clicked.Image = active.MyImage;
                }
                clicked.Tag = active.Index; // changes the tag to the active class's Index. Important for saving. 
            }
        }

        /// <summary>
        /// Error handling for proper number of boxes/doors, if correct it calls the function to save to file, allowing the user to specify location.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnsSave_Click(object sender, EventArgs e)
        {
            int countWalls = 0;
            int countRedDoors = 0;
            int countGreenDoors = 0;
            int countRedBoxes = 0;
            int countGreenBoxes = 0;
            bool valid = true;
            foreach (PictureBox box in pnlBoard.Controls) // does a tally of each element
            {
                string temp = box.Tag.ToString();
                switch (temp)
                {
                    case "1":
                        countWalls++;
                        break;
                    case "2":
                        countRedDoors++;
                        break;
                    case "3":
                        countGreenDoors++;
                        break;
                    case "4":
                        countRedBoxes++;
                        break;
                    case "5":
                        countGreenBoxes++;
                        break;
                }
            }

            // error handling for game state
            //if (countRedDoors > 2 || countRedBoxes > 2 || countGreenDoors > 2 || countGreenBoxes > 2) // ensures there aren't more than 2 of any box/door
            //{
            //    MessageBox.Show("You cannot have more than 2 of any colour of box or door.");
            //    valid = false;
            //}
            //else if (countRedBoxes > 0 && countRedDoors < 1) // ensures there aren't red boxes without red doors
            //{
            //    MessageBox.Show("You must have at least one Red Door if you have Red Boxes!");
            //    valid = false;
            //}
            //else if (countGreenBoxes > 0 && countGreenDoors < 1) // ensures there aren't green boxes without green doors
            //{
            //    MessageBox.Show("You must have at least one Green Door if you have Green Boxes!");
            //    valid = false;
            //}
            //else if (countGreenBoxes < 1 && countRedBoxes < 1)
            //{
            //    MessageBox.Show("You must have at least one Box!");
            //    valid = false;
            //}

            int countDoors = countRedDoors + countGreenDoors; // adds the doors together for display purposes
            int countBoxes = countRedBoxes + countGreenBoxes; // adds boxes for display

            if(valid) // assuming it passed all validation... 
            {
                if (fileLocation == "") // if they haven't saved it before, allows them to select a location and name
                {
                    saveFileDialog.Filter = "Text files(*.txt)|*.txt";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        fileLocation = saveFileDialog.FileName;
                        WriteToFile(countWalls, countDoors, countBoxes); // calls write function
                    }
                }
                else // if they have saved it before, just saves it to the previous location
                {
                    File.WriteAllText(fileLocation, string.Empty);
                    WriteToFile(countWalls, countDoors, countBoxes);
                }
            }
        }

        /// <summary>
        /// Saves the board by writing each picture box's index into a text document.
        /// </summary>
        /// <param name="countWalls">Number of Walls</param>
        /// <param name="countDoors">Number of Doors</param>
        /// <param name="countBoxes">Number of Boxes</param>
        private void WriteToFile(int countWalls, int countDoors, int countBoxes)
        {
            using (StreamWriter writer = new StreamWriter(fileLocation,true)) // writes the rows, columns, and then Index of each picture box
            {
                writer.WriteLine(rows);
                writer.WriteLine(cols);
                foreach(PictureBox box in pnlBoard.Controls)
                {
                    string temp = box.Tag.ToString();
                    writer.WriteLine(temp);
                }
            }
            MessageBox.Show($"Game saved!\nThere are {countWalls} Walls\nThere are {countDoors} Doors\nThere are {countBoxes} Boxes", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Close form button in menu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnsClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Allows the user to return to the main menu. Sets the public bool to false, letting the launcher know to not close down on return.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void returnToMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if(rows != 0) // if they already have a grid active, verifies that they want to leave, giving them a chance to save
            //{
            //    if (MessageBox.Show("Unsaved changes will be deleted, are you sure you want to leave?", "Leave creation?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning) == DialogResult.Yes)
            //    {
            //        ReturnToLauncher();
            //    }
            //}
            //else
            //{
                ReturnToLauncher();
            //}
        }

        /// <summary>
        /// Asks the user if they are sure they want to close, when they select close from any source. If they select yes, cancels closing.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QGameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if(rows != 0) // if they already have a grid active, verifies that they want to leave, giving them a chance to save
            //{
            //    if (MessageBox.Show("Unsaved changes will be deleted, are you sure you want to leave?", "Leave creation?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning) != DialogResult.Yes)
            //    {
            //        e.Cancel = true; // cancels closing if they don't select yes. I could have used just Yes/No, but I like having Cancel cause it adds the X button at the top :)
            //    }
            //}
        }

        /// <summary>
        /// Sends the user back to the launcher by hiding this form and opening a new instance of the launcher. 
        /// Sets the public bool MyClose to false so that the other launcher doesn't force an Environment.Exit
        /// </summary>
        private void ReturnToLauncher()
        {
            pnlBoard.Controls.Clear();
            rows = 0;
            cols = 0;
            txtCols.Text = "";
            txtRows.Text = "";
            fileLocation = "";
            this.Hide();
            MyClose = false; // public bool that tells the launcher not to execute Environment.Exit
        }

        /// <summary>
        /// Resets our public MyClose variable when the form is shown, so that it doesn't forever think that the launch menu should be shown on exit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QGameForm_Shown(object sender, EventArgs e)
        {
            MyClose = true; // this could have been done in the launcher's code, but it felt like bad form to do it there
        }
    }
}