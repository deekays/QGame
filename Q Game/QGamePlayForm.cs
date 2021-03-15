/* Program ID: QGame
 * 
 * Purpose: Create a functional game to demonstrate programing knowledge
 * 
 * History:
 *      created November 2020, by Stephen Draper
 */


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
    /// The play area for our game
    /// </summary>
    public partial class QGamePlayForm : Form
    {
        int rows;
        int cols;
        MyObject active;
        PictureBox[,] pictureArray;
        PictureBox selected;
        PictureBox oldSelected;
        int selectedRow;
        int selectedCol;
        int remainingBoxes;
        int totalTurns;

        /// <summary>
        /// On load, initializes a couple boxes. Most is in form UI this time around.
        /// </summary>
        public QGamePlayForm()
        {
            InitializeComponent();
            txtRemaining.Text = "0";
            txtTurns.Text = "0";
        }

        /// <summary>
        /// Upon selecting Load from the dropdown, prompts the user to select a valid textfile. If they do, populates the panel with the appropriate
        /// gamestate from the saved file, as well as counting the boxes and setting the remaining boxes. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Text files (*.txt)|*.txt";
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try // make sure there are no errors loading
                {
                    // remove any current board
                    pnlBoard.Controls.Clear();
                    remainingBoxes = 0;
                    totalTurns = 0;
                    txtTurns.Text = totalTurns.ToString();
                    txtRemaining.Text = remainingBoxes.ToString();

                    // load our file, first two rows are row/col, rest are individuals handled by the for loops
                    string fileName = openFileDialog.FileName;
                    string[] textFromFile = File.ReadAllLines(fileName);
                    rows = int.Parse(textFromFile[0]);
                    cols = int.Parse(textFromFile[1]);
                    pictureArray = new PictureBox[rows, cols];

                    // no magic numbers here
                    int sizeBetween = 1;
                    int boxSize = 75;
                    int left = sizeBetween;
                    int top = sizeBetween;

                    int arrayPosition = 2;
                    for (int i = 0; i < cols; i++) // handles individual boxes with loops based on row/col size
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

                            switch (textFromFile[arrayPosition]) // sets the appropriate class based on what number was loaded
                            {
                                case "0":
                                    active = new None();
                                    break;
                                case "1":
                                    active = new Wall();
                                    break;
                                case "2":
                                    active = new Door(MyObject.ObjColor.Red);
                                    break;
                                case "3":
                                    active = new Door(MyObject.ObjColor.Green);
                                    break;
                                case "4":
                                    active = new Box(MyObject.ObjColor.Red);
                                    remainingBoxes++;
                                    break;
                                case "5":
                                    active = new Box(MyObject.ObjColor.Green);
                                    remainingBoxes++;
                                    break;
                            }

                            // sets the box to the chosen class's information 
                            box.Image = active.MyImage;
                            box.Tag = active.Index;
                            pictureArray[j, i] = box;

                            txtRemaining.Text = remainingBoxes.ToString();


                            pnlBoard.Controls.Add(box);
                            top += boxSize + sizeBetween;
                            arrayPosition++;
                        }
                        left += boxSize + sizeBetween;
                        top = sizeBetween;
                    }
                    btnDown.Enabled = true;
                    btnLeft.Enabled = true;
                    btnRight.Enabled = true;
                    btnUp.Enabled = true;
                }
                catch // if they uploaded a txt file that doesn't work with our reading system
                {
                    MessageBox.Show("Your text file was unreadable,\nplease try again.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }    
        }

        /// <summary>
        /// Allows the user to select one of the boxes as the active object to be moved.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox_Click(object sender, EventArgs e)
        {
            PictureBox clicked = sender as PictureBox;
            int pullTag = int.Parse(clicked.Tag.ToString());
            if(pullTag == 4 || pullTag == 5) // checks that they clicked a box (game box, not picture box)
            {
                if(oldSelected != clicked) // doesn't run if they click the same box, stops flickering
                {
                    if (oldSelected != null) // doesn't clear background (or throw errors!) if none are selected 
                    {
                        oldSelected.BorderStyle = BorderStyle.Fixed3D;
                    }
                    selected = clicked;
                    clicked.BorderStyle = BorderStyle.FixedSingle;
                    oldSelected = selected;

                    for (int i = 0; i < rows; i++)
                    {
                        for (int j = 0; j < cols; j++)
                        {
                            if(selected.Location == pictureArray[i,j].Location) // pulls the location from our array, so we know where they have clicked
                            {
                                selectedRow = i;
                                selectedCol = j;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Handler for when they click up. Checks if there is an active box, then pulls the column that it is in and checks every square above it 
        /// until it hits a non-empty square. Then checks if it is a door of the appropriate colour, and either calls MoveBox or DeleteBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUp_Click(object sender, EventArgs e)
        {
            if(selected != null)
            {
                string selectedTag = selected.Tag.ToString();
                for (int i = selectedRow-1; i > -1; i--) // checks from the one above selectedRow, until i = 0
                {
                    string checkTag = pictureArray[i, selectedCol].Tag.ToString();
                    if(checkTag == "0") // if the checked box is empty, makes it the new location
                    {
                        selectedRow = i;
                    }
                    else if(selectedTag == "4" && checkTag == "2") // checks if red box hit red door
                    {
                        DeleteBox();
                        return; // return instead of break so that we skip the final movebox call
                    }
                    else if(selectedTag == "5" && checkTag == "3") // or if green hits green
                    {
                        DeleteBox();
                        return;
                    }
                    else // if not, end the loop by running move up and returning
                    {
                        MoveBox();
                        return;
                    }
                }
                MoveBox(); // if it hits the edge without ever hitting another object
            }
            else
            {
                MessageBox.Show("Please select a box to move!","None selected.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Handler for when they click down. Checks if there is an active box, then pulls the column that it is in and checks every square below it 
        /// until it hits a non-empty square. Then checks if it is a door of the appropriate colour, and either calls MoveBox or DeleteBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDown_Click(object sender, EventArgs e)
        {
            if(selected != null)
            {
                string selectedTag = selected.Tag.ToString();
                for (int i = selectedRow+1; i < rows; i++)
                {
                    string checkTag = pictureArray[i, selectedCol].Tag.ToString();
                    if(checkTag == "0")
                    {
                        selectedRow = i;
                    }
                    else if (selectedTag == "4" && checkTag == "2")
                    {
                        DeleteBox();
                        return;
                    }
                    else if (selectedTag == "5" && checkTag == "3")
                    {
                        DeleteBox();
                        return;
                    }
                    else
                    {
                        MoveBox();
                        return;
                    }
                }
                MoveBox();
            }
            else
            {
                MessageBox.Show("Please select a box to move!", "None selected.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Handler for when they click left. Checks if there is an active box, then pulls the row that it is in and checks every square to the right of it 
        /// until it hits a non-empty square. Then checks if it is a door of the appropriate colour, and either calls MoveBox or DeleteBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLeft_Click(object sender, EventArgs e)
        {
            if (selected != null)
            {
                string selectedTag = selected.Tag.ToString();
                for (int i = selectedCol-1; i > -1; i--)
                {
                    string checkTag = pictureArray[selectedRow, i].Tag.ToString();
                    if (checkTag == "0")
                    {
                        selectedCol = i;
                    }
                    else if (selectedTag == "4" && checkTag == "2")
                    {
                        DeleteBox();
                        return;
                    }
                    else if (selectedTag == "5" && checkTag == "3")
                    {
                        DeleteBox();
                        return;
                    }
                    else
                    {
                        MoveBox();
                        return;
                    }
                }
                MoveBox();
            }
            else
            {
                MessageBox.Show("Please select a box to move!", "None selected.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Handler for when they click left. Checks if there is an active box, then pulls the row that it is in and checks every square to the left of it 
        /// until it hits a non-empty square. Then checks if it is a door of the appropriate colour, and either calls MoveBox or DeleteBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRight_Click(object sender, EventArgs e)
        {
            if (selected != null)
            {
                string selectedTag = selected.Tag.ToString();
                for (int i = selectedCol + 1; i < cols; i++)
                {
                    string checkTag = pictureArray[selectedRow, i].Tag.ToString();
                    if (checkTag == "0")
                    {
                        selectedCol = i;
                    }
                    else if (selectedTag == "4" && checkTag == "2")
                    {
                        DeleteBox();
                        return;
                    }
                    else if (selectedTag == "5" && checkTag == "3")
                    {
                        DeleteBox();
                        return;
                    }
                    else
                    {
                        MoveBox();
                        return;
                    }
                }
                MoveBox();
            }
            else
            {
                MessageBox.Show("Please select a box to move!", "None selected.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Deletes the active box. Which really means we set the picturebox where the box is to being an empty square, and de-increment our remaining boxes.
        /// Also checks if the EndGame state has been reached (remaining boxes = 0)
        /// </summary>
        private void DeleteBox()
        {
            // when a box hits a door of the same colour
            totalTurns++;
            txtTurns.Text = totalTurns.ToString();
            selected.Image = null;
            selected.Tag = "0";
            selected.BorderStyle = BorderStyle.Fixed3D;
            selected = null;
            remainingBoxes--;
            txtRemaining.Text = remainingBoxes.ToString();
            if(remainingBoxes == 0)
            {
                EndGame();
            }
        }

        /// <summary>
        /// Yay we won! This happens when there are 0 remaining boxes, after a box has been deleted. (if there are no active boxes on load this will not occur, I am aware, but it allows
        /// for level viewing). Once this event occurs, clears the panel, sets the remainingboxes and total turns to zero, and disables the buttons. Basically leaves the form as you found it.
        /// </summary>
        private void EndGame()
        {
            // you win wooooo
            totalTurns++;
            txtTurns.Text = totalTurns.ToString(); // so that they can see how many turns it took on the side, before we wipe it
            MessageBox.Show("Congratulations!\nYou win!", "Victory!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            // reset it all!
            pnlBoard.Controls.Clear();
            remainingBoxes = 0;
            txtRemaining.Text = remainingBoxes.ToString();
            totalTurns = 0;
            txtTurns.Text = totalTurns.ToString();
            btnDown.Enabled = false;
            btnLeft.Enabled = false;
            btnRight.Enabled = false;
            btnUp.Enabled = false;
        }

        /// <summary>
        /// Called when a box is successfully moved via the arrow buttons, and it did not encounter a door of the same colour. This function
        /// sets the square that the box is moving from back to being empty, and then sets the new location to contain a box of the appropriate colour.
        /// </summary>
        private void MoveBox()
        {   
            string selectedTag = selected.Tag.ToString(); // pulls the tag from the selected box before reassigning it
            selected = pictureArray[selectedRow, selectedCol]; // selected is now the new location
            if(selected != oldSelected)
            {
                MyObject temp = new None();
                // reset old
                oldSelected.Image = null;
                oldSelected.Tag = temp.Index;
                oldSelected.BorderStyle = BorderStyle.Fixed3D;


                selected.BorderStyle = BorderStyle.FixedSingle;
                if (selectedTag == "4") // set new red
                {
                    temp = new Box(MyObject.ObjColor.Red);
                    selected.Image = temp.MyImage;
                    selected.Tag = temp.Index;
                }
                else if (selectedTag == "5") // set new green
                {
                    temp = new Box(MyObject.ObjColor.Green);
                    selected.Image = temp.MyImage;
                    selected.Tag = temp.Index;
                }
                oldSelected = selected;
                totalTurns++;
                txtTurns.Text = totalTurns.ToString();
            }
        }

        /// <summary>
        /// Quits the program.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}