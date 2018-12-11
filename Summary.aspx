<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Summary.aspx.cs" Inherits="Summary" %>

    <!DOCTYPE html>

    <html xmlns="http://www.w3.org/1999/xhtml">

    <head runat="server">
        <meta name="viewport" content="width=device-width,initial-scale=1.0">
        <title>Summary Page</title>
        <link href="styles/stylesheet.css" rel="stylesheet" />
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css">
        <link href="https://fonts.googleapis.com/css?family=Pacifico" rel="stylesheet">
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
            }
        </style>
    </head>

    <body>
        <div class="container">
            <h1 class="brand"><span>BlueShade</span> Web Design</h1>
            <div class="wrapper">
                <div class="header-info">
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
                </div>
                <div class="event">
                    <form class="myForm" id="form1" runat="server">
                        <div>

                            <div>

                                <h1>Ticket Holders for
                                    <asp:Label ID="lblShowText" runat="server" ForeColor="Red" Text="ShowText"></asp:Label>
                                </h1>

                                <asp:Button class="btn" ID="SellMore" runat="server" Text="Sell More Tickets" OnClick="SellMore_Click" /> &nbsp;

                                <div class="sort">
                                    <asp:Label ID="lblSort" runat="server" Text="Sort: "></asp:Label>
                                    <div class="radioBtn">
                                        <asp:RadioButton ID="radioOrder" runat="server" Checked="True" Text="Order Purchased" GroupName="Sort" AutoPostBack="True" OnCheckedChanged="radioOrder_CheckedChanged" /> &nbsp;
                                        <asp:RadioButton ID="radioName" runat="server" Text="Name" GroupName="Sort" AutoPostBack="True" OnCheckedChanged="radioName_CheckedChanged" /> &nbsp;
                                        <asp:RadioButton ID="radioSeat" runat="server" Text="Seat" GroupName="Sort" AutoPostBack="True" OnCheckedChanged="radioSeat_CheckedChanged" />
                                    </div>
                                </div>

                                <br />
                                <div class="parent">
                                    <asp:Label ID="lblRemoveHolder" runat="server" Text="Remove Ticket Holder  "></asp:Label>
                                    <asp:DropDownList class="dropDown" ID="HolderDropDownList" runat="server" Height="25px" Width="195px">
                                        <asp:ListItem>Choose Person to Remove</asp:ListItem>
                                    </asp:DropDownList>

                                    &nbsp;
                                    <asp:Button class="btn" ID="Remove" runat="server" Text="Remove" OnClick="Remove_Click" />
                                    <br />
                                    <h3>Summary</h3>
                                    
                                    <br />
                                    <div>
                                        <asp:TextBox class="textBox" ID="TextBox1" runat="server" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                </div>

                            </div>
                        </div>

                    </form>
                </div>
            </div>
        </div>



    </body>

    </html>