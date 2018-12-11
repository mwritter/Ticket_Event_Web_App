using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Summary : System.Web.UI.Page
{

    List<TicketHolder> summaryTickets;
    ShowEvent showEvent;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["selectedEvent"] != null)
        {
            showEvent = (ShowEvent)Session["selectedEvent"];
            summaryTickets = new List<TicketHolder>();
            
            
            createSummary();
        }
        else
        {
            showEvent = new ShowEvent("Unknown", 5);
            summaryTickets = new List<TicketHolder>();
            TextBox1.Text = "No Events Yet";
        }




    }

    private void createSummary() {
        lblShowText.Text = showEvent.EventName;
        fillSummaryTickets();
        addTicketHolders();
        TextBox1.Text = string.Empty;
        printSummary(summaryTickets);
    }

    private void fillSummaryTickets() {
        foreach (TicketHolder holder in showEvent.TicketHolders) {
            summaryTickets.Add(holder);
        }
    }

    private void printSummary(List<TicketHolder> holderList) {
        TextBox1.Text = "";

        TextBox1.Text +=
            "-----------------------------------------\n";

        foreach (TicketHolder holder in holderList) {
            TextBox1.Text += "NAME: "+ holder.Name + "\tSEAT: " + holder.Seat + "\tAGE: " + holder.Age + "\tPRICE: $" + holder.Price + "\n";
        }
        TextBox1.Text += "\n-----------------------------------------\nTickets Sold: " + summaryTickets.Count;
        TextBox1.Text += "\nTickets Available: " + getTicketsLeft();
        TextBox1.Text += "\nTotal Tickets Price: $" + getTotalPrice(holderList);
        TextBox1.Text += "\nAverage Ticket Price: $" + getTotalPrice(holderList)/holderList.Count;
        TextBox1.Text += "\nAvailable Seats: "; getSeats();

    }

    private void getSeats() {
         
         foreach (string seat in showEvent.SeatsLeft) {
             TextBox1.Text += " "+ seat;
         }
    }
    private int getTicketsLeft() {
        return showEvent.TotalSeats;
    }

    private double getTotalPrice(List<TicketHolder> holderList) {
        double total = 0;
        foreach (TicketHolder holder in holderList) {
            total += holder.Price;
        } return total;
    }

    private void addTicketHolders() {
        foreach (TicketHolder holder in showEvent.TicketHolders) {
            HolderDropDownList.Items.Add(new ListItem(holder.Name));
        }
    }



    protected void SellMore_Click(object sender, EventArgs e)
    {
        //saveSession();
        Response.Redirect("Default.aspx");
    }

    protected void Remove_Click(object sender, EventArgs e)
    {
        String selected = "";

            
            for (int i = HolderDropDownList.Items.Count - 1; i >= 0; i--)
            {
                if (HolderDropDownList.Items[i].Selected)
                {
                    selected = HolderDropDownList.Items[i].Text;
                    if (selected.Equals("Choose Person to Remove")) {

                    }
                    else
                    {
                    HolderDropDownList.Items.RemoveAt(i);
                    removeFromShowEvent(selected);
                    Response.Redirect("Summary.aspx");
                    fillSummaryTickets();
                    addTicketHolders();
                    
                    

                    }
                    
                }

            }
            
        
    }

    private void removeFromShowEvent(String selected)
    {
        String seat = "";

        for (int i = showEvent.TicketHolders.Count - 1; i >= 0; i--)
        {
            if (showEvent.TicketHolders[i].Name.Equals(selected))
            {
                seat = showEvent.TicketHolders[i].Seat;
                showEvent.SeatsLeft.Add(seat);
                showEvent.TotalSeats++;
                showEvent.TicketHolders.Remove(showEvent.TicketHolders[i]);
               
            }
        }
        
    }



    protected void radioName_CheckedChanged(object sender, EventArgs e)
    {
        sortByName();
    }

    protected void radioSeat_CheckedChanged(object sender, EventArgs e)
    {
        sortBySeat();
    }
    protected void radioOrder_CheckedChanged(object sender, EventArgs e)
    {
        sortNormal();

    }

    private void sortByName() {
        List<TicketHolder> temp = new List<TicketHolder>(summaryTickets);
        temp.Sort((x,y) => string.Compare(x.Name, y.Name));
        HolderDropDownList.Items.Clear();
        createSummary();
        printSummary(temp);
    }

    private void sortBySeat() {
        List<TicketHolder> temp = new List<TicketHolder>(summaryTickets);
        temp.Sort((x, y) => x.SeatValue.CompareTo(y.SeatValue));
        HolderDropDownList.Items.Clear();
        createSummary();
        printSummary(temp);
    }

    private void sortNormal() {
        HolderDropDownList.Items.Clear();
        TextBox1.Text += Convert.ToString(summaryTickets.Count);
        printSummary(summaryTickets);
    }
}