<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content">
        <h1>Add a new Project</h1>
        <p>
            <%= Html.ActionLink("Go Back", MVC.Projects.Admin())  %>
        </p>
        <% using (Html.BeginForm(MVC.Projects.CreateProject(), FormMethod.Post))
           { %>
        <p>
            <%= Html.TextBox("name", "Project Name") %>
        </p>
        <p>
            <%= Html.TextArea("description", "Project Description", 6, 50, null) %>
        </p>
        <p>
            <%= Html.DropDownList("categoryId", ((List<SimpleBlog.Web.Models.Domain.ProjectCategory>)ViewData["Categories"]).Select(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString()}))   %>
        </p>
        <p>
            <input type="submit" value="create" />
        </p>
        <% } %>
    </div>
</asp:Content>
