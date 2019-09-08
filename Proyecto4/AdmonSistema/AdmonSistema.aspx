<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdmonSistema.aspx.cs" Inherits="Proyecto4.AdmonSistema.AdmonSistema" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <asp:Label ID="LblRolMensage" runat="server" Text=""></asp:Label>
    <asp:Label ID="LblRol" runat="server" Text="Rol"></asp:Label>
    <asp:TextBox ID="TxtRol" runat="server"></asp:TextBox>

    <asp:Button ID="BntCrearRol" runat="server" Text="Crear Rol" OnClick="BntCrearRol_Click" />

    <asp:Button ID="BtnEliRol" runat="server" Text="Eliminar Rol" />
    <asp:GridView ID="GvdRoles" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSourceRoles" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GvdRoles_SelectedIndexChanged">
        <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
        <Columns>
            <asp:CommandField ShowSelectButton="True" ButtonType="Button"></asp:CommandField>
            <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id"></asp:BoundField>
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name"></asp:BoundField>
        </Columns>

        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White"></FooterStyle>

        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White"></HeaderStyle>

        <PagerStyle HorizontalAlign="Center" BackColor="#FFCC66" ForeColor="#333333"></PagerStyle>

        <RowStyle BackColor="#FFFBD6" ForeColor="#333333"></RowStyle>

        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy"></SelectedRowStyle>

        <SortedAscendingCellStyle BackColor="#FDF5AC"></SortedAscendingCellStyle>

        <SortedAscendingHeaderStyle BackColor="#4D0000"></SortedAscendingHeaderStyle>

        <SortedDescendingCellStyle BackColor="#FCF6C0"></SortedDescendingCellStyle>

        <SortedDescendingHeaderStyle BackColor="#820000"></SortedDescendingHeaderStyle>
    </asp:GridView>

    <asp:SqlDataSource runat="server" ID="SqlDataSourceRoles" ConnectionString='<%$ ConnectionStrings:UPPConnectionString %>' SelectCommand="SELECT [Id], [Name] FROM [AspNetRoles]"></asp:SqlDataSource>

    <div class="row">
        <div class="col-md-3">
            <asp:Label ID="LblUser" runat="server" Text="Usuario:"></asp:Label>
            <asp:TextBox ID="txtUser" runat="server"></asp:TextBox>
        </div>
    </div>

    <div class="row">
        <div class="col-md-3">
            <asp:Label ID="LbCorreo" runat="server" Text="Correo:"></asp:Label>
            <asp:TextBox ID="TxtEmail" TextMode="Email" runat="server"></asp:TextBox>
        </div>
    </div>

    <div class="row">
        <div class="col-md-3">
            <asp:Label ID="LblPass" runat="server" Text="Contraseña:"></asp:Label>
            <asp:TextBox ID="PwdUser1" TextMode="Password" runat="server"></asp:TextBox>
            
        </div>
    </div>

    <div class="row">
        <div class="col-md-3">
            <asp:Label ID="LblPassA" runat="server" Text="Confirmar Contraseña:"></asp:Label>
           <asp:TextBox ID="PwdUserA" TextMode="Password" runat="server"></asp:TextBox>
         
                
        </div>
    </div>


    <div class="row">
        <div class="col-md-4">
            <asp:Button ID="btnInsert" runat="server" Text="Crear Usuario" OnClick="btnInsert_Click" />
        </div>
    </div>

    <div class="row">
        <div class="col-md-4">
            <asp:Button ID="btnDelete" runat="server" Text="Eliminar Usuario" />
        </div>
    </div>

    <asp:Button ID="AsignarRol" runat="server" Text="Asignar Rol" OnClick="AsignarRol_Click" />

    <asp:GridView ID="GdvRoles2" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSourceAsp" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GvdRoles2_SelectedIndexChanged">
        <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
        <Columns>
            <asp:CommandField ShowSelectButton="True" ButtonType="Button"></asp:CommandField>
            <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id"></asp:BoundField>

            <asp:BoundField DataField="UserName" HeaderText="UserName" SortExpression="UserName"></asp:BoundField>
            <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email"></asp:BoundField>
        </Columns>
        <EditRowStyle BackColor="#7C6F57"></EditRowStyle>


        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White"></FooterStyle>

        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White"></HeaderStyle>

        <PagerStyle HorizontalAlign="Center" BackColor="#666666" ForeColor="White"></PagerStyle>

        <RowStyle BackColor="#E3EAEB"></RowStyle>

        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

        <SortedAscendingCellStyle BackColor="#F8FAFA"></SortedAscendingCellStyle>

        <SortedAscendingHeaderStyle BackColor="#246B61"></SortedAscendingHeaderStyle>

        <SortedDescendingCellStyle BackColor="#D4DFE1"></SortedDescendingCellStyle>

        <SortedDescendingHeaderStyle BackColor="#15524A"></SortedDescendingHeaderStyle>
    </asp:GridView>

    <asp:SqlDataSource runat="server" ID="SqlDataSourceAsp" ConnectionString='<%$ ConnectionStrings:UPPConnectionString %>' SelectCommand="SELECT [Id], [UserName], [Email] FROM [AspNetUsers]"></asp:SqlDataSource>

    <asp:GridView ID="GdvUsuariosRoles" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSourceUsuariosRoles" CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
        <Columns>
            <asp:BoundField DataField="UserName" HeaderText="UserName" SortExpression="UserName"></asp:BoundField>
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name"></asp:BoundField>
        </Columns>
        <EditRowStyle BackColor="#7C6F57"></EditRowStyle>

        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White"></FooterStyle>

        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White"></HeaderStyle>

        <PagerStyle HorizontalAlign="Center" BackColor="#666666" ForeColor="White"></PagerStyle>

        <RowStyle BackColor="#E3EAEB"></RowStyle>

        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

        <SortedAscendingCellStyle BackColor="#F8FAFA"></SortedAscendingCellStyle>

        <SortedAscendingHeaderStyle BackColor="#246B61"></SortedAscendingHeaderStyle>

        <SortedDescendingCellStyle BackColor="#D4DFE1"></SortedDescendingCellStyle>

        <SortedDescendingHeaderStyle BackColor="#15524A"></SortedDescendingHeaderStyle>
    </asp:GridView>

    <asp:SqlDataSource runat="server" ID="SqlDataSourceUsuariosRoles" ConnectionString='<%$ ConnectionStrings:UPPConnectionString %>' SelectCommand="SELECT AspNetUsers.UserName, AspNetRoles.Name FROM AspNetUserRoles INNER JOIN AspNetRoles ON AspNetUserRoles.RoleId = AspNetRoles.Id INNER JOIN AspNetUsers ON AspNetUserRoles.UserId = AspNetUsers.Id"></asp:SqlDataSource>
    
    <asp:SqlDataSource ID="SqlDataSourceIngresarRol" runat="server" ConnectionString='<%$ ConnectionStrings:UPPConnectionString %>' InsertCommand="INSERT INTO AspNetUserRoles(UserId, RoleId) VALUES (@userid, @rolid)" SelectCommand="SELECT AspNetUsers.UserName, AspNetRoles.Name FROM AspNetUsers INNER JOIN AspNetUserRoles ON AspNetUsers.Id = AspNetUserRoles.UserId INNER JOIN AspNetRoles ON AspNetUserRoles.RoleId = AspNetRoles.Id">
        <InsertParameters>
            <asp:Parameter Name="userid"></asp:Parameter>
            <asp:Parameter Name="rolid"></asp:Parameter>
        </InsertParameters>
    </asp:SqlDataSource>

</asp:Content>
