<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CarlosCardonaWeb._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <section class="row" aria-labelledby="aspnetTitle">
            <h1 id="aspnetTitle">Lista de Actas</h1>
            <p class="lead">A continuación podrá gestionar las actas de la empresa.</p>

        </section>

        <div class="container text-center mt-5">
            <div class="row ">

                <div class="col-4 bg-light  d-flex flex-column  " style="padding: 20px 80px">
                    <div class="">
                        <p class="lead text-primary text-start fw-bold">Agrega actas de reunión </p>
                    </div>
                    <div class="">
                        <div class=" text-start mb-4">
                            <asp:Label ID="Label1" runat="server" Text="Fecha"></asp:Label>
                            <asp:TextBox ID="dateInput1" CssClass="form-control" runat="server" TextMode="Date"></asp:TextBox>


                        </div>

                        <div class=" text-start  mb-4">
                            <asp:Label ID="Label2" runat="server" Text="Lugar"></asp:Label>
                            <asp:TextBox ID="place" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>

                        <div class=" text-start  mb-4">
                            <asp:Label ID="Label3" runat="server" Text="Presidente de la reunión"></asp:Label>
                            <asp:TextBox ID="chairman_meeting" CssClass="form-control" runat="server"></asp:TextBox>

                        </div>

                        <div class=" text-start  mb-4">
                            <asp:Label ID="Label4" runat="server" Text="Resumen de la reunión"></asp:Label>
                            <asp:TextBox ID="resume" CssClass="form-control" runat="server"></asp:TextBox>

                        </div>
                    </div>

                    <div class="row">
                      <asp:Button  CssClass="btn btn-warning mb-3"  ID="updateBtn" runat="server" Text="Actializar Acta" Visible="False" OnClick="updateBtn_Click" />

                      <asp:Button CssClass="btn btn-primary" ID="BtnCreate" runat="server" Text="Guardar Acta" OnClick="BtnCreate_Click" />
                    </div>
                

                </div>
                <div class="col ms-4 px-5 py-3">
                    <p class="lead text-primary text-start fw-bold">Lista de actas </p>
                
                    <asp:GridView CssClass="table" ID="grid_scanned_files" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" DataKeyNames="id" OnRowDeleting="grid_scanned_files_RowDeleting">
                        <Columns>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:Button ID="btn_select" runat="server" CssClass="btn btn-warning" CausesValidation="False" CommandName="Select" Text="Seleccionar" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:Button ID="btn_delete" runat="server"   CssClass="btn btn-danger" CausesValidation="False" CommandName="Delete" Text="Eliminar" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="date" HeaderText="Fecha" DataFormatString="{0:d}" />
                            <asp:BoundField DataField="place" HeaderText="Lugar" />
                            <asp:BoundField DataField="chairman_meeting" HeaderText="Pte. reunión" />
                            <asp:BoundField DataField="resume" HeaderText="Resume" />
                        </Columns>
                    </asp:GridView>

                </div>

            </div>

        </div>
    </main>

</asp:Content>
