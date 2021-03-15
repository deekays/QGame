/* Program ID: Q Game
 * 
 * Purpose: Creating the first part of a Q Game to prove programming knowledge and get 100%
 * 
 * History:
 *      created October 2020 by Stephen Draper
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Q_Game
{
    /// <summary>
    /// Launcher form, main menu providing links to create, play, and exit
    /// </summary>
    public partial class LaunchForm : Form
    {
        QGameForm gameCreate = new QGameForm();
        QGamePlayForm playerCreate = new QGamePlayForm();

        public LaunchForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Hides this form and brings up the creation form. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreate_Click(object sender, EventArgs e)
        {
            this.Hide();
            gameCreate.ShowDialog();
            if(gameCreate.MyClose) // if the user wants to navigate back to this form, we don't want to exit. So we check if MyClose was set to false. 
            {
                this.Close(); // if it was, we close
            }
            else
            {
                this.Show(); // if not, we show
            }
        }

        /// <summary>
        /// Closes the form when they click... close. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            this.Hide();
            playerCreate.ShowDialog();
            this.Close();
        }
    }
}
