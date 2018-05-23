<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EjemploDotnet._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <button id="HW" class="btn btn-default">Run JS</button>

    <button onclick="CallItem()" class="btn btn-default">View Array</button>

    <asp:Button ID="Button1" runat="server" Text="Button" />

    <asp:LinkButton ID="id_run" runat="server" OnClick="id_run_Click" OnClientClick="AnimateEjm()" class="btn btn-default">Fill Gridview</asp:LinkButton>

    <asp:DropDownList ID="DropDownList1" CssClass="form-control" runat="server">
    </asp:DropDownList>

    <br />
    <div class="panel panel-default">
        <div class="panel-body">
            <div class="table-responsive">
                <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-striped"></asp:GridView>
            </div>
        </div>
    </div>

    <div class="panel panel-default">
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
