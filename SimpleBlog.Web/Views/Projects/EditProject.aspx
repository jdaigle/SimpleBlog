<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SimpleBlog.Web.Models.Domain.Project>" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content">
        <h1>Editing - <%= Html.Encode(Model.Name) %></h1>
        <p>
            <%= Html.ActionLink("Go Back", MVC.Projects.Admin())  %>
        </p>
        <% using (Html.BeginForm(MVC.Projects.EditProject(Model.Id, string.Empty, string.Empty, 0), FormMethod.Post)) { %>
        <fieldset>
            <legend>Details</legend>
            <p>
                Name:
                <%= Html.TextBox("name", Model.Name) %>
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
                <input type="reset" value="reset" />
            </p>
        </fieldset>        
        <% } %>
        <% using (Html.BeginForm(MVC.Projects.ChangeProjectThumbnail(Model.Id, null), FormMethod.Post, new { enctype = "multipart/form-data" })) { %>
        <fieldset>
            <legend>Thumbnail</legend>
            <p>
            <% if (Model.Thumbnail != null) { %> 
                <%= Html.ImageLink(MVC.Projects.List(Model.Id), Url.Action(MVC.Projects.Image(Model.Thumbnail.Id)), Model.Name, new { title = Model.Name }, null)%>
            <% } else { %>
                No Thumbnail Uploaded
            <%}  %>
            </p>                
            <p>
                <input type="file" name="image" />
            </p>
            <p>
                <input type="submit" value="change" />
                <input type="reset" value="reset" />
            </p>
        <% } %>
        <% using (Html.BeginForm(MVC.Projects.ChangeProjectImage(Model.Id, null), FormMethod.Post, new { enctype = "multipart/form-data" })) { %>
        <fieldset>
            <legend>Image</legend>
            <p>
            <% if (Model.Image != null) { %> 
                <%= Html.ImageLink(MVC.Projects.List(Model.Id), Url.Action(MVC.Projects.Image(Model.Image.Id)), Model.Name, new { title = Model.Name }, null)%>
            <% } else { %>
                No Image Uploaded
            <%}  %>
            </p>                
            <p>
                <input type="file" name="image" />
            </p>
            <p>
                <input type="submit" value="change" />
                <input type="reset" value="reset" />
            </p>
        <% } %>
    </div>
</asp:Content>
