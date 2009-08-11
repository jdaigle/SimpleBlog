<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<SimpleBlog.Web.Models.Article>"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Create</title>
</head>
<body>
    <%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>

    <% using (Html.BeginForm()) {%>

        <fieldset>
            <legend>Fields</legend>
            <p>
                <label for="Title">Title:</label>
                <%= Html.TextBox("Title", null, new { size = "100" })%>
                <%= Html.ValidationMessage("Title", "*") %>
            </p>
            <p>
                <label for="ShowOn">Date:</label>
                <%= Html.TextBox("ShowOn") %>
                <%= Html.ValidationMessage("ShowOn", "*") %>
            </p>
            <p>
                <label for="Content" >Content:</label>
                <%= Html.TextArea("Content", new { cols = 50, rows = 10, style = "vertical-align:text-top;" })%>
                <%= Html.ValidationMessage("Content", "*") %>
            </p>
            
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%=Html.ActionLink("Back to List", "Index") %>
    </div>

</body>
</html>

