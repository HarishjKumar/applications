<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebControls1.aspx.cs" Inherits="AspNetApplication.WebControls1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--
        m-1 => margin m1-,mr-,mt-,,mb-,mx- (ml+mr),my-(mt+mb)
        p-1=> padding, pl-,pr-,pt-,pb-,px-,py
        p|m-[1-5]
        width => w-25,w-50,w-75,w-100, height => h-25-50-75-100--%>
    <asp:Literal ID="literal1" runat="server" />
    <section class="card shadow mx-5">
        <div class="card-header card-title text-center">Application Form</div>
        <div class="card-body">
            <div class ="form-group form-row">
                <div class="col-3 offset-2 text-right">
                    <asp:Label id="lbl1" runat="server" Text="Name"/>
                </div>
                <div class="col-5 text-left">
                    <asp:TextBox id="txtName" runat="server"/>
                </div>
            </div>
            <!-- Password -->
            <div class ="form-group form-row">
                <div class="col-3 offset-2 text-right">
                    <asp:Label id="lbl2" runat="server" Text="Password"/>
                </div>
                <div class="col-5 text-left">
                    <asp:TextBox id="txtPwd" runat="server" TextMode="Password" CssClass="form-control"/>
                </div>
            </div>
            <!-- Address -->
            <div class ="form-group form-row">
                <div class="col-3 offset-2 text-right">
                    <asp:Label id="lbl3" runat="server" Text="Address"/>
                </div>
                <div class="col-5 text-left">
                    <asp:TextBox id="txtAddress" runat="server" TextMode="MultiLine" CssClass="form-control"/>
                </div>
            </div>

            <!-- Gender -->
            <div class ="form-group form-row">
                <div class="col-3 offset-2 text-right">
                    <asp:Label id="lbl4" runat="server" Text="Gender"/>
                </div>
                <div class="col-5 text-left">
                    <asp:RadioButton ID="radio1" runat="server" GroupName="Gender" Text="Male" />
                    <asp:RadioButton ID="radio2" runat="server" GroupName="Gender" Text="Female" />
                </div>
            </div>

            <!-- Location --> 
             <div class="form-group form-row">
                <div class="col-3 offset-2 text-right">
                    <asp:Label id="lbl5" runat="server" Text="Location" />
                </div>
                <div class="col-5 text-left">
                    <asp:DropDownList ID="ddlLocation" runat="server" CssClass="form-control">
                        <asp:ListItem Text="--Select--" Value="0" Selected="True" />
                        <asp:ListItem Text="Bengaluru" Value="Bengaluru"  />
                        <asp:ListItem Text="Chennai" Value="Chennai" />
                        <asp:ListItem Text="Amritsar" Value="Amritsar"  />
                        <asp:ListItem Text="Varanasi" Value="Varanasi" />
                    </asp:DropDownList>
                </div>
            </div>

            <!-- Interests/Hobbies --> 
            <div class="form-group form-row">
                <div class="col-3 offset-2 text-right">
                    <asp:Label id="Label1" runat="server" Text="Interests" />
                </div>
                <div class="col-5 text-left">
                    <asp:CheckBoxList ID="chkInterests" runat="server" RepeatColumns="2"
                        RepeatDirection="Horizontal" RepeatLayout="Table" 
                        CssClass="table table-sm table-striped">
                    </asp:CheckBoxList>
                </div>
            </div>
            
            <div class="form-row">
                <div class="col-4 offset-4 btn-group-lg">
                    <asp:Button id="btnSave" runat="server" Text="Save" CssClass="btn btn-primary mx-2" OnClick="btnSave_Click"/>
                    <asp:Button id="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-secondary mx-2" />
                </div>
            </div>
        </div>
    </section>
</asp:Content>
