<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SimpleBlog.Web.Models.View.AdminDto>" %>

<asp:Content ContentPlaceHolderID="mainContent" runat="server">
    <div class="content">
        <h1>Projects</h1>
        <ul>
            <% foreach (var category in Model.AllCategories) { %>
            <li style="padding-bottom: 10px">
                <b><%= Html.Encode(category.Name) %></b> (<%= category.Projects.Count %> projects) - 
                <%= Html.ActionLink("rename", MVC.Projects.EditCategory(category.Id)) %>
                <% if (category.Projects.Count == 0) { %>
                <%= Html.ActionLink("delete", MVC.Projects.DeleteCategory(category.Id)) %>
                <% } %>
                <ul style="margin-left: 15px">
                <% foreach (var project in category.Projects) { %>
                    <li>
                        <%= Html.Encode(project.Name) %> - 
                        <%= Html.ActionLink("edit", MVC.Projects.EditProject(project.Id)) %>
                    </li>
                <% } %>
                    <li>
                        <%= Html.ActionLink("add new project", MVC.Projects.CreateProject()) %>
                    </li>
                </ul>
            </li>
            <% } %>
        </ul>
        <p>
            <% using(Html.BeginForm(MVC.Projects.AddCategory())) { %>
            <%= Html.TextBox("name") %>
            <input type="submit" value="Create Category" />
            <% } %>
        </p>
    </div>
</asp:Content>
