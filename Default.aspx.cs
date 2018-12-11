using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    private static List<ShowEvent> eventList;
    private static List<TicketHolder> ticketHolders;
    private static ShowEvent SelectedEvent;

    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!Page.IsPostBack)
        {
            if (Session["eventList"] != null)
            {
                eventList = (List<ShowEvent>)Session["eventList"];
                ticketHolders = (List<TicketHolder>)Session["ticketHolders"];
                
                addToDropDown();
                printEvents();
            }
            else {
                eventList = new List<ShowEvent>();
                ticketHolders = new List<TicketHolder>();
                printEvents();
            }

            
        }
        else
        {
            

        }

    }

    private void addToDropDown() {
        DropDownEventsList.Items.Clear();
        foreach (ShowEvent e in eventList) {
            DropDownEventsList.Items.Add(new ListItem(e.EventName, Convert.ToString(e.TotalSeats)));
        }
    }

    protected void btnPurchase_Click(object sender, EventArgs e)
    {
        if (!txtName.Text.Equals("") && !txtAge.Text.Equals("") && DropDownSeats.Items.Count > 0)
        {
            makeHolder();
        }
        else {

            txtTestEvents.Text = "Must have a Name Age and Seat to Purchase Tickets";
        }
    }
    private void makeHolder() {
        String ticketHolder = txtName.Text;
        int age = Convert.ToInt16(txtAge.Text);
        String seat = DropDownSeats.SelectedValue;
        DropDownSeats.Items.Remove(seat);
        lblTicketsAvailableNum.Text = Convert.ToString((Convert.ToInt16(lblTicketsAvailableNum.Text) - 1));
        String thisEvent = DropDownEventsList.SelectedItem.Text;
        TicketHolder newTicketHolder = new TicketHolder(ticketHolder, age, seat, thisEvent);
        ticketHolders.Add(newTicketHolder);
        addTicketHoldedToEvent(newTicketHolder, thisEvent);
        txtName.Text = "";
        txtAge.Text = "";
        printEvents();
    }
    private void addTicketHoldedToEvent(TicketHolder newTicketHolder, String thisEvent) {
        foreach (ShowEvent e in eventList) {
            if (e.EventName.Equals(thisEvent)) {
                e.TicketHolders.Add(newTicketHolder);
                e.takeSeat(newTicketHolder.Seat);
            }
        }
    }





    protected void btnMakeEvent_Click(object sender, EventArgs e)
    {



        if (!txtEventName.Text.Equals("") && !txtFirst.Text.Equals("") && !txtLast.Text.Equals(""))
        {
            //Get the number of Seats available and add to Seat dropdown box
            DropDownSeats.Items.Clear();
            makeEvent();
            printEvents();
        }
        else
        {

        }


        txtEventName.Text = "";
        txtFirst.Text = "";
        txtLast.Text = "";

    }


    private void makeEvent()
    {
        //Get the number of Seats available and add to Seat dropdown box
        String eventName = txtEventName.Text;
        int firstSeat = Convert.ToInt16(txtFirst.Text);
        int lastSeat = Convert.ToInt16(txtLast.Text);
        int totalAvalible = (lastSeat - firstSeat) + 1;

        if (firstSeat < 0 || lastSeat < 0 || totalAvalible < 0)
        {
            firstSeat = 0;
            lastSeat = 0;
            totalAvalible = 0;
        }
        else {
            
        }

        
        



        DropDownEventsList.Items.Add(new ListItem(eventName, Convert.ToString(totalAvalible)));


        eventList.Add(new ShowEvent(eventName, totalAvalible));


    }

    private void printEvents()
    {
        String eventMsg = "";

        foreach (ShowEvent e in eventList)
        {
            eventMsg += "\nEvent Name: " + e.EventName + "\n Remaining Number of Seats: " + e.TotalSeats + "\n";
            eventMsg += "\n====Ticket Holders For this event====\n";
            if (e.TicketHolders.Count > 0) {
                foreach (TicketHolder holder in e.TicketHolders)
                {
                    eventMsg += "Name: " + holder.Name + " age: " + holder.Age +
                        " Seat: " + holder.Seat + "\n";
                }
            } else {
                eventMsg += "No Ticket Holders Yet";
            }

        }

        txtTestEvents.Text = eventMsg;
    }




    protected void SelectEvent_Click(object sender, EventArgs e)

    {

        DropDownSeats.Items.Clear();
        if (DropDownEventsList.Items.Count > 0)
        {
            String selected = DropDownEventsList.SelectedItem.Text;

            lblTicketsAvailable.Text = "Event Selected: " + selected + " only ";
            foreach (ShowEvent se in eventList)
            {
                if (se.EventName.Equals(selected))
                {
                    SelectedEvent = se;
                    Session.Add("selectedEvent", SelectedEvent);
                    lblTicketsAvailableNum.Text = Convert.ToString(se.TotalSeats);

                    foreach (string seat in se.SeatsLeft)
                    {
                        DropDownSeats.Items.Add(seat);
                    }

                }
            }
        }
        else {
            txtTestEvents.Text += "";
        }
    }

    
    

    protected void btnEventSummary_Click(object sender, EventArgs e)
    {
        Session.Add("ticketHolders", ticketHolders);
        Session.Add("eventList", eventList);
        Response.Redirect("Summary.aspx");
    }


    
}