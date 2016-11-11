<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="true" Inherits="Admin_Baner_NewManageBanner" Title="Admin - Manage Banner" Codebehind="NewManageBanner.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="innerContent" style="width:900px;">
        <div class="pageTitle">
            <h2>
                Manage Banner</h2>
        </div>
        
          <div class="errorDiv" id="divError" runat="server" visible="false">
            <table width="100%">
                <tbody>
                    <tr>
                        <td align="left" rowspan="2">
                            <asp:Label ID="lblError" runat="server" Visible="False" Font-Bold="True"></asp:Label>&nbsp;
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <br style="clear:both;" />
       <table class="setservPage">
             <tr>
                <td style="width:15%;"> Select Page :</td>
                <td>  <asp:DropDownList ID="ddlPage" runat="server"  AutoPostBack="true"
                       >
                    <asp:ListItem Value="0" Text="Home" ></asp:ListItem>
                    <asp:ListItem Value="1" Text="Services" ></asp:ListItem>
                    <asp:ListItem Value="2" Text="ServiceDetail" ></asp:ListItem>
                    <asp:ListItem Value="3" Text="Product" ></asp:ListItem>
                    <asp:ListItem Value="4" Text="Flea" ></asp:ListItem>
                    <asp:ListItem Value="5" Text="Fritzy Friend" ></asp:ListItem>
                    <asp:ListItem Value="6" Text="About Us" ></asp:ListItem>
                    <asp:ListItem Value="7" Text="Contact Us" ></asp:ListItem>
                    <asp:ListItem Value="8" Text="Registration" ></asp:ListItem>
                    <asp:ListItem Value="9" Text="News Detail" ></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td> User Type : </td>
                <td><asp:DropDownList ID="ddlUserType" runat="server" AutoPostBack="true"
                        >
                <asp:ListItem Value="0" Text="Unregistered User" ></asp:ListItem>
                <asp:ListItem Value="1" Text="Registerd User - Cat" ></asp:ListItem>
                <asp:ListItem Value="2" Text="Registerd User - Dog" ></asp:ListItem>
                <asp:ListItem Value="3" Text="Registerd User - Cat & Dog" ></asp:ListItem>
                </asp:DropDownList></td>
               
            </tr>
           
        </table>
        <div style="border:0px solid #ff0;">
            <div class="matrix">
                    <table border="0" width="100%" class="mngTable" cellpadding="1" cellspacing="0">
                        <tr>
                            <th>Sr.</th>
                            <th>1</th>
                            <th>2</th>
                            <th>3</th>
                            <th>4</th>
                            <th>5</th>
                            <th>6</th>
                            <th>7</th>
                            <th>8</th>
                            <th>9</th>
                            <th>10</th>
                        </tr>
                        <tr>
                            <th>1</th>
                            <td>
                            <img src="../images/Sunset.jpg" width="80px" height="50px" alt=""/><br />
                                <asp:TextBox ID="TextBox10" runat="server" CssClass="txt" Text="3" ></asp:TextBox>
                            
                            </td>
                            <td>
                            <img src="../images/bannerimages/36banner05.jpg" width="80px" height="50px" alt=""/><br />
                                <asp:TextBox ID="TextBox11" runat="server" CssClass="txt" Text="1"></asp:TextBox>
                                
                            </td>
                            <td>
                                <img src="../images/bannerimages/43banner12.jpg" width="80px" height="50px" alt=""/><br />
                                <asp:TextBox ID="TextBox12" runat="server" CssClass="txt" Text="2"></asp:TextBox>
                            </td>
                            <td>
                            <img src="../images/bannerimages/38banner07.jpg" width="80px" height="50px" alt=""/><br />
                                <asp:TextBox ID="TextBox13" runat="server" CssClass="txt" Text="4"></asp:TextBox></td>
                            <td>
                             <img src="../images/Sunset.jpg" width="80px" height="50px" alt=""/><br />
                            
                                <asp:TextBox ID="TextBox14" runat="server" CssClass="txt" Text="3"></asp:TextBox></td>
                            <td>
                            <img src="../images/bannerimages/40banner09.jpg" width="80px" height="50px" alt=""/><br />
                                <asp:TextBox ID="TextBox15" runat="server" CssClass="txt" Text="5"></asp:TextBox></td>
                            <td>
                            <img src="../images/bannerimages/41banner10.jpg" width="80px" height="50px" alt=""/><br />
                                <asp:TextBox ID="TextBox16" runat="server" CssClass="txt" Text="6"></asp:TextBox></td>
                            <td>
                                <img src="../images/bannerimages/39banner08.jpg" width="80px" height="50px" alt=""/><br />
                                <asp:TextBox ID="TextBox17" runat="server" CssClass="txt" Text="7"></asp:TextBox></td>
                            <td>
                            <img src="../images/Sunset.jpg" width="80px" height="50px" alt=""/><br />
                                <asp:TextBox ID="TextBox18" runat="server" CssClass="txt" Text="3"></asp:TextBox></td>
                            <td>
                             <img src="../images/bannerimages/37banner06.jpg" width="80px" height="50px" alt=""/><br />
                            
                                <asp:TextBox ID="TextBox19" runat="server" CssClass="txt" Text="8"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <th>2</th>
                            <td>
                           <img src="../images/bannerimages/36banner05.jpg" width="80px" height="50px" alt=""/><br />
                                <asp:TextBox ID="TextBox20" runat="server" CssClass="txt" Text="1"></asp:TextBox>
                            
                            </td>
                            <td>
                            <img src="../images/bannerimages/44Book On-Line 5 Off 090725.jpg" width="80px" height="50px" alt=""/><br />
                                <asp:TextBox ID="TextBox21" runat="server" CssClass="txt" Text="9"></asp:TextBox>
                                
                            </td>
                            <td>
                                <img src="../images/bannerimages/43banner12.jpg" width="80px" height="50px" alt=""/><br />
                                <asp:TextBox ID="TextBox22" runat="server" CssClass="txt" Text="2"></asp:TextBox>
                            </td>
                            <td>
                            <img src="../images/bannerimages/38banner07.jpg" width="80px" height="50px" alt=""/><br />
                                <asp:TextBox ID="TextBox23" runat="server" CssClass="txt" Text="4"></asp:TextBox></td>
                            <td>
                             <img src="../images/Sunset.jpg" width="80px" height="50px" alt=""/><br />
                            
                                <asp:TextBox ID="TextBox24" runat="server" CssClass="txt" Text="3"></asp:TextBox></td>
                            <td>
                            <img src="../images/bannerimages/40banner09.jpg" width="80px" height="50px" alt=""/><br />
                                <asp:TextBox ID="TextBox25" runat="server" CssClass="txt" Text="5"></asp:TextBox></td>
                            <td>
                            <img src="../images/bannerimages/41banner10.jpg" width="80px" height="50px" alt=""/><br />
                                <asp:TextBox ID="TextBox26" runat="server" CssClass="txt" Text="6"></asp:TextBox></td>
                            <td>
                                <img src="../images/bannerimages/39banner08.jpg" width="80px" height="50px" alt=""/><br />
                                <asp:TextBox ID="TextBox27" runat="server" CssClass="txt" Text="7"></asp:TextBox></td>
                            <td>
                           <img src="../images/bannerimages/45Book On-Line Free TB 090730.jpg" width="80px" height="50px" alt=""/><br />
                                <asp:TextBox ID="TextBox28" runat="server" CssClass="txt" Text="10"></asp:TextBox></td>
                            <td>
                             <img src="../images/bannerimages/37banner06.jpg" width="80px" height="50px" alt=""/><br />
                            
                                <asp:TextBox ID="TextBox29" runat="server" CssClass="txt" Text="8"></asp:TextBox></td>
                        </tr>
                        
                        <tr>
                            <th>3</th>
                            <td><br /><asp:TextBox ID="TextBox1" runat="server" CssClass="txt" Text=""></asp:TextBox></td>
                            <td><br /><asp:TextBox ID="TextBox2" runat="server" CssClass="txt" Text=""></asp:TextBox></td>
                            <td><br /><asp:TextBox ID="TextBox3" runat="server" CssClass="txt" Text=""></asp:TextBox></td>
                            <td><br /><asp:TextBox ID="TextBox4" runat="server" CssClass="txt" Text=""></asp:TextBox></td>
                            <td><br /><asp:TextBox ID="TextBox5" runat="server" CssClass="txt" Text=""></asp:TextBox></td>
                            <td><br /><asp:TextBox ID="TextBox6" runat="server" CssClass="txt" Text=""></asp:TextBox></td>
                            <td><br /><asp:TextBox ID="TextBox7" runat="server" CssClass="txt" Text=""></asp:TextBox></td>
                            <td><br /><asp:TextBox ID="TextBox8" runat="server" CssClass="txt" Text=""></asp:TextBox></td>
                            <td><br /><asp:TextBox ID="TextBox9" runat="server" CssClass="txt" Text=""></asp:TextBox></td>
                            <td><br /><asp:TextBox ID="TextBox30" runat="server" CssClass="txt" Text=""></asp:TextBox></td>
                        </tr>
                        
                     
                        
                    </table>
                    
                    <br />
                    <asp:Button ID="btnSave" CssClass="servbtnBg" runat="server" Text="Save" />
                    <br /><br />
            </div>
            
            <br />
            
            <div class="bottommatrix">
                <table border="0" width="100%" class="mngTable" cellpadding="1" cellspacing="0">
                        <tr>
                            <th>1</th>
                            <td>
                            <img src="../images/bannerimages/36banner05.jpg" width="80px" height="50px" alt=""/><br />
                                1<br />
                            
                            </td>
                            <td>
                             <img src="../images/bannerimages/43banner12.jpg" width="80px" height="50px" alt=""/><br />
                                2<br />
                                
                            </td>
                            <td>
                               <img src="../images/Sunset.jpg" width="80px" height="50px" alt=""/><br />
                                3<br />
                            </td>
                            <td>
                             <img src="../images/bannerimages/38banner07.jpg" width="80px" height="50px" alt=""/><br />
                               4<br /></td>
                            <td>
                             <img src="../images/bannerimages/40banner09.jpg" width="80px" height="50px" alt=""/><br />
                            
                                5<br /></td>
                            <td>
                            <img src="../images/bannerimages/41banner10.jpg" width="80px" height="50px" alt=""/><br />
                                6<br /></td>
                            <td>
                            <img src="../images/bannerimages/39banner08.jpg" width="80px" height="50px" alt=""/><br />
                                7<br /></td>
                            <td>
                                <img src="../images/bannerimages/37banner06.jpg" width="80px" height="50px" alt=""/><br />
                                8<br /></td>
                            <td>
                            <img src="../images/bannerimages/44Book On-Line $5 Off 090725.jpg" width="80px" height="50px" alt=""/><br />
                                9<br /></td>
                            <td>
                             <img src="../images/bannerimages/45Book On-Line Free TB 090730.jpg" width="80px" height="50px" alt=""/><br />
                            
                                10<br /></td>
                        </tr>
                      
                    </table>
            </div>
        </div>
        
    </div>

</asp:Content>

