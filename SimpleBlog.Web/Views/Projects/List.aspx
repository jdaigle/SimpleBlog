<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SimpleBlog.Web.Models.View.ProjectListing>" %>

<asp:Content ContentPlaceHolderID="additionalStylesheets" runat="server">
    <link rel="stylesheet" type="text/css" href='<%= Links.css.projectsListing_css %>' />
</asp:Content>
<asp:Content ContentPlaceHolderID="mainContent" runat="server">
    <div class="widecontent">
        <div id="allProjectThumbnails">
            <% foreach (var category in Model.Keys) { %>
            <span class="categoryName"><%= Html.Encode(category.Name) %></span>
            <div class="projectThumbnails">
                <% for (int i = 0; i < Model[category].Count; i += 5) { %>
                <div class="thumbnailRow">
                    <% foreach (var project in Model[category].Skip(i).Take(5)) { %>
                    <div class="projectThumbnail">
                        <% if (project.Images.Count > 0) { %>
                        <%= Html.ImageLink(MVC.Projects.List(project.Id), Url.Action(MVC.Projects.Thumbnail(project.Images[0].Id)), project.Name, new { title = project.Name}, null) %>
                        <% } %>
                    </div>
                    <% } %>
                </div>
                <% } %>
            </div>
            <% } %>
        </div>
        <div id="projectDetails">
            <%= Html.ImageLink(MVC.Projects.List(Model.BackId), Links.Content.back_button_png, "Back", new { @class = "backButton" }, null)%>
            <div class="projectImage">
                <img src='<%= Url.Action(MVC.Projects.Image(Model.SelectedProject.Images[0].Id)) %>' alt="Project" />
                <span class="projectImageTitle"><%= Html.Encode(Model.SelectedProject.Name) %></span>
                <span class="projectImageCaption"><%= Html.Encode(Model.SelectedProject.Description) %></span>
            </div>
            <%= Html.ImageLink(MVC.Projects.List(Model.NextId), Links.Content.next_button_png, "Next", new { @class = "nextButton" }, null)%>
        </div>
    </div>
</asp:Content>
