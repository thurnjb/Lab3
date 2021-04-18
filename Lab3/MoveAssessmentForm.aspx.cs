using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab3
{
    public partial class MoveAssessmentForm : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {


        }


        //Loops through array and checks if a panel is visible
        //If panel is visible, make all panels invisible
        //If next was clicked, make next panel visible
        protected void ChangePanelVisible(Boolean goNext)
        {
            //this is awful programming
            //update with loop
            Panel[] arr = new Panel[] { Panel1, Panel2, Panel3, Panel4, Panel5, Panel6, Panel7, Panel8 };

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].Visible == true)
                {
                    if (goNext && i != arr.Length - 1)
                    {
                        arr[i].Visible = false;
                        arr[i + 1].Visible = true;
                        break;
                    }
                    if (!goNext && i != 0)
                    {
                        arr[i].Visible = false;
                        arr[i - 1].Visible = true;
                        break;
                    }
                }

            }

        }


        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            //String sqlCommitQuery = "INSERT INTO";

            //SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            //sqlConnect.Open();
            //SqlCommand sqlCommand = new SqlCommand();
            //sqlCommand.Connection = sqlConnect;
            //sqlCommand.CommandText = sqlCommitQuery;
            //sqlCommand.Parameters.AddWithValue("@FirstName", HttpUtility.HtmlEncode(txtFirstName.Text));

            //sqlCommand.ExecuteNonQuery();
        }

        protected void btnPreviousPanel_Click(object sender, EventArgs e)
        {
            ChangePanelVisible(false);
        }

        protected void btnNextPanel_Click(object sender, EventArgs e)
        {
            ChangePanelVisible(true);
        }

        protected void btnPopulate_Click(object sender, EventArgs e)
        {
            //eek I don't want to do this
            //Customer Questions
            TextBoxMoveOutDate.Text = "10 / 12 / 2021";
            TextBoxWindowDaysMove.Text = "any day";
            TextBoxAddressMovingTo.Text = "9805 Pinecone Ln";
            TextBoxMLSListing.Text = "Yes";
            TextBoxPhotos.Text = "Yes";
            CheckBoxListAddService.SelectedValue = "Packing";
            TextBoxAuctionServices.Text = "Yes";

            //Room Info
            CheckBoxListOrderOfRooms.SelectedValue = "Den";
            ListBoxEachRoomFurniture.Text = "Couch and dresser";
            CheckBoxFloor.SelectedValue = "Basement";
            CheckBoxList1.SelectedValue = "Large";

            //Notes
            TextBoxNoteTitle.Text = "Glass Collection!";
            TextBoxNotesMove.Text = "Bring extra bubble wrap for fragile items";

            //Home Info
            TextBoxAptFloor.Text = "n/a";
            TextBoxAptElevator.Text = "n/a";
            TextBoxAptWalk.Text = "n/a";
            TextBoxHouse.Text = "Single story";

            //Storage Info
            TextBoxClimateC.Text = "Yes";
            TextBoxSelfStorage.Text = "No";
            TextBoxBusiness.Text = "n/a";

            //Logistics Info
            TextBoxTruckAccess.Text = "Yes";
            TextBoxLoadingDoor.Text = "About 100 yards";
            TextBoxSteps.Text = "25 feet";

            //Equipemnt Needed
            CheckBoxListSpecialEquipment.SelectedValue = "0";
            CheckBoxListTrucksRequired.SelectedValue = "0";

            //Cost Estimate
            TextBoxEstimate.Text = "6,950";
            TextBoxFixed.Text = "$2,000";
            TextBoxPackingFees.Text = "$1,000";
            TextBoxStorageFees.Text = "$200/month";
            TextBoxTrashRemoval.Text = "$100";
        }

        protected void ddlSkipToSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            int sectionIndex = int.Parse(ddlSkipToSection.SelectedValue);


            switch (sectionIndex)
            {
                case 1:
                    HidePanels_ShowOne(0);
                    break;
                case 2:
                    HidePanels_ShowOne(1);
                    break;
                case 3:
                    HidePanels_ShowOne(2);
                    break;
                case 4:
                    HidePanels_ShowOne(3);
                    break;
                case 5:
                    HidePanels_ShowOne(4);
                    break;
                case 6:
                    HidePanels_ShowOne(5);
                    break;
                case 7:
                    HidePanels_ShowOne(6);
                    break;
                case 8:
                    HidePanels_ShowOne(7);
                    break;
            }
        }
        protected void HidePanels_ShowOne(int x)
        {
            Panel[] arr = new Panel[] { Panel1, Panel2, Panel3, Panel4, Panel5, Panel6, Panel7, Panel8 };

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i].Visible = false;
            }
            arr[x].Visible = true;
        }
    }


}