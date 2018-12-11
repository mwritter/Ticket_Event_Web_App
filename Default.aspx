<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

    <!DOCTYPE html>

    <html xmlns="http://www.w3.org/1999/xhtml">

    <head runat="server">
        
        <title>HW 3 - Matthew Ritter</title>
        <link href="styles/stylesheet.css" rel="stylesheet" />
       <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css">
       <link href="https://fonts.googleapis.com/css?family=Pacifico" rel="stylesheet">
        <meta name="viewport" content="width=device-width,initial-scale=1.0">
        <style>
            @media(min-width: 700px) {
                .brand {
                    display:block;
                }
            }

            @media(min-width:750px) {
                .brand {
                    transform: scale(1.1);
                    
                }
                .wrapper {
                    display: grid;
                    grid-template-columns: 1fr 2fr;
                }

                    .wrapper > * {
                        padding: 2em;
                    }

                .header-info h2 {
                    font-size: 1.2em;
                }

                .header-info h2,
                .header-info ul,
                .brand {
                    text-align: left;
                }
               .styleButton {
                text-align: center;
                height: 30px;
                width:30px;
                border-radius: 50%;
                background-color: #0a4099;
}
            }
        </style>
    </head>


    <body>
        
        <div class="container">
            <!--container-->
            <h1 class="brand"><span>BlueShade</span> Web Design</h1>
            <div class="wrapper">
                <!--wrapper-->
                <div class="header-info">
                    <!--header-info-->
                    <h2><span>BlueShade</span> Web Design</h2>
                    <ul>
                        <li><i class="fa fa-road"></i> 1500 N Patterson St</li>
                        <li><i class="fa fa-phone"></i> (229) 333-5800</li>
                        <li><i class="fa fa-envelope"></i> mwritter@valdosta.edu</li>
                    </ul>
                </div>
                <!--header-info-->
                <div class="event">
                    <!--======= FORM =======-->
                    <form id="form1" class="myForm" runat="server">

                        <div>

                            <h1>Event Maker</h1>
                            <div class="eventMaker">
                                <!--eventMaker-->
                                <asp:Label ID="Label1" runat="server" Text="Event Name:"></asp:Label>
                                <asp:TextBox ID="txtEventName" runat="server"></asp:TextBox>

                                &nbsp; Available Seat Numbers:
                                <div>
                                    <asp:Label ID="Label2" runat="server" Text="First "></asp:Label>
                                    &nbsp;
                                    <asp:TextBox ID="txtFirst" type="number" runat="server" Width="40px"></asp:TextBox>
                                    &nbsp;
                                </div>
                                <div>
                                    <asp:Label ID="Label3" runat="server" Text="Last"></asp:Label>
                                    &nbsp;&nbsp;
                                    <asp:TextBox ID="txtLast" runat="server" type="number" Width="40px"></asp:TextBox>
                                    &nbsp;
                                </div>


                                <p>
                                    <asp:Button class="btn btn-make-event" ID="btnMakeEvent" runat="server" Text="Make Event" OnClick="btnMakeEvent_Click" />
                                </p>

                            </div>

                            <br />
                            <br />
                            <div class="eventPicker">
                                <!--eventPicker-->
                                &nbsp;Pick from Events:
                                <asp:DropDownList class="dropDown" ID="DropDownEventsList" runat="server" Width="200px" AutoPostBack="False" >
                                </asp:DropDownList>
                                <asp:Button class="btn" ID="SelectEvent" runat="server" OnClick="SelectEvent_Click" Text="Select Event" />
                                <asp:Label ID="lblTicketsAvailable" runat="server" Text="No Even Selected"></asp:Label>
                                &nbsp;
                                <asp:Label ID="lblTicketsAvailableNum" runat="server" ForeColor="Red" Text="0"></asp:Label>
                                &nbsp;tickets available

                            </div>

                            <div class="ticketPurchase">
                                <!--ticketPurchase-->
                                <div>
                                    <asp:Label ID="Label4" runat="server" Text="Name"></asp:Label>
                                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                                    &nbsp;
                                </div>
                                <div>
                                    <asp:Label ID="Label5" runat="server" Text="Age"></asp:Label>
                                    <asp:TextBox ID="txtAge" runat="server" TextMode="Number" Width="40px"></asp:TextBox>
                                    &nbsp;
                                </div>
                                <div>
                                    <asp:Label ID="Label6" runat="server" Text="Seat"></asp:Label>
                                    <asp:DropDownList class="dropDown" ID="DropDownSeats" runat="server">
                                    </asp:DropDownList>
                                    &nbsp;
                                </div>
                                <asp:Button class="btn" ID="btnPurchase" runat="server" Text="Purchase" OnClick="btnPurchase_Click" />
                                <asp:Button class="btn" ID="btnEventSummary" runat="server" Text="Event Summary" OnClick="btnEventSummary_Click" />


                            </div>
                        </div>
                        <asp:TextBox hidden ID="txtTestEvents" runat="server" Height="350px" TextMode="MultiLine" Width="400px"></asp:TextBox>
                    </form>
                    <!--======= FORM =======-->
                </div>
                <!--event-->
            </div>
            <!--wrapper-->
        </div>
        <!--container-->

        <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
       
        
    </body>

    </html>