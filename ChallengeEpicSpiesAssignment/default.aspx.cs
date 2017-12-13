using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengeEpicSpiesAssignment
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {if (!Page.IsPostBack)
            {
                previousCalendar.SelectedDate = DateTime.Now.Date;
                startCalendar.SelectedDate = DateTime.Now.Date.AddDays(14);
                endCalendar.SelectedDate = DateTime.Now.Date.AddDays(21);
            }

        }

        protected void AssignButton_Click(object sender, EventArgs e)
        {
            int breakLength = (int)startCalendar.SelectedDate.Subtract(previousCalendar.SelectedDate).TotalDays;
            int assignmentLength = (int)endCalendar.SelectedDate.Subtract(startCalendar.SelectedDate).TotalDays;
            int assignmentMaxDays = 21;
            int agentDalyCost = 500;
            int budgetFee = 1000;
            string agentName = spyCodeNameTextBox.Text;
            string assignmentName = assignmentNameTextBox.Text;

            //Verify period between end of last assignment and start of new one is < 14 days
            if ( breakLength < 14)
            {
                resultLabel.Text =
                    "Union rules require a 14 day break between assignments. Current break is "
                    + breakLength + " days.<br>Please choose a later start date.";
            } //See if assignment is longer than 21 days. If so, calc cost and add $1000
            else if (assignmentLength > assignmentMaxDays)
            {
                resultLabel.Text = String.Format(
                    "Assignment of agent {0} to assignement '{1}' is authorized.<br>" +
                    "Total cost is {2:C} ({3} days * {4:C} per day = {6:C}, + {5:C} Budget Fee = {2:C})",
                    spyCodeNameTextBox.Text,
                    assignmentNameTextBox.Text,
                    (assignmentLength * agentDalyCost) + budgetFee,
                    assignmentLength,
                    agentDalyCost,
                    budgetFee,
                    (assignmentLength * agentDalyCost)
                    );
            } //Calculate cost
            else
            {
                resultLabel.Text = String.Format(
                    "Assignment of agent {0} to assignement '{1}' is authorized.<br>" +
                    "Total cost is {2:C} ({3} days * {4:C} per day = {2:C}).",
                    spyCodeNameTextBox.Text,
                    assignmentNameTextBox.Text,
                    (assignmentLength * agentDalyCost),
                    assignmentLength,
                    agentDalyCost
                );
            }
        }
    }
}