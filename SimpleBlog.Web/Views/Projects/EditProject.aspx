<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SimpleBlog.Web.Models.Domain.Project>" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content">
        <h1>Editing - <%= Html.Encode(Model.Name) %></h1>
        <p>
            <%= Html.ActionLink("Go Back", MVC.Projects.Admin())  %>
        </p>
        <% using (Html.BeginForm(MVC.Projects.EditProject(Model.Id, string.Empty, string.Empty, 0), FormMethod.Post)) { %>
        <p>
            Name: <%= Html.TextBox("name", Model.Name) %>
        </p>
        <p>
            Description:<br />
            <%= Html.TextArea("description", Model.Description, 6, 50, null) %>
        </p>
        <p>
            <%= Html.DropDownList("categoryId", ((List<SimpleBlog.Web.Models.Domain.ProjectCategory>)ViewData["Categories"]).Select(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString(), Selected = x.Id == Model.Category.Id})) %>
        </p>
        <p>
            <input type="submit" value="edit" />
        </p>
        <% } %>
    </div>
</asp:Content>
