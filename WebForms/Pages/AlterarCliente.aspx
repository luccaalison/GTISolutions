﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="AlterarCliente.aspx.cs" Inherits="WebForms.Pages.AlterarCliente" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script src="https://code.jquery.com/jquery-3.7.0.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/jquery.mask/1.14.16/jquery.mask.min.js"></script>
<script>
    $(document).ready(function () {

        $('#<%= cpf.ClientID %>').mask('000.000.000-00', { reverse: true });

        $('#<%= cep.ClientID %>').mask('00000-000');

        $('#<%= rg.ClientID %>').mask('00.000.000-0');

        $('#<%= dtNascimento.ClientID %>').mask('99/99/9999', { placeholder: 'dd/mm/yyyy' });
    });
</script>
    <link href="https://fonts.cdnfonts.com/css/apple-chancery" rel="stylesheet">
    <style>

    h1 {
        text-align: center;
        font-weight: bold;
    }
     
</style>
<h1>Alterar Cliente</h1>



    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.4/css/all.min.css" rel="stylesheet">
    <asp:Literal ID="lblMensagemErro" runat="server" Visible="false"></asp:Literal>

    <h2>Cliente</h2>
        <div class="row">
            <div class="col-md-3">
                <label for="cpf">CPF*</label>
                <asp:TextBox ID="cpf" runat="server" CssClass="form-control"  ReadOnly="true" />
            </div>
            <div class="col-md-9">
                <label for="nome">Nome*</label>
                <asp:TextBox ID="nome" runat="server" CssClass="form-control" />
            </div>
        </div>      
        <div class="row">
            <div class="col-md-3">
                <label for="rg">RG</label>
                <asp:TextBox ID="rg" runat="server" CssClass="form-control" />
            </div>
            <div class="col-md-3">
                <label for="dtExpedicao">Data Expedição</label>
                <asp:TextBox ID="dtExpedicao" runat="server" CssClass="form-control" />
            </div>
            <div class="col-md-4">
                <label for="orgExpedicao">Órgão Expedição</label>
                    <asp:DropDownList ID="orgExpedicao" runat="server" CssClass="form-select"  >
                    </asp:DropDownList>               
            </div>
             <div class="col-md-2">
                <label for="ufExpedicao">UF Expedição</label>
                <asp:DropDownList ID="ufExpedicao" runat="server" CssClass="form-select">
                </asp:DropDownList>
            </div>
        </div>
        <div class="row">
                <div class="col-md-3">
                    <label for="dtNascimento">Data de Nascimento*</label>
                    <asp:TextBox ID="dtNascimento" runat="server" CssClass="form-control" />
                </div>
                <div class="col-md-3">
                    <label for="Sexo">Sexo*</label>
                        <asp:DropDownList ID="Sexo" runat="server" CssClass="form-select" >
                        </asp:DropDownList>               
                </div>
                 <div class="col-md-3">
                    <label for="estCivil">Estado Civil*</label>
                    <asp:DropDownList ID="estCivil" runat="server" CssClass="form-select" >
                    </asp:DropDownList>
                </div>
        </div>
        <h2>Endereço</h2>
             <div class="row ">  
                 
                
                 <div class="col-md-2">       
                       <label for="cep">CEP*</label>           
                   <div class="input-group">
                    <asp:TextBox ID="cep" runat="server" CssClass="form-control" />
                   <asp:Button ID="btnBuscar" runat="server" CssClass="btn btn-primary " Style="background-color: #00caff7a;border-color:#dee2e6;" OnClick="btnBuscar_Click" Text="🔍" />
                   </div>
                </div>
                 <div class="col-md-2">
                <label for="rua">Rua*</label>
                    <asp:TextBox ID="rua" runat="server" CssClass="form-control" />              
                </div>
                 <div class="col-md-1">
                    <label for="numero">Numero*</label>
                    <asp:TextBox ID="numero" runat="server" CssClass="form-control" />
                </div>
                 <div class="col-md-2">
                    <label for="complemento">Complemento</label>
                    <asp:TextBox ID="complemento" runat="server" CssClass="form-control" />
                </div>
                 <div class="col-md-2">
                    <label for="bairro">Bairro*</label>
                    <asp:TextBox ID="bairro" runat="server" CssClass="form-control" />
                 </div>

                 <div class="col-md-2">
                    <label for="cidade">Cidade*</label>
                    <asp:DropDownList ID="cidade" runat="server" CssClass="form-select" />                   
                </div>
                 <div class="col-md-1">
                    <label for="uf">UF*</label>
                    <asp:DropDownList ID="uf" runat="server" CssClass="form-select">
                    </asp:DropDownList>
                </div>
            </div>

            <div class="row align-items-end justify-content-center">
                <div class="col-md-2">
                   <asp:Button ID="BtnAlterar" runat="server" Text="Alterar ›"
                        OnClick="btnAlterar_Click" CssClass="btn btn-default" 
                        style="position: relative; background-color:#a8bc14" />
                </div>
            </div>

</asp:Content>
