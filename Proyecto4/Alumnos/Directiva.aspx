<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Directiva.aspx.cs" Inherits="Proyecto4.Alumnos.Directiva" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>DIRECTIVOS</h1>
    <div class="row">

        <div class="col-md-3">
            <asp:Label ID="LblNomi" runat="server" Text="Nómina:"></asp:Label>
            <asp:TextBox ID="TxtNomi" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RfvMatricula" ControlToValidate="TxtNomi" runat="server" ForeColor="Red" ErrorMessage="Nómina requerida"></asp:RequiredFieldValidator>
        </div>

        <div class="col-md-3">
            <asp:Label ID="LblNom" runat="server" Text="Nombre(s):"></asp:Label>
            <asp:TextBox ID="TxtNom" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RfvNombre" ControlToValidate="TxtNom" runat="server" ForeColor="Red" ErrorMessage="Nombre requerido"></asp:RequiredFieldValidator>
        </div>

        <div class="col-md-3">
            <asp:Label ID="LblApeP" runat="server" Text="Apellido Paterno:"></asp:Label>
            <asp:TextBox ID="TxtApeP" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RfvApelldoP" ForeColor="Red" ControlToValidate="TxtApeP" runat="server" ErrorMessage="Apellido Paterno requerido"></asp:RequiredFieldValidator>
        </div>

        <div class="col-md-3">
            <asp:Label ID="LblApeM" runat="server" Text="Apellido Materno:"></asp:Label>
            <asp:TextBox ID="TxtApeM" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RfvApellidoM" ForeColor="Red" ControlToValidate="TxtApeM" runat="server" ErrorMessage="Apellido Materno requerido"></asp:RequiredFieldValidator>
        </div>

    </div>

    <div class="row">

        <div class="col-md-4">
        <asp:DropDownList ID="DDEstado" runat="server" DataSourceID="SqlDataSourceEstado" DataTextField="Estado" DataValueField="cveEstado" AutoPostBack="True"></asp:DropDownList>
        <asp:SqlDataSource runat="server" ID="SqlDataSourceEstado" ConnectionString='<%$ ConnectionStrings:UPPConnectionString %>' SelectCommand="ConsultaEstado" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
        </div>

        <div class="col-md-4">
            <asp:DropDownList ID="DDMunicipio" runat="server" DataSourceID="SqlDataSourceMunicipio" DataTextField="Municipio" DataValueField="cveMunicipio" AutoPostBack="True"></asp:DropDownList>
        <asp:SqlDataSource runat="server" ID="SqlDataSourceMunicipio" ConnectionString='<%$ ConnectionStrings:UPPConnectionString %>' SelectCommand="ConsultaMunicipios" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:ControlParameter ControlID="DDEstado" PropertyName="SelectedValue" Name="cveEstado" Type="Int32"></asp:ControlParameter>
            </SelectParameters>
        </asp:SqlDataSource>
         </div>

        <div class="col-md-4">
        <asp:DropDownList ID="DDLocalidad" runat="server" DataSourceID="SqlDataSourceLocalidad" DataTextField="Localidad" DataValueField="cveLocalidad" AutoPostBack="True"></asp:DropDownList>
        <asp:SqlDataSource runat="server" ID="SqlDataSourceLocalidad" ConnectionString='<%$ ConnectionStrings:UPPConnectionString %>' SelectCommand="ConsultaLocalidad" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:ControlParameter ControlID="DDEstado" PropertyName="SelectedValue" Name="cveEstado" Type="Int32"></asp:ControlParameter>
                <asp:ControlParameter ControlID="DDMunicipio" PropertyName="SelectedValue" Name="cveMunicipio" Type="Int32"></asp:ControlParameter>
            </SelectParameters>
        </asp:SqlDataSource>
        </div>
    </div>

    <div class="row">
        <div class="col-md-4">
            <asp:Button ID="btnInsert" runat="server" Text="Ingresar" OnClick="btnInsert_Click"/>
        </div>
        <div class="col-md-4">
            <asp:Button ID="btnUpdate" runat="server" Text="Actualizar" OnClick="btnUpdate_Click" />
        </div>
        <div class="col-md-4">
            <asp:Button ID="btnDelete" runat="server" Text="Eliminar" OnClick="btnDelete_Click" />
        </div>
    </div>

    <div class="row">
        <div class="col-md-12">
            <asp:GridView ID="GVDirectivoEdoMunLoc" runat="server" AutoGenerateColumns="False" DataKeyNames="Nomina" DataSourceID="SqlDataSourceDirectivo" CellPadding="4" OnSelectedIndexChanged="GVDirectivoEdoMunLoc_SelectedIndexChanged" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White"></AlternatingRowStyle>
                <Columns>
                    <asp:CommandField ShowSelectButton="True" ButtonType="Button"></asp:CommandField>
                    <asp:BoundField DataField="Nomina" HeaderText="Nomina" ReadOnly="True" SortExpression="Nomina"></asp:BoundField>
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre"></asp:BoundField>

                    <asp:BoundField DataField="ApePaterno" HeaderText="ApePaterno" SortExpression="ApePaterno"></asp:BoundField>
                    <asp:BoundField DataField="ApeMaterno" HeaderText="ApeMaterno" SortExpression="ApeMaterno"></asp:BoundField>
                    <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado"></asp:BoundField>
                    <asp:BoundField DataField="Municipio" HeaderText="Municipio" SortExpression="Municipio"></asp:BoundField>
                    <asp:BoundField DataField="Localidad" HeaderText="Localidad" SortExpression="Localidad"></asp:BoundField>
                    <asp:BoundField DataField="Latitud" HeaderText="Latitud" SortExpression="Latitud"></asp:BoundField>
                    <asp:BoundField DataField="Longitud" HeaderText="Longitud" SortExpression="Longitud"></asp:BoundField>
                </Columns>

                <EditRowStyle BackColor="#7C6F57"></EditRowStyle>

                <FooterStyle BackColor="#1C5E55" ForeColor="White" Font-Bold="True"></FooterStyle>

                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White"></HeaderStyle>

                <PagerStyle HorizontalAlign="Center" BackColor="#666666" ForeColor="White"></PagerStyle>

                <RowStyle BackColor="#E3EAEB"></RowStyle>

                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>

                <SortedAscendingCellStyle BackColor="#F8FAFA"></SortedAscendingCellStyle>

                <SortedAscendingHeaderStyle BackColor="#246B61"></SortedAscendingHeaderStyle>

                <SortedDescendingCellStyle BackColor="#D4DFE1"></SortedDescendingCellStyle>

                <SortedDescendingHeaderStyle BackColor="#15524A"></SortedDescendingHeaderStyle>
            </asp:GridView>
            <asp:SqlDataSource runat="server" ID="SqlDataSourceDirectivo" ConnectionString='<%$ ConnectionStrings:UPPConnectionString %>' SelectCommand="SELECT [Nomina], [Nombre], [ApePaterno], [ApeMaterno], [Estado], [Municipio], [Localidad], [Latitud], [Longitud] FROM [DirectivoEdoMunLoc]"></asp:SqlDataSource>
         
        </div>
    </div>


 <div class="row">
        <div class="col-md-12">
            <map:googlemap id="GoogleMap2" latitude="19.9797410001" longitude="-98.6846520004 " runat="server" maptype="HYBRID" zoom="16" cssclass="Map" width="100%" ApiKey="">
            </map:googlemap>
        </div>
    </div>
</asp:Content>
