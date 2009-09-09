<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SimpleBlog.Web.Models.Domain.ProjectCategory>" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <div class="content">
        <h1>Category - <%= Html.Encode(Model.Name) %></h1>
        <p>
            <%= Html.ActionLink("Go Back", MVC.Projects.Admin())  %>
        </p>
        <p>
            <% using(Html.BeginForm(MVC.Projects.RenameCategory(Model.Id, string.Empty), FormMethod.Post)) { %>
            <label for="name">Rename: </label>
            <%= Html.TextBox("name", Model.Name)  %>
            <input type="submit" value="rename" />
            <% } %>
        </p>
    </div>
</asp:Content>
