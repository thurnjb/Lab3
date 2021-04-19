using System;
using System.Collections.Generic;
using System.Data;
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
          

            //String sqlquery = "SELECT FirstName, LastName FROM CUSTOMER WHERE CustomerID=" + Session["CustomerID"] + ";";

            //SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            //SqlCommand sqlCommand = new SqlCommand();
            //sqlCommand.Connection = sqlConnect;
            //sqlCommand.CommandType = CommandType.Text;
            //sqlCommand.CommandText = sqlquery;


            //sqlConnect.Open();
            //SqlDataReader queryResults = sqlCommand.ExecuteReader();

            //lblName.Text = queryResults.ToString();



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
            string additionalService = CheckBoxListAddService.SelectedValue;
            string rooms = CheckBoxListOrderOfRooms.SelectedValue;
            string roomFloor = CheckBoxFloor.SelectedValue;
            string boxes = CheckBoxList1.SelectedValue;
            string equip = CheckBoxListSpecialEquipment.SelectedValue;
            string trucks = CheckBoxListTrucksRequired.SelectedValue;

            String sqlCommitQuery = "INSERT INTO MoveAssessment(outDate,windowDays,address,mls,photo,additionalServices,auctionServices,room,furnitureList, roomFloor, boxes, appFloor, elevator, walk, house, climateStorage, outdoorStorage, businessPlace, truckAccessable, doorWalk, stepsWalk, equipNeeded, trucksRequired, moveEstimate, fixedRates, packingFees, storageFees, trashRemoval, CustomerID)  VALUES(@outDate, @windowDays, @address, @mls, @photo, @additionalServices, @auctionServices, @room, @furnitureList, @roomFloor, @boxes, @appFloor, @elevator, @walk, @house, @climateStorage, @outdoorStorage, @businessPlace, @truckAccessable, @doorWalk, @stepsWalk, @equipNeeded, @trucksRequired, @moveEstimate, @fixedRates, @packingFees, @storageFees, @trashRemoval, @CustomerID); ";

            SqlConnection sqlConnect = new SqlConnection(WebConfigurationManager.ConnectionStrings["Lab3"].ConnectionString);

            sqlConnect.Open();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandText = sqlCommitQuery;
            sqlCommand.Parameters.AddWithValue("@outDate", HttpUtility.HtmlEncode(TextBoxMoveOutDate.Text));
            sqlCommand.Parameters.AddWithValue("@windowDays", HttpUtility.HtmlEncode(TextBoxWindowDaysMove.Text));
            sqlCommand.Parameters.AddWithValue("@address", HttpUtility.HtmlEncode(TextBoxAddressMovingTo.Text));
            sqlCommand.Parameters.AddWithValue("@mls", HttpUtility.HtmlEncode(TextBoxMLSListing.Text));
            sqlCommand.Parameters.AddWithValue("@photo", HttpUtility.HtmlEncode(TextBoxPhotos.Text));
            sqlCommand.Parameters.AddWithValue("@additionalServices", HttpUtility.HtmlEncode(additionalService));
            sqlCommand.Parameters.AddWithValue("@auctionServices", HttpUtility.HtmlEncode(TextBoxAuctionServices.Text));
            sqlCommand.Parameters.AddWithValue("@room", HttpUtility.HtmlEncode(rooms));
            sqlCommand.Parameters.AddWithValue("@furnitureList", HttpUtility.HtmlEncode("chair, table"));
            sqlCommand.Parameters.AddWithValue("@roomFloor", HttpUtility.HtmlEncode(roomFloor));
            sqlCommand.Parameters.AddWithValue("@boxes", HttpUtility.HtmlEncode(boxes));
            sqlCommand.Parameters.AddWithValue("@appFloor", HttpUtility.HtmlEncode(TextBoxAptFloor.Text));
            sqlCommand.Parameters.AddWithValue("@elevator", HttpUtility.HtmlEncode(TextBoxAptElevator.Text));
            sqlCommand.Parameters.AddWithValue("@walk", HttpUtility.HtmlEncode(TextBoxAptWalk.Text));
            sqlCommand.Parameters.AddWithValue("@house", HttpUtility.HtmlEncode(TextBoxHouse.Text));
            sqlCommand.Parameters.AddWithValue("@climateStorage", HttpUtility.HtmlEncode(TextBoxClimateC.Text));
            sqlCommand.Parameters.AddWithValue("@outdoorStorage", HttpUtility.HtmlEncode(TextBoxSelfStorage.Text));
            sqlCommand.Parameters.AddWithValue("@businessPlace", HttpUtility.HtmlEncode(TextBoxBusiness.Text));
            sqlCommand.Parameters.AddWithValue("@truckAccessable", HttpUtility.HtmlEncode(TextBoxTruckAccess.Text));
            sqlCommand.Parameters.AddWithValue("@doorWalk", HttpUtility.HtmlEncode(TextBoxLoadingDoor.Text));
            sqlCommand.Parameters.AddWithValue("@stepsWalk", HttpUtility.HtmlEncode(TextBoxSteps.Text));
            sqlCommand.Parameters.AddWithValue("@equipNeeded", HttpUtility.HtmlEncode(equip));
            sqlCommand.Parameters.AddWithValue("@trucksRequired", HttpUtility.HtmlEncode(trucks));
            sqlCommand.Parameters.AddWithValue("@moveEstimate", HttpUtility.HtmlEncode(TextBoxEstimate.Text));
            sqlCommand.Parameters.AddWithValue("@fixedRates", HttpUtility.HtmlEncode(TextBoxFixed.Text));
            sqlCommand.Parameters.AddWithValue("@packingFees", HttpUtility.HtmlEncode(TextBoxPackingFees.Text));
            sqlCommand.Parameters.AddWithValue("@storageFees", HttpUtility.HtmlEncode(TextBoxStorageFees.Text));
            sqlCommand.Parameters.AddWithValue("@trashRemoval", HttpUtility.HtmlEncode(TextBoxTrashRemoval.Text));
            sqlCommand.Parameters.AddWithValue("@customerID", HttpUtility.HtmlEncode(Session["CustomerID"]));


            sqlCommand.ExecuteNonQuery();

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
            CheckBoxListSpecialEquipment.SelectedValue = "Piano Dolly";
            CheckBoxListTrucksRequired.SelectedValue = "2011";

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