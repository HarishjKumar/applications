<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Validators.aspx.cs" Inherits="AspNetApplication.validator" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function myValidation(s, e) {
            if (e.Value.length > 4) {
                e.IsValid = true;
            } else {
                e.IsValid = false;
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class ="container">
        <h2 class="bg-success text-white font-weight-bold text-center">Working with Validators</h2>
        <asp:ValidationSummary id="sum1" runat="server" DisplayMode="List"
            ShowSummary="true" CssClass="alert alert-danger" HeaderText="Errors"></asp:ValidationSummary>
        <div class="row">
            <div class="col-3 p-2">
                <div class="card h-100">
                    <div class="card-header card-title bg-warning">Required Field Validator</div>
                    <div class="card-body">
                        <div class="form-group">  
                            <asp:TextBox ID="txtName" CssClass="form-control" PlaceHolder="EnterName" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator id="rfv1" runat="server" ControlToValidate="txtName" display="Static" Text="*"
                                ErrorMessage="Name is Required."
                                CssClass="alert alert-danger" />
                        </div>
                    </div>
                </div>
            </div>
                        <div class="col-3 p-2">
                <div class="card h-100">
                    <div class="card-header card-title bg-warning">Compare Validator 1</div>
                    <div class="card-body">
                        <div class="form-group">
                            <asp:Textbox id="txtPwd" Cssclass="form-control" runat="server" placeholder="Enter PassWord" TextMode="password" />
                            <asp:Textbox id="txtConfirm" Cssclass="form-control" runat="server" placeholder="Confirm PassWord" TextMode="password"/>
                            <asp:CompareValidator id="cv1" runat="server" ControlToValidate="txtConfirm" display="Static" Text="*"
                                ErrorMessage="PassWords Do Not Match."
                                CssClass="alert alert-danger"
                                ControlToCompare="txtPwd" Operator="Equal" Type="String" />
                        </div>
                    </div>
                </div>
            </div>
                                    <div class="col-3 p-2">
                <div class="card h-100">
                    <div class="card-header card-title bg-warning">Compare Validator 2</div>
                    <div class="card-body">
                        <div class="form-group">
                            <asp:Textbox id="txtDate" Cssclass="form-control" runat="server" placeholder="Enter BirthDate" />
                            <asp:CompareValidator id="cv2" runat="server" ControlToValidate="txtDate" display="Static" Text="*"
                                ErrorMessage="Invalid Date."
                                CssClass="alert alert-danger"
                                Operator="DataTypeCheck" Type="Date" />
                        </div>
                    </div>
                </div>
            </div>
                                                <div class="col-3 p-2">
                <div class="card h-100">
                    <div class="card-header card-title bg-warning">Range Validator</div>
                    <div class="card-body">
                        <div class="form-group">
                            <asp:Textbox id="txtAge" Cssclass="form-control" runat="server" placeholder="Enter Age" />
                            <asp:RangeValidator id="rv1" runat="server" ControlToValidate="txtAge" display="Static" Text="*"
                                ErrorMessage="Age should be between 18 and 100."
                                CssClass="text-danger"
                               Type="Integer"
                                MinimumValue="18"
                                MaximumValue="100"/>
                        </div>
                    </div>
                </div>
            </div>
                                                            <div class="col-3 p-2">
                <div class="card h-100">
                    <div class="card-header card-title bg-warning">Regular Expression Validator 1</div>
                    <div class="card-body">
                        <div class="form-group">
                            <asp:Textbox id="txtEmail" Cssclass="form-control" runat="server" placeholder="Enter Email" />
                            <asp:RegularExpressionValidator id="reg1" runat="server" ControlToValidate="txtEmail" display="Static" Text="*"
                                ErrorMessage="Invalid Email Format."
                                CssClass="text-danger"
                               ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"/>
                        </div>
                    </div>
                </div>
            </div>
                                                                        <div class="col-3 p-2">
                <div class="card h-100">
                    <div class="card-header card-title bg-warning">Regular Expression Validator 2</div>
                    <div class="card-body">
                        <div class="form-group">
                            <asp:Textbox id="txtUserId" Cssclass="form-control" runat="server" placeholder="Enter a Valid User Id" />
                            <asp:CustomValidator id="cv3" runat="server" ControlToValidate="txtUserId" display="Static" Text="*"
                                ErrorMessage="UserId should be 5 or more letters and non-existent."
                                CssClass="text-danger"
                                ClientValidationFunction="myValidation"
                                OnServerValidate="cv3_ServerValidate"
                                ></asp:CustomValidator>
                        </div>
                    </div>
                </div>
            </div>

        </div>
        <div class="row">
            <div class="col-12 text-center">
                <button class="btn btn-outline-danger">Submit</button>
            </div>
        </div>
    </section>
</asp:Content>
