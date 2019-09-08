<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Alumnos.aspx.cs" Inherits="Proyecto4.Alumnos.Alumnos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>ALUMNOS</h1>
    <div class="row">

        <div class="col-md-3">
            <asp:Label ID="LblMat" runat="server" Text="Matrícula:"></asp:Label>
            <asp:TextBox ID="TxtMat" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RfvMatricula" ControlToValidate="TxtMat" runat="server" ForeColor="Red" ErrorMessage="Matricula requerida"></asp:RequiredFieldValidator>
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

        <div class="col-md-3">
            <asp:Label ID="LblTel" runat="server" Text="Teléfono:"></asp:Label>
            <asp:TextBox ID="TxtTel" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RfvTel" ForeColor="Red" ControlToValidate="TxtTel" runat="server" ErrorMessage="Teléfono requerido"></asp:RequiredFieldValidator>
        </div>

        <div class="col-md-3">
            <asp:Label ID="LblCorreo" runat="server" Text="Correo:"></asp:Label>
            <asp:TextBox ID="TxtCorreo" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" ControlToValidate="TxtCorreo" runat="server" ErrorMessage="Correo requerido"></asp:RequiredFieldValidator>
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
            <asp:Button ID="btnInsert" runat="server" Text="Ingresar" OnClick="btnInsert_Click1" />
        </div>
        <div class="col-md-4">
            <asp:Button ID="btnUpdate" runat="server" Text="Actualizar" OnClick="btnUpdate_Click" />
        </div>
        <div class="col-md-4">
            <asp:Button ID="btnDelete" runat="server" Text="Eliminar" OnClick="btnDelete_Click"/>
        </div>
    </div>

    <div class="row">
        <div class="col-md-12">
            <asp:GridView ID="GVAlumnosEdoMunLoc" runat="server" AutoGenerateColumns="False" DataKeyNames="Matricula" DataSourceID="SqlDataSourceAlumnoEdoMunLoc" CellPadding="4" OnSelectedIndexChanged="GVAlumnosEdoMunLoc_SelectedIndexChanged" OnRowDataBound="GVAlumnosEdoMunLoc_RowDataBound"  ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>
                <Columns>
                    <asp:CommandField ShowSelectButton="True" ButtonType="Button"></asp:CommandField>
                    <asp:BoundField DataField="Matricula" HeaderText="Matricula" ReadOnly="True" SortExpression="Matricula"></asp:BoundField>
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre"></asp:BoundField>

                    <asp:BoundField DataField="ApePaterno" HeaderText="ApePaterno" SortExpression="ApePaterno"></asp:BoundField>
                    <asp:BoundField DataField="ApeMaterno" HeaderText="ApeMaterno" SortExpression="ApeMaterno"></asp:BoundField>

                    <asp:BoundField DataField="Telefono" HeaderText="Telefono" SortExpression="Telefono"></asp:BoundField>
                    <asp:BoundField DataField="Correo" HeaderText="Correo" SortExpression="Correo"></asp:BoundField>
                    <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado"></asp:BoundField>
                    <asp:BoundField DataField="Municipio" HeaderText="Municipio" SortExpression="Municipio"></asp:BoundField>
                    <asp:BoundField DataField="Localidad" HeaderText="Localidad" SortExpression="Localidad"></asp:BoundField>
                    <asp:BoundField DataField="Latitud" HeaderText="Latitud" SortExpression="Latitud"></asp:BoundField>
                    <asp:BoundField DataField="Longitud" HeaderText="Longitud" SortExpression="Longitud"></asp:BoundField>
                </Columns>

                <EditRowStyle BackColor="#999999"></EditRowStyle>

                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></FooterStyle>

                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></HeaderStyle>

                <PagerStyle HorizontalAlign="Center" BackColor="#284775" ForeColor="White"></PagerStyle>

                <RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>

                <SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>

                <SortedAscendingCellStyle BackColor="#E9E7E2"></SortedAscendingCellStyle>

                <SortedAscendingHeaderStyle BackColor="#506C8C"></SortedAscendingHeaderStyle>

                <SortedDescendingCellStyle BackColor="#FFFDF8"></SortedDescendingCellStyle>

                <SortedDescendingHeaderStyle BackColor="#6F8DAE"></SortedDescendingHeaderStyle>
            </asp:GridView>
            <asp:SqlDataSource runat="server" ID="SqlDataSourceAlumnoEdoMunLoc" ConnectionString='<%$ ConnectionStrings:UPPConnectionString %>' SelectCommand="SELECT [Matricula], [Nombre], [ApePaterno], [ApeMaterno], [Telefono], [Correo], [Estado], [Municipio], [Localidad], [Latitud], [Longitud] FROM [AlumnoEdoMunLoc]"></asp:SqlDataSource>
        </div>
    </div>


 <div class="row">
        <div class="col-md-12">
            <map:googlemap id="GoogleMap1" latitude="19.9797410001" longitude="-98.6846520004 " runat="server" maptype="HYBRID" zoom="16" cssclass="Map" width="100%" ApiKey="">
            </map:googlemap>
        </div>
    </div>

</asp:Content>
