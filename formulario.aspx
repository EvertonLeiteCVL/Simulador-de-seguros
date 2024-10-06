<%@ Page Title="Simulador de Seguros" Language="C#" MasterPageFile="~/master/Site.master" AutoEventWireup="true" CodeBehind="Formulario.aspx.cs" Inherits="Simulador_de_Seguros.Formulario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Simulador de Seguros Télos</h2>
    <asp:Label ID="lblMensagem" runat="server" CssClass="error"></asp:Label>

    <div class="form-group">
        <label for="<%= txtNome.ClientID %>">Nome:</label>
        <asp:TextBox ID="txtNome" runat="server" CssClass="form-control" />
        <asp:Label ID="errorNome" runat="server" CssClass="error"></asp:Label>
    </div>

    <div class="form-group">
        <label for="<%= txtDataNascimento.ClientID %>">Data de Nascimento:</label>
        <asp:TextBox ID="txtDataNascimento" runat="server" CssClass="form-control" />
        <asp:Label ID="errorDataNascimento" runat="server" CssClass="error"></asp:Label>
    </div>

    <div class="form-group">
        <label for="<%= txtCpf.ClientID %>">CPF:</label>
        <asp:TextBox ID="txtCpf" runat="server" CssClass="form-control" />
        <asp:Label ID="errorCpf" runat="server" CssClass="error"></asp:Label>
    </div>

    <div class="form-group">
        <label for="<%= comboTipoSeguro.ClientID %>">Tipo de Seguro:</label>
        <asp:DropDownList ID="comboTipoSeguro" runat="server" CssClass="form-control">
            <asp:ListItem Value="0.8">Seguro de Vida</asp:ListItem>
            <asp:ListItem Value="0.9">Seguro de Morte Acidental</asp:ListItem>
            <asp:ListItem Value="0.5">Seguro Contra Acidentes Pessoais</asp:ListItem>
            <asp:ListItem Value="0.4">Seguro de Saúde</asp:ListItem>
            <asp:ListItem Value="2.5">Seguro de Automóvel</asp:ListItem>
            <asp:ListItem Value="0.6">Seguro Residencial</asp:ListItem>
            <asp:ListItem Value="1.2">Seguro Patrimonial</asp:ListItem>
            <asp:ListItem Value="1.5">Seguro Empresarial</asp:ListItem>
        </asp:DropDownList>
    </div>

    <asp:Button ID="BtnCalcular" runat="server" Text="Calcular" OnClick="BtnCalcular_Click" CssClass="btn btn-primary" />

    <div class="form-group">
        <label for="<%= txtResultado.ClientID %>">Valor do Seguro:</label>
        <asp:TextBox ID="txtResultado" runat="server" ReadOnly="true" CssClass="form-control" />
    </div>
</asp:Content>
