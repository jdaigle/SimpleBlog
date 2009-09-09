<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ContentPlaceHolderID="mainContent" runat="server">
    <div class="content">
        <h2>Log On</h2>
        <p>
            <%= Html.ActionLink("Go Back", MVC.Projects.Index()) %>
        </p>
        <p>
            Please enter the <b>admin</b> password.
        </p>
        <% using (Html.BeginForm()) { %>
        <p>
            <label for="password">
                Password:
            </label>
            <%= Html.Password("password") %>
            <%= Html.ValidationMessage("password") %>
        </p>
        <p>
            <%= Html.CheckBox("rememberMe") %>
            <label class="inline" for="rememberMe">
                Remember me?
            </label>
        </p>
        <p>
            <input type="submit" value="Log On" />
        </p>
        <% } %>
    </div>
</asp:Content>
