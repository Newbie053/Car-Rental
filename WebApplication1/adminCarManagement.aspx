<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminCarManagement.aspx.cs" Inherits="WebApplication1.adminCarManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

               <div class="container">
      <div class="row">
         <div class="col-md-5">
            <div class="card">
               <div class="card-body">
                   <div class="row">
                     <div class="col">
                        <center>
                           <h4>Car Details</h4>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <center>
                            <img width="100px" src="imgs/navicon.png" />
                        </center>
                     </div>
                  </div>
                  
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>

                         <div class="row">
                     <div class="col-md-4">
                             <label>Car ID</label>
                        <div class="form-group">
                            <div class="input-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="ID"></asp:TextBox>

                              <asp:Button class="btn btn-primary" ID="Button2" runat="server" Text="Go"/>
                                </div>

                        </div>
                     
                     </div>
                              <div class="col-md-8">
                                        <label>Car Name</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Car Name"></asp:TextBox>
                        </div>
                     
                     </div>
                  </div>

                   <div class="row">
                       <div class="col-4">
                            <asp:Button class="btn btn-block btn-success" ID="Button1" runat="server" Text="Add"/>

                       </div>
                                              <div class="col-4">
                            <asp:Button class="btn btn-block btn-warning" ID="Button3" runat="server" Text="Update"/>

                       </div>
                                              <div class="col-4">
                            <asp:Button class="btn btn-block btn-danger" ID="Button4" runat="server" Text="Remove"/>

                       </div>

                   </div>





   
               </div>
            </div>
            <a href="homepage.aspx"><< Back to Home</a><br><br>
         </div>


          <div class="col-md-7">

                          <div class="card">
               <div class="card-body">
                  
                  <div class="row">
                     <div class="col">
                        <center>
                           <h4>Car List</h4>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>

                   <div class="row">
                       <div class="col"></div>
                       <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server"></asp:GridView>

                   </div>

               
   
               </div>
            </div>

          </div>

      </div>
   </div>


</asp:Content>
