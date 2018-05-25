﻿<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EjemploDotnet._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <br />

    <div>
        <%-- Comentario prueba --%>
        <%-- Comentario prueba dos --%>

        <!-- Nav tabs -->
        <ul class="nav nav-tabs" role="tablist">
            <li role="presentation" class="active"><a href="#home" aria-controls="home" role="tab" data-toggle="tab">Home</a></li>
            <li role="presentation"><a href="#profile" aria-controls="profile" role="tab" data-toggle="tab">Profile</a></li>
            <li role="presentation"><a href="#messages" aria-controls="messages" role="tab" data-toggle="tab">Messages</a></li>
            <li role="presentation"><a href="#settings" aria-controls="settings" role="tab" data-toggle="tab">Settings</a></li>
        </ul>

        <!-- Tab panes -->
        <div class="tab-content">
            <div role="tabpanel" class="tab-pane active" id="home">

                <asp:UpdatePanel ID="up_tab1" runat="server">
                    <ContentTemplate>

                        <div>

                            <button id="HW" class="btn btn-default">Run JS</button>

                            <button onclick="CallItem()" class="btn btn-default">View Array</button>

                            <asp:Button ID="Button1" runat="server" Text="Button" />

                            <asp:LinkButton ID="id_run" runat="server" OnClick="id_run_Click" OnClientClick="AnimateEjm()" class="btn btn-default">Fill Gridview</asp:LinkButton>

                            <asp:DropDownList ID="DropDownList1" CssClass="form-control" AutoPostBack="true" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                            </asp:DropDownList>

                            <h3 class="animated infinite <%= DropDownList1.SelectedItem.Value%>"><%=DropDownList1.SelectedItem.Text%></h3>

                            <br />
                            <div class="panel panel-default">
                                <div class="panel-body">
                                    <div class="table-responsive">
                                        <asp:GridView ID="GridView1" runat="server" GridLines="None" CssClass="table table-hover table-striped"></asp:GridView>
                                    </div>
                                </div>
                            </div>

                            <div class="panel panel-default" style="display: none">
                                <div class="panel-body">
                                    <div class="table-responsive">

                                        <table class="table table-hover table-striped">
                                            <thead>
                                                <tr>
                                                    <th>Name</th>
                                                    <th>Grp</th>
                                                    <th>Dep</th>
                                                    <th>Mod</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <%foreach (var x in Grupo())
                                                    { %>
                                                <tr>
                                                    <td><%=x.Name%></td>
                                                    <td><%=x.GroupName%></td>
                                                    <td><%=x.DepartmentID%></td>
                                                    <td><%=x.ModifiedDate%></td>
                                                </tr>
                                                <%} %>
                                            </tbody>
                                        </table>

                                    </div>
                                </div>
                            </div>
                        </div>

                    </ContentTemplate>
                </asp:UpdatePanel>

            </div>
            <div role="tabpanel" class="tab-pane" id="profile">

                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>

                        <asp:TextBox ID="txb_dato" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:LinkButton ID="lbtn_animate" runat="server" CssClass="btn btn-default" OnClick="lbtn_animate_Click">Run</asp:LinkButton>
                        <br />
                        <asp:Label ID="lb_title" runat="server"></asp:Label>

                    </ContentTemplate>
                </asp:UpdatePanel>

            </div>
            <div role="tabpanel" class="tab-pane" id="messages">

                <asp:UpdatePanel ID="up_formulario" runat="server">
                    <ContentTemplate>
                        <br />
                        <asp:TextBox ID="txb_name" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:DropDownList ID="ddl_grp" runat="server" CssClass="form-control"></asp:DropDownList>


                        <asp:LinkButton ID="lbtn_add" runat="server" CssClass="btn btn-default" OnClick="lbtn_add_Click">
                            <i class="fa fa-plus" aria-hidden="true"></i>
                        </asp:LinkButton>
                        <asp:LinkButton ID="lbtn_save" runat="server" CssClass="btn btn-primary" OnClick="lbtn_save_Click">
                            <i class="fa fa-floppy-o" aria-hidden="true"></i>
                        </asp:LinkButton>
                        <asp:LinkButton ID="lbtn_refresh" runat="server" CssClass="btn btn-info" OnClick="lbtn_refresh_Click">
                            <i class="fa fa-refresh" aria-hidden="true"></i>
                        </asp:LinkButton>

                        <br />

                        <asp:GridView ID="id_gvreg" runat="server" GridLines="None" CssClass="table table-hover table-striped"></asp:GridView>

                    </ContentTemplate>
                </asp:UpdatePanel>


            </div>
            <div role="tabpanel" class="tab-pane" id="settings">...</div>
        </div>

    </div>

</asp:Content>

<asp:Content ContentPlaceHolderID="cph_scripts" ID="scrips" runat="server">

    <script type="text/javascript">

        Hello();

        function CallItem() {

            <%foreach (var x in Grupo())
        {%>

            alert('<%=x.GroupName%>');

            <%}%>
        }

    </script>

</asp:Content>
