<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ViewCars.aspx.cs" Inherits="WebApplication1.ViewCars" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

            <script type="text/javascript">
            $(document).ready(function () {
                $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
            });
            </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <div class="container">
            <div class="row">

                <div class="col-sm-12">
                    <center>
                        <h3>
                        Car Inventory List</h3>
                    </center>
                    <div class="row">
                        <div class="col-sm-12 col-md-12">
                            <asp:Panel class="alert alert-success" role="alert" ID="Panel1" runat="server" Visible="False">
                                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                            </asp:Panel>
                        </div>
                    </div>

                <br />
                    <div class="row">
                        <div class="card">
               <div class="card-body">

                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                  <div class="row">
                      <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:elibraryDBConnectionString %>" SelectCommand="SELECT * FROM [car_master_tbl]"></asp:SqlDataSource>
                     <div class="col">
                        <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                            <Columns>
                                <asp:BoundField DataField="car_id" HeaderText="car_id" ReadOnly="true" SortExpression="car_id" />


                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <div class="container-fluid">
                                            <div class="row">
                                                <div class="col-lg-10">
                                                    <div class="row">
                                                        <div class="col-12">
                                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("car_name") %>' Font-Bold="True" Font-Size="X-Large"></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-12">
                                                            <span>Edition</span>
                                                            <asp:Label ID="label2" runat="server" Font-Bold="True" Text='<%# Eval("edition") %>'></asp:Label>
                                                            &nbsp;
                                                            <span>Rent Cost</span>
                                                            <asp:Label ID="label3" runat="server" Font-Bold="True" Text='<%# Eval("rent_cost") %>'></asp:Label>
                                                            &nbsp;
                                                            <span>Capacity</span>
                                                            <asp:Label ID="label4" runat="server" Font-Bold="True" Text='<%# Eval("capacity") %>'></asp:Label>
                                                            &nbsp;
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-12">
                                                            Description -
                                                   <asp:Label ID="Label12" runat="server" Font-Bold="True" Font-Italic="True" Font-Size="Smaller" Text='<%# Eval("car_description") %>'></asp:Label>
                                                        </div>
                                                    </div>



                                                </div>
                                                     <div class="col-lg-2">
                                                         <asp:Image CssClass= "img-fluid" ID="Image1" runat="server" ImageUrl='<%# Eval("car_img_link") %>' />
                                                </div>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>


                            </Columns>
                         </asp:GridView>
                     </div>
                  </div>
               </div>
            </div>
                       
                    </div>
                   </div>



                <center>
                    <a href="homepage.aspx"> Back toHome </a><span class="clearfix"></span><br />
                </center>
                </div>
                </div>




</asp:Content>
