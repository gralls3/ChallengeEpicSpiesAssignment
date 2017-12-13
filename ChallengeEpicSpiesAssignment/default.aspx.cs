using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//C# app created through DevU as part of Tech Academy curriculum
//App used to calculate $ of assinging spies to spy assignments for fictitious agency
//Full biz rules are in project files. Gist is:
//- get Spy and Assignment name
//- start date must be 14 days after end of last assignment (else error msg)
//- cost is $500/day
//- $1000 "budget fee" if assignment > 21 days

namespace ChallengeEpicSpiesAssignment
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                previousCalendar.SelectedDate = DateTime.Now.Date;
                startCalendar.SelectedDate = DateTime.Now.Date.AddDays(14);
                endCalendar.SelectedDate = DateTime.Now.Date.AddDays(21);
            }

        }

        protected void AssignButton_Click(object sender, EventArgs e)
        {
            int daysBetweenAssignments = (int)startCalendar.SelectedDate.Subtract(previousCalendar.SelectedDate).TotalDays;
            int assignmentLength = (int)endCalendar.SelectedDate.Subtract(startCalendar.SelectedDate).TotalDays;
            int assignmentMaxDays = 21;
            int minDaysBetweenAssignments = 14;
            int agentDalyCost = 500;
            int overMaxDaysFee = 1000;
            string agentName = spyCodeNameTextBox.Text;
            string assignmentName = assignmentNameTextBox.Text;

            //Verify period between end of last assignment and start of new one
            //(aka breaklenght) is < 14 days. If so, stop and tell user
            if (daysBetweenAssignments < minDaysBetweenAssignments)
            {
                resultLabel.Text = String.Format(
                    "Union rules require a 14 day break between assignments. Current break is {0} days." +
                    "<p>Please choose a later start date.", daysBetweenAssignments
                );
            } //See if assignment is longer than 21 days. If so, calc cost and add $1000
            else if (assignmentLength > assignmentMaxDays)
            {
                resultLabel.Text = String.Format(
                    "Assignment of agent {0} to assignement '{1}' is authorized.<p>" +
                    "Total cost is {2:C} ({3} days * {4:C} per day = {6:C}, + {5:C} Budget Fee = {2:C})",
                    spyCodeNameTextBox.Text,
                    assignmentNameTextBox.Text,
                    (assignmentLength * agentDalyCost) + overMaxDaysFee,
                    assignmentLength,
                    agentDalyCost,
                    overMaxDaysFee,
                    (assignmentLength * agentDalyCost)
                    );
            } //We're here so break must be >= 14 days and assignment <= 21 day
            //let's calculate the cost!
            else
            {
                resultLabel.Text = String.Format(
                    "Assignment of agent {0} to assignement '{1}' is authorized.<p>" +
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